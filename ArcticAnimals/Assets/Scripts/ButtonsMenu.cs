using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsMenu : MonoBehaviour
{
    public Slider SliderAnimalLimit;
    private void Start()
    {
        SliderAnimalLimit.value = GlobalVar.AnimalLimit;
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
    

    public void AnimalLimit(Slider Slider)
    {
        GlobalVar.AnimalLimit = (int)Slider.value;
        Text txtAnimalLimit = Slider.GetComponentInChildren<Text>();
        txtAnimalLimit.text = ""+ Slider.value;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void CopySave(InputField Inp)
    {
        if (!(Inp.text.Equals(GlobalVar.TextUse["CopiedTC"])))
        {
            GUIUtility.systemCopyBuffer = Inp.text;
            Inp.text = GlobalVar.TextUse["CopiedTC"];
        }
    }


    public void TakeSave(InputField Inp)
    {
        string textfield = "";
        if (!PlayerPrefs.HasKey("DNA"))
        {
            textfield = "No Data Found!";
        }
        else
        {
            /*PlayerPrefs.DeleteAll();
            Inp.text = "DELET";
            return; */
            foreach (string element in GlobalVar.NameType.Keys)
            {
                string type = GlobalVar.NameType[element];
                switch (type)
                {
                    case "Int":
                        textfield += GlobalVar.GetValueInt(element) + "&";
                        break;

                    case "Str":
                        textfield += GlobalVar.GetValueStr(element) + "&";
                        break;

                    case "Int[]":
                        for (int i = 0; i < GlobalVar.SumAnimals; i++)
                        {
                            textfield += GlobalVar.GetValueInt(element,i) + "%";
                        }
                        textfield += "&";
                        break;

                    case "Str[]":
                        for (int i = 0; i < GlobalVar.SumAnimals; i++)
                        {
                            textfield += GlobalVar.GetValueStr(element, i) + "%";
                        }
                        textfield += "&";
                        break;
                }
            }
        }
        Inp.text = textfield;
    }

    public void LoadSave(InputField Inp)
    {
        try
        {
            string[] Saves = Inp.text.Split('&');
            int SaveNumb = -1;
            foreach (string element in GlobalVar.NameType.Keys)
            {
                SaveNumb++;
                string type = GlobalVar.NameType[element];
                switch (type)
                {
                    case "Int":
                        GlobalVar.SetValueInt(element, int.Parse(Saves[SaveNumb]));
                        break;

                    case "Str":
                        GlobalVar.SetValueStr(element, Saves[SaveNumb]);
                        break;

                    case "Int[]":
                        string[] TempSave = Saves[SaveNumb].Split('%');
                        for (int i = 0; i < GlobalVar.SumAnimals; i++)
                        {
                            GlobalVar.SetValueInt(element, i, int.Parse(TempSave[i]));
                        }
                        break;

                    case "Str[]":
                        string[] TempSave1 = Saves[SaveNumb].Split('%');
                        for (int i = 0; i < GlobalVar.SumAnimals; i++)
                        {
                            GlobalVar.SetValueStr(element, i, TempSave1[i]);
                        }
                        break;
                }
            }
            Inp.text = "Success!";
        }
        catch
        {
            Inp.text = "ERROR!";
        }
        
    }

    public void Languages(string lang)
    {
        switch (lang)
        {
            case "English":
                GlobalVar.Language = "En";
                break;
            case "Russian":
                GlobalVar.Language = "Ru";
                break;
        }
        GlobalVar.SelectText();
    }


    public void GameExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }





}
