using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saves : MonoBehaviour
{
    
    void Awake()
    {
        if ((!(PlayerPrefs.HasKey("DNA")))&&(GlobalVar.First))
        {
            GlobalVar.FirstPlay = true;
        }
        
        if (GlobalVar.FirstsWorkingNow < GlobalVar.FirstsWorkingNeed)
        {
            for (int i = 0; i < GlobalVar.SumAnimals; i++)
            {
                GlobalVar.SpriteAnimal[i] = Resources.Load<Sprite>("Animals/Animal" + i + "/Animal" + i + "Idle");
                GlobalVar.ImageAnimal[i] = Resources.Load<Sprite>("Animals/Animal" + i + "/Animal" + i);
                GlobalVar.DescriptionAnimal[i] = Resources.Load("Animals/Animal" + i + "/DescAnimal" + i) as TextAsset;
                GlobalVar.DescriptionAnimalRU[i] = Resources.Load("Animals/Animal" + i + "/DescAnimal" + i+"RU") as TextAsset;
                GlobalVar.ResearchQuestionsAnimal[i] = Resources.Load("Animals/Animal" + i + "/QuestionsAnimal" + i) as TextAsset;
                GlobalVar.ResearchQuestionsAnimalRU[i] = Resources.Load("Animals/Animal" + i + "/QuestionsAnimal" + i + "RU") as TextAsset;
            }
            for (int i = 0; i < 11; i++)
            {
                GlobalVar.ManualText[i] = Resources.Load("Manual/Manual" + i) as TextAsset;
                GlobalVar.ManualTextRU[i] = Resources.Load("Manual/Manual" + i + "RU") as TextAsset;
            }


            GlobalVar.SetSave("DNA", "Int");
            GlobalVar.SetSave("Matter", "Int");
            GlobalVar.SetSave("QuarryDNA", "Str");
            GlobalVar.SetSave("QuarryMatter", "Str");
            GlobalVar.SetSave("PopulAnimal", "Int[]");
            GlobalVar.SetSave("FoodAnimal", "Int[]");
            GlobalVar.SetSave("HungerAnimal", "Str[]");
            GlobalVar.SetSave("FeedCD", "Str[]");
            GlobalVar.SetSave("LoveAnimal", "Str[]");
            GlobalVar.SetSave("PetCD", "Str[]");
            GlobalVar.SetSave("MineralsAnimal", "Str[]");
            GlobalVar.SetSave("OxygenAnimal", "Str[]");
            GlobalVar.SetSave("Language", "Str"); 
            GlobalVar.SetSave("AnimalLimit", "Int"); 
            GlobalVar.SetSave("TimeLastExit", "Str"); 
            GlobalVar.SetSave("ReproductionAnimal", "Int[]");
            GlobalVar.SetSave("PurposesState", "Str");
            GlobalVar.SetSave("Forfeits", "Str");
            GlobalVar.SetSave("QuarrySpeed", "Str");
            GlobalVar.SetSave("QuarryCollapseCD", "Str");
            GlobalVar.SetSave("ResearchAnimal", "Int[]");
            GlobalVar.SetSave("OpenManual", "Str");
            /*
                    public static int QuarryDNAMax
                    public static int QuarryMatterMax
             */

            foreach (string element in GlobalVar.NameType.Keys)
            {
                string type = GlobalVar.NameType[element];
                switch (type)
                {
                    case "Int":
                        GlobalVar.SetValueInt(element, PlayerPrefs.GetInt(element, 15));
                        break;

                    case "Str":
                        GlobalVar.SetValueStr(element, PlayerPrefs.GetString(element, "0"));
                        break;

                    case "Int[]":
                        for (int i = 0; i < GlobalVar.SumAnimals; i++)
                        {
                            GlobalVar.SetValueInt(element, i ,PlayerPrefs.GetInt(element+i, 0));
                        }
                        break;

                    case "Str[]":
                        for (int i = 0; i < GlobalVar.SumAnimals; i++)
                        {
                            GlobalVar.SetValueStr(element, i, PlayerPrefs.GetString(element + i, "0"));
                        }
                        break;
                }

            }

            GlobalVar.FirstsWorkingNow+=1;

            
        }
    }
    private void SaveData()
    {
        foreach (string element in GlobalVar.NameType.Keys)
        {
            string type = GlobalVar.NameType[element];
            switch (type)
            {
                case "Int":
                    PlayerPrefs.SetInt(element, GlobalVar.GetValueInt(element));
                    PlayerPrefs.Save();
                    break;

                case "Str":
                    PlayerPrefs.SetString(element, GlobalVar.GetValueStr(element));
                    PlayerPrefs.Save();
                    break;

                case "Int[]":
                    for (int i = 0; i < GlobalVar.SumAnimals; i++)
                    {
                        PlayerPrefs.SetInt(element+i, GlobalVar.GetValueInt(element,i));
                        PlayerPrefs.Save();
                    }
                    break;

                case "Str[]":
                    for (int i = 0; i < GlobalVar.SumAnimals; i++)
                    {
                        PlayerPrefs.SetString(element+i, GlobalVar.GetValueStr(element,i));
                        PlayerPrefs.Save();
                    }
                    break;
            }
        }
        long DTnow = System.DateTime.Now.Ticks / 10000000;
        PlayerPrefs.SetString("TimeLastExit", "" + DTnow);
        PlayerPrefs.Save();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveData();
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }
}
