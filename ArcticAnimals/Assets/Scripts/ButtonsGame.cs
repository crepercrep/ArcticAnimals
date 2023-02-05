using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsGame : MonoBehaviour
{

    public Slider AnimalNumSl;

    public Transform Windows;
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

    public void SetMatterSpeed(float val)
    {
        GlobalVar.QuarryChangeMatterSpeed(val);
    }
    public void QuarryGet(Text BtnText)
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        int Value = int.Parse(BtnText.text);
        if (Value < 1) return;
        switch (BtnText.name)
        {
            case "TextGetDNA":
                GlobalVar.QuarryDNA = nowtime+(long)(GlobalVar.QuarryDNAMax/GlobalVar.QuarryDNASpeed);
                GlobalVar.DNA += Value;
                break;
            case "TextGetMatter":
                GlobalVar.QuarryMatter = nowtime + (long)(GlobalVar.QuarryMatterMax / GlobalVar.QuarryMatterSpeed);
                GlobalVar.Matter += Value;
                break;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void plusdna()
    {
        GlobalVar.DNA += Random.Range(1,11);
        GlobalVar.Matter += Random.Range(1, 11);
    }
    public void pluspopul()
    {
        
        GlobalVar.PopulAnimal[(int)AnimalNumSl.value] += 1;
        
    }
    public void minuspopul()
    {
        GlobalVar.PopulAnimal[(int)AnimalNumSl.value] -= 1;
        if (GlobalVar.PopulAnimal[(int)AnimalNumSl.value] < 0) GlobalVar.PopulAnimal[(int)AnimalNumSl.value] = 0;
    }

}
