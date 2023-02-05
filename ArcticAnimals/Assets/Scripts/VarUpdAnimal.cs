using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VarUpdAnimal : MonoBehaviour
{

    public GameObject[] PreFAnimal = new GameObject[GlobalVar.SumAnimals];
    public GameObject Price;
    public GameObject ReproductionOn;

    public Text DNA;
    public Text Matter;
    public Text Population;
    public Text FeedCD;
    public Text BtnFood;
    public Text BtnMinerals;
    public Text BtnOxygen;
    public Image HungerBar;
    public Image LoveBar;

    private string CorrectMinerals;
    private string CorrectOxygen;
    private string[] TextDoc;


    private int AnimalNumber = 0;
    private int AnimalLimit = 25;

    void Awake()
    {
        AnimalNumber = GlobalVar.AnimalNumber;
        AnimalLimit = GlobalVar.AnimalLimit;

        if (AnimalLimit > GlobalVar.PopulAnimal[AnimalNumber]) AnimalLimit = GlobalVar.PopulAnimal[AnimalNumber];

        for (int i = 0; i < AnimalLimit; i++)
        {
            SpawnAnimal();
        }
    }
    void Start()
    {
        TextDoc = GlobalVar.DescriptionAnimal[AnimalNumber].text.Split('\n');
        CorrectMinerals = TextDoc[2].Substring(0,8);
        CorrectOxygen = TextDoc[3].Substring(0, 10);
        BtnMinerals.text = GlobalVar.MineralsAnimal[AnimalNumber];
        BtnOxygen.text = GlobalVar.OxygenAnimal[AnimalNumber];
        if (GlobalVar.FoodAnimal[AnimalNumber] == 0) BtnFood.text = "Food:Meat";
        else BtnFood.text = "Food:Vegetation";

        
    }
    void SpawnAnimal()
    {
        Vector3 spawncoord = new Vector3(0, 0, 1);
        spawncoord.x = UnityEngine.Random.Range(-5.0f, 25.0f);
        spawncoord.y = UnityEngine.Random.Range(-3.0f, 12.0f);

        Instantiate(PreFAnimal[GlobalVar.AnimalNumber], spawncoord, Quaternion.identity);
    }
    void CheckMaintenance()
    {
        int wrongM = 0;
        int wrongO = 0;
        if (CorrectMinerals.Equals(BtnMinerals.text)) wrongM = 0;
        else wrongM = 1;
        if (CorrectOxygen.Equals(BtnOxygen.text)) wrongO = 0;
        else wrongO = 1;
        GlobalVar.WrongMaintenance = wrongM + wrongO;
    }

    void Update()
    {
        if (GlobalVar.ReproductionAnimal[AnimalNumber] > 0) ReproductionOn.SetActive(true);
        else ReproductionOn.SetActive(false);

        CheckMaintenance();
        DNA.text = "" + GlobalVar.DNA;
        Matter.text = "" + GlobalVar.Matter;
        Population.text = GlobalVar.TextUse["Population:"] + GlobalVar.PopulAnimal[AnimalNumber];
        long DTnow = DateTime.Now.Ticks / 10000000;

        long feedcd = (GlobalVar.FeedCD[AnimalNumber] - DTnow);
        long min=0;
        long sec=0;
        if (feedcd > 0)
        {
            min = feedcd / 60;
            sec = feedcd % 60;
            FeedCD.text = string.Format("{0:00}:{1:00}", min, sec);
            Price.SetActive(false);
        }
        else
        {
            FeedCD.text = "";
            Price.SetActive(true);
        }

        long hunger = (GlobalVar.HungerAnimal[AnimalNumber] - DTnow)/864;
        
        if (hunger < 0) hunger = 0;
        HungerBar.fillAmount = (float)hunger / 100;

        long love = (GlobalVar.LoveAnimal[AnimalNumber] - DTnow) / 864;

        if (love < 0) love = 0;
        LoveBar.fillAmount = (float)love / 100;

        int feedprice = (GlobalVar.PopulAnimal[AnimalNumber] / 3)/2;
        int lovebonus = ((int)(feedprice*((float)love /100)));
        GlobalVar.PriceFeedMatter = feedprice*2 - lovebonus+1;
    }
}
