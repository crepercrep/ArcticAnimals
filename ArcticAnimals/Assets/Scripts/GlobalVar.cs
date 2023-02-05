using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    //PRICE
    public static int PriceMineMatter = 25;
    public static int PriceSynthesizeMatter = 45;
    public static int PriceSynthesizeDNA = 35;
    public static int PriceFeedMatter = 5;
    //PRICE
    public static bool FirstPlay = false;
    public static bool First = true;
    public static int FirstsWorkingNeed = 2;
    public static int FirstsWorkingNow = 0;

    public static float QuarryDNASpeed = 0.5f;
    public static float QuarryMatterSpeed = 1;
    public static int QuarryDNAMax = 100;
    public static int QuarryMatterMax = 100;

    public static float QuarryForfeitDNAFood = 0;
    public static float QuarryForfeitMatterFood = 0;
    public static float QuarryForfeitDNACollapse = 0;
    public static float QuarryForfeitMatterCollapse = 0;

    public static int AnimalNumber = 0;
    public static int PetAnimals = 0;
    public static int WrongMaintenance = 0;
    public static int DNA = 0;
    public static int Matter = 0;
    public static int AnimalLimit = 25;
    

    public static int SumAnimals = 15;

    public static long QuarryCollapseCD = 0;
    public static long QuarryDNA = 0;
    public static long QuarryMatter = 0;
    public static long TimeLastExit = 0;

    public static string PurposesState = "0";

    public static int[] PopulAnimal = new int[SumAnimals];
    public static int[] FoodAnimal = new int[SumAnimals];
    public static int[] ReproductionAnimal = new int[SumAnimals];
    public static int[] ResearchAnimal = new int[SumAnimals];
    public static int[] OpenManual = new int[SumAnimals];

    public static long[] HungerAnimal = new long[SumAnimals];
    public static long[] FeedCD = new long[SumAnimals];
    public static long[] LoveAnimal = new long[SumAnimals];
    public static long[] PetCD = new long[SumAnimals];
    

    public static string[] MineralsAnimal = new string[SumAnimals];
    public static string[] OxygenAnimal = new string[SumAnimals];

    public static string Language = "En";

    


    public static UnityEngine.Sprite[] SpriteAnimal = new UnityEngine.Sprite[SumAnimals];
    public static UnityEngine.Sprite[] ImageAnimal = new UnityEngine.Sprite[SumAnimals];
    public static TextAsset[] DescriptionAnimal = new TextAsset[SumAnimals];
    public static TextAsset[] DescriptionAnimalRU = new TextAsset[SumAnimals];
    public static TextAsset[] ResearchQuestionsAnimal = new TextAsset[15];
    public static TextAsset[] ResearchQuestionsAnimalRU = new TextAsset[15];
    public static TextAsset[] ManualText = new TextAsset[11];
    public static TextAsset[] ManualTextRU = new TextAsset[11];


    public static Dictionary<string, string>  NameType = new Dictionary<string, string>();

    public static Dictionary<string, string> TextRu = new Dictionary<string, string>();
    public static Dictionary<string, string> TextEn = new Dictionary<string, string>();
    public static Dictionary<string, string> TextUse = new Dictionary<string, string>();

    public static void Addtext(string id, string en, string ru)
    {
        
        TextRu.Add(id, ru);
        if (en.Equals("")) TextEn.Add(id, id);
        else TextEn.Add(id, en);

    }
    public static void SelectText()
    {
        switch (Language)
        {
            case "Ru":
                TextUse = TextRu;
                break;
            case "En":
                TextUse = TextEn;
                break;
            default:
                TextUse = TextEn;
                break;
        }
    }

    public static void SetSave(string Name,string Type)
    {
        NameType.Add(Name, Type);
    }

    //Int
    public static void SetValueInt(string name,int val)
    {
        switch (name)
        {
            case "DNA":
                DNA = val;
                break;
            case "Matter":
                Matter = val; 
                break;
            case "AnimalLimit":
                AnimalLimit = val;
                break;
        }
    }
    public static int GetValueInt(string name)
    {
        switch(name){
            case "DNA":
                return DNA;
            case "Matter":
                return Matter;
            case "AnimalLimit":
                return AnimalLimit;
            default:
                return 0;
        }
    }

    //String 
    public static void SetValueStr(string name,string val)
    {
        switch (name)
        {
            case "QuarryDNA":
                QuarryDNA = long.Parse(val); 
                break;
            case "QuarryMatter":
                QuarryMatter = long.Parse(val);
                break;
            case "TimeLastExit":
                TimeLastExit = long.Parse(val);
                break;
            case "QuarryCollapseCD":
                QuarryCollapseCD = long.Parse(val);
                break;
            case "Language":
                Language = val;
                break;
            case "PurposesState":
                PurposesState = val;
                break;
            case "Forfeits":
                if (val.Equals("0"))
                {
                    QuarryForfeitDNAFood = 0;
                    QuarryForfeitMatterFood = 0;
                    QuarryForfeitDNACollapse = 0;
                    QuarryForfeitMatterCollapse = 0;
                }
                else
                {
                    string[] temp = val.Split('J');
                    QuarryForfeitDNAFood = float.Parse(temp[0]);
                    QuarryForfeitMatterFood = float.Parse(temp[1]);
                    QuarryForfeitDNACollapse = float.Parse(temp[2]);
                    QuarryForfeitMatterCollapse = float.Parse(temp[3]);
                }
                break;
            case "OpenManual":
                if (val.Equals("0"))
                {
                    for (int i = 0; i < 11; i++) OpenManual[i] = 1;
                    OpenManual[1] = 0;
                    OpenManual[2] = 0;
                    OpenManual[3] = 0;
                    OpenManual[4] = 0;
                    OpenManual[10] = 0;
                }
                else
                {
                    string[] temp2 = val.Split('J');
                    for (int i = 0; i < 11; i++) OpenManual[i] = int.Parse(temp2[i]);
                }
                break;
            case "QuarrySpeed":
                if (val.Equals("0"))
                {
                    QuarryDNASpeed = 0.005f;
                    QuarryMatterSpeed = 0.01f;
                }
                else
                {
                    string[] temp1 = val.Split('J');
                    QuarryDNASpeed = float.Parse(temp1[0]);
                    QuarryMatterSpeed = float.Parse(temp1[1]);
                }
                break;
        }
    }
    public static string GetValueStr(string name)
    {
        switch (name)
        {
            case "QuarryDNA":
                return QuarryDNA + "";
            case "QuarryMatter":
                return QuarryMatter + "";
            case "TimeLastExit":
                return TimeLastExit + "";
            case "QuarryCollapseCD":
                return QuarryCollapseCD + "";
            case "Language":
                return Language;
            case "PurposesState":
                return PurposesState;
            case "Forfeits":
                string val = QuarryForfeitDNAFood+"J"+QuarryForfeitMatterFood + "J" + QuarryForfeitDNACollapse + "J" + QuarryForfeitMatterCollapse;
                return val;
            case "OpenManual":
                string val2 ="";
                for (int i = 0; i < 11; i++) val2 += OpenManual[i] + "J";
                return val2;
            case "QuarrySpeed":
                string val1 = QuarryDNASpeed + "J" + QuarryMatterSpeed;
                return val1;
            default:
                return "";
        }
    }

    //Int[] 
    public static void SetValueInt(string name, int numbAnimal,int val)
    {
        switch (name)
        {
            case "PopulAnimal":
                PopulAnimal[numbAnimal] = val;
                break;
            case "FoodAnimal":
                FoodAnimal[numbAnimal] = val;
                break;
            case "ReproductionAnimal":
                ReproductionAnimal[numbAnimal] = val;
                break;
            case "ResearchAnimal":
                ResearchAnimal[numbAnimal] = val;
                break;
        }
    }
    public static int GetValueInt(string name,int numbAnimal)
    {
        switch (name)
        {
            case "PopulAnimal":
                return PopulAnimal[numbAnimal];
            case "FoodAnimal":
                return FoodAnimal[numbAnimal];
            case "ReproductionAnimal":
                return ReproductionAnimal[numbAnimal];
            case "ResearchAnimal":
                return ResearchAnimal[numbAnimal];
            default:
                return 0; 
        }
    }

    //String[]
    public static void SetValueStr(string name, int numbAnimal, string val)
    {
        switch (name)
        {
            case "HungerAnimal":
                HungerAnimal[numbAnimal] = long.Parse(val);
                break;
            case "FeedCD":
                FeedCD[numbAnimal] = long.Parse(val);
                break;
            case "LoveAnimal":
                LoveAnimal[numbAnimal] = long.Parse(val);
                break;
            case "PetCD":
                PetCD[numbAnimal] = long.Parse(val);
                break;
            case "MineralsAnimal":
                MineralsAnimal[numbAnimal] = val;
                break;
            case "OxygenAnimal":
                OxygenAnimal[numbAnimal] = val;
                break;
        }
    }
    public static string GetValueStr(string name, int numbAnimal)
    {
        switch (name)
        {
            case "HungerAnimal":
                return HungerAnimal[numbAnimal] + "";
            case "FeedCD":
                return FeedCD[numbAnimal] + "";
            case "LoveAnimal":
                return LoveAnimal[numbAnimal] + "";
            case "PetCD":
                return PetCD[numbAnimal] + "";
            case "MineralsAnimal":
                return MineralsAnimal[numbAnimal];
            case "OxygenAnimal":
                return OxygenAnimal[numbAnimal];
            default:
                return "";
        }
    }

    public static void QuarryChangeDNASpeed(float speed)
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        int Currentvalue = QuarryDNAMax - (int)((QuarryDNA - nowtime) * QuarryDNASpeed);
        if (Currentvalue > QuarryDNAMax) Currentvalue = QuarryDNAMax;
        if (Currentvalue < 1) Currentvalue = 0;
        int timegone = (int)(Currentvalue / QuarryDNASpeed);
        QuarryRecalculation("DNA", speed, QuarryDNAMax, Currentvalue, timegone);
    }
    public static void QuarryChangeMatterSpeed(float speed)
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        int Currentvalue = QuarryMatterMax - (int)((QuarryMatter - nowtime) * QuarryMatterSpeed);
        if (Currentvalue > QuarryMatterMax) Currentvalue = QuarryMatterMax;
        if (Currentvalue < 1) Currentvalue = 0;
        int timegone = (int)(Currentvalue / QuarryMatterSpeed);
        QuarryRecalculation("Matter", speed, QuarryMatterMax, Currentvalue, timegone);
    }
    public static void QuarryChangeDNAMax(int max)
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        int Currentvalue = QuarryDNAMax - (int)((QuarryDNA - nowtime) * QuarryDNASpeed);
        if (Currentvalue > QuarryDNAMax) Currentvalue = QuarryDNAMax;
        if (Currentvalue < 1) Currentvalue = 0;
        int timegone = (int)(Currentvalue / QuarryDNASpeed);
        QuarryRecalculation("DNA", QuarryDNASpeed, max, Currentvalue, timegone);
    }
    public static void QuarryChangeMatterMax(int max)
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        int Currentvalue = QuarryMatterMax - (int)((QuarryMatter - nowtime) * QuarryMatterSpeed);
        if (Currentvalue > QuarryMatterMax) Currentvalue = QuarryMatterMax;
        if (Currentvalue < 1) Currentvalue = 0;
        int timegone = (int)(Currentvalue / QuarryMatterSpeed);

        QuarryRecalculation("Matter", QuarryMatterSpeed, max, Currentvalue, timegone);
    }
    public static void QuarryRecalculation(string Type, float Speed, int Max, int Current, int TimeGone)
    {
        
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        long Addtime = (long)(((Max - Current) / Speed) + TimeGone);
        long NewTime = nowtime + Addtime - TimeGone;
        switch (Type)
        {
            case "DNA":
                QuarryDNAMax = Max;
                QuarryDNASpeed = Speed;
                QuarryDNA = NewTime;
                break;
            case "Matter":
                QuarryMatterMax = Max;
                QuarryMatterSpeed = Speed;
                QuarryMatter = NewTime;
                break;
        }
    }
}
