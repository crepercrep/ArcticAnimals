using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Animal : MonoBehaviour
{
    public GameObject Heart;

    public float TextureCooldown = 5f;
    public float AnimalSpeed = 1f;
    private GameObject Animall;

    public GameObject Texture1;
    public GameObject Texture2;
    public GameObject Texture3;

    public GameObject JumpTexture1;
    public GameObject JumpTexture2;

    public float JumpRange = 3f;

    private bool IsPet = false;
    private bool IsJump = false;
    private Vector3 target = new Vector3(0, 0, 1);
    private float cooldown = 0;
    private float idle = 1001;

    private int walkcooldown = 5;

    private int NoIdle = 750;
    private int BeIdle = 1000;
    private int DoJump = 25;


    void Awake()
    {
        Animall = gameObject;
        SpriteRenderer T1 = Texture1.GetComponent<SpriteRenderer>();
        SpriteRenderer T2 = Texture2.GetComponent<SpriteRenderer>();
        SpriteRenderer T3 = Texture3.GetComponent<SpriteRenderer>();
        SpriteRenderer JT1 = JumpTexture1.GetComponent<SpriteRenderer>();
        SpriteRenderer JT2 = JumpTexture2.GetComponent<SpriteRenderer>();
        byte red = (byte)Random.Range(225, 256);
        byte green = (byte)Random.Range(225, 256);
        byte blue = (byte)Random.Range(225, 256);
        int BeWhite = Random.Range(1, 101);
        if (BeWhite < 21)
        {
            red = (byte)255;
            green = (byte)255;
            blue = (byte)255;
        }
        Color AnimalColor = new Color32(red, green, blue, 255);
        T1.color = AnimalColor;
        T2.color = AnimalColor;
        T3.color = AnimalColor;
        JT1.color = AnimalColor;
        JT2.color = AnimalColor;
        GlobalVar.PetAnimals = 0;
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        if ((nowtime < GlobalVar.PetCD[GlobalVar.AnimalNumber]))
        {
            IsPet = true;
        }
    }
    void Start()
    {
        int Temperament = Random.Range(0, 5);
        switch (Temperament)
        {
            case 0: 
                break;
            case 1: 
                NoIdle = 250;
                break;
            case 2: 
                NoIdle = 550;
                break;
            case 3: 
                NoIdle = 950;
                break;
            case 4: 
                NoIdle = 1250;
                break; 
        }
        Temperament = Random.Range(0, 5);
        switch (Temperament)
        {
            case 0:
                BeIdle = NoIdle + 250;
                break;
            case 1:
                BeIdle = NoIdle + 75;
                break;
            case 2:
                BeIdle = NoIdle + 450;
                break;
            case 3:
                BeIdle = NoIdle + 750;
                break;
            case 4:
                BeIdle = NoIdle + 1050;
                break;
        }
        Temperament = Random.Range(0, 5);
        switch (Temperament)
        {
            case 0:
                break;
            case 1:
                DoJump = 11;
                break;
            case 2:
                DoJump = 35;
                break;
            case 3:
                DoJump = 50;
                break;
            case 4:
                DoJump = 75;
                break;
        }
        AnimalSpeed = Random.Range(1f, 3f);
        TextureCooldown = Random.Range(3f, 5.0001f);
    }
    private void Idle()
    {
        JumpTexture2.SetActive(false);
        JumpTexture1.SetActive(false);
        Texture3.SetActive(false);
        Texture2.SetActive(false);
        Texture1.SetActive(true);
        if (idle > BeIdle)
        {
            int action = Random.Range(0, 100);
            if (action < DoJump)
            {
                IsJump = true;
                float temptargetx = Random.Range(-JumpRange, JumpRange);
                float temptargety = Mathf.Sqrt((JumpRange* JumpRange - (temptargetx * temptargetx)));
                if (action < 2)
                {
                    temptargety *= -1;
                }
                target.x = Animall.transform.position.x + temptargetx;
                target.y = Animall.transform.position.y + temptargety;
                if (target.x < -8.5f)
                {
                    target.x = Animall.transform.position.x - temptargetx;
                }
                else if (target.x > 29.5f)
                {
                    target.x = Animall.transform.position.x - temptargetx;
                }
                if (target.y < -4.5f)
                {
                    target.y = Animall.transform.position.y - temptargety;
                }
                else if (target.y > 14.5f)
                {
                    target.y = Animall.transform.position.y - temptargety;
                }
            }
            else
            {
                Texture1.SetActive(false);
                Texture3.SetActive(true);
                target.x = Animall.transform.position.x + (Random.Range(-11.0f, 11.0f));
                target.y = Animall.transform.position.y + (Random.Range(-11.0f, 11.0f));
                if (target.x < -8.5f)
                {
                    target.x = -7.5f;
                }
                else if(target.x > 29.5f)
                {
                    target.x = 28.5f;
                }
                if (target.y < -4.5f)
                {
                    target.y = -3.5f;
                }
                else if (target.y > 14.5f)
                {
                    target.y = 13.5f;
                }
            }
            
            idle = 0;
            cooldown = 0;
        }
        

    }
    private void Walk()
    {
        cooldown += (100 * Time.deltaTime);
        Vector3 walkno = (target - Animall.transform.position);
        Vector3 walk = walkno.normalized;

        if ((walkno.x * walkno.x < 0.1f) && (walkno.y * walkno.y < 0.1f))
        {
            cooldown = 0;
            idle = NoIdle;
            return;
        }

        Rotate();

        Animall.transform.position += walk * AnimalSpeed * Time.deltaTime;

        if (cooldown > walkcooldown * TextureCooldown)
        {
            if (cooldown> walkcooldown*2 * TextureCooldown)
            {
                cooldown = 0;
                Texture2.SetActive(false);
                Texture3.SetActive(true);

            }
            else
            {
                Texture1.SetActive(false);
                Texture2.SetActive(true);
                Texture3.SetActive(false);
            }
        }

    }

    private void Jump()
    {
        cooldown+=(100*Time.deltaTime);
        Vector3 walkno = (target - Animall.transform.position);
        Vector3 walk = walkno.normalized;
        
        if ((walkno.x* walkno.x < 0.1f) && (walkno.y* walkno.y <0.1f))
        {
            cooldown = 0;
            idle = NoIdle;
            IsJump = false;
            return;
        }
        
        Rotate();

        Animall.transform.position += walk * AnimalSpeed*7.5f * Time.deltaTime;
        if (cooldown > 0.1 * TextureCooldown)
        {
            if (cooldown > 2.5 * TextureCooldown)
            {
                JumpTexture1.SetActive(false);
                JumpTexture2.SetActive(true);
            }
            else
            {
                Texture1.SetActive(false);
                JumpTexture1.SetActive(true);
            }


        }
    }
    private void Rotate()
    {
        if (target.x > Animall.transform.position.x)
        {
            Texture1.transform.localRotation = Quaternion.Euler(0, 180, 0);
            Texture2.transform.localRotation = Quaternion.Euler(0, 180, 0);
            Texture3.transform.localRotation = Quaternion.Euler(0, 180, 0);
            JumpTexture1.transform.localRotation = Quaternion.Euler(0, 180, 0);
            JumpTexture2.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            Texture1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Texture2.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Texture3.transform.localRotation = Quaternion.Euler(0, 0, 0);
            JumpTexture1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            JumpTexture2.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        idle+=(100 * Time.deltaTime);
        if (IsJump)
        {
            Jump();
            return;
        }
        if (idle < NoIdle)
        {
            Walk();
        }
        else
        {
            Idle();
        }
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.transform.position.y > collision.gameObject.transform.position.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1.001f);
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 0.999f);
        }
    }
    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu")) return;
        if (!IsPet)
        {
            Vector3 spawncoord = new Vector3(0, 0, 1);
            spawncoord.x = Animall.transform.position.x;
            spawncoord.y = Animall.transform.position.y;
            Instantiate(Heart, spawncoord, Quaternion.identity);
            IsPet = true;
            GlobalVar.PetAnimals += 1;
        }
        else
        {
            idle = BeIdle;
            return;
        }
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        if ( (nowtime > GlobalVar.PetCD[GlobalVar.AnimalNumber]))
        {
            int NeedPet = GlobalVar.PopulAnimal[GlobalVar.AnimalNumber]/2;
            if (NeedPet > 25) NeedPet = 25;
            if (GlobalVar.PetAnimals >= NeedPet)
            {
                GlobalVar.PetAnimals =0;
                if (GlobalVar.LoveAnimal[GlobalVar.AnimalNumber] > nowtime)
                {
                    GlobalVar.PetCD[GlobalVar.AnimalNumber] = nowtime + 300;
                    GlobalVar.LoveAnimal[GlobalVar.AnimalNumber] += 14400;
                    if (GlobalVar.LoveAnimal[GlobalVar.AnimalNumber] > (nowtime + 14400 * 6))
                    {
                        GlobalVar.LoveAnimal[GlobalVar.AnimalNumber] += 14400 * 6;
                    }
                }
                else
                {
                    GlobalVar.LoveAnimal[GlobalVar.AnimalNumber] = nowtime + 14400;
                }
            }
            
        }else idle = BeIdle;




    }
}
