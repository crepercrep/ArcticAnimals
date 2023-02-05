using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsAnimals : MonoBehaviour
{

    public Transform Windows;
    //public int Food = 0;
    [Range(0, 2)]
    public int[] Food = new int[GlobalVar.SumAnimals];

    private int AnimalNumber = 0;


    void Awake()
    {
        AnimalNumber = GlobalVar.AnimalNumber;
    }

    public void SetActive(GameObject MaintenanceBtns)
    {
        if (MaintenanceBtns.active)
        {
            MaintenanceBtns.SetActive(false);

        }
        else
        {
            MaintenanceBtns.SetActive(true);
        }
    }
    public void ActiveWindows(GameObject Window)
    {
        if (!(Window.active))
        {
            for (int i = 0; i < Windows.childCount; i++)
            {
                Windows.GetChild(i).gameObject.SetActive(false);
            }
            Window.SetActive(true);

        }
        else
        {
            for (int i = 0; i < Windows.childCount; i++)
            {
                Windows.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void BtnFood(Text BtnFood)
    {
        if (BtnFood.text.Equals("Food:Meat"))
        {
            GlobalVar.FoodAnimal[AnimalNumber] = 1;
            BtnFood.text = "Food:Vegetation";
        }
        else
        {
            GlobalVar.FoodAnimal[AnimalNumber] = 0;
            BtnFood.text = "Food:Meat";
        }
    }

    public void Reproduction()
    {
        if (GlobalVar.ReproductionAnimal[AnimalNumber] > 0)
        {
            GlobalVar.ReproductionAnimal[AnimalNumber] = 0;
        }
        else
        {
            GlobalVar.ReproductionAnimal[AnimalNumber] = 1;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    private bool FoodRight()
    {
        if (Food[AnimalNumber] == 2) return true;
        if (GlobalVar.FoodAnimal[AnimalNumber] == Food[AnimalNumber])
        {
            return true;
        }
        else return false;
    }
    public void Feed()
    {
        if (GlobalVar.Matter < GlobalVar.PriceFeedMatter) return;
        
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        if (nowtime>GlobalVar.FeedCD[AnimalNumber])
        {
            GlobalVar.Matter -= GlobalVar.PriceFeedMatter;
            int WrongCD = 0;
            if (GlobalVar.WrongMaintenance > 0)
            {
                GlobalVar.LoveAnimal[AnimalNumber] -= 3600 * 2;
                if (GlobalVar.WrongMaintenance > 1)
                {
                    GlobalVar.LoveAnimal[AnimalNumber] -= 3600 ;
                    GlobalVar.HungerAnimal[AnimalNumber] -= 1800;
                    WrongCD = 900;
                }
            }
            GlobalVar.FeedCD[AnimalNumber] = nowtime + 1800+ WrongCD;
            if (FoodRight())
            {
                if (GlobalVar.HungerAnimal[AnimalNumber] > nowtime)
                {
                    GlobalVar.HungerAnimal[AnimalNumber] += 28800;
                    if (GlobalVar.HungerAnimal[AnimalNumber] > (nowtime + 28800 * 3))
                    {
                        GlobalVar.HungerAnimal[AnimalNumber] = nowtime + 28800 * 3;
                    }

                }
                else
                {
                    GlobalVar.HungerAnimal[AnimalNumber] = nowtime + 28800;
                }
            }
            else
            {
                GlobalVar.HungerAnimal[AnimalNumber] -= 7200;
            }
                
            
            
        }
    }


}
