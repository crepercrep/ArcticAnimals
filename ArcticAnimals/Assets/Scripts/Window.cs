using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public bool IsMinerals = false;
    public Text Button;
    public Text DrpdLeft;
    public Text DrpdMid;
    public Text DrpdRight;


    void Awake()
    {
    }
    public void BtnApply(GameObject Window)
    {
        string val = DrpdLeft.text + "-" + DrpdMid.text + "-" + DrpdRight.text;
        if (IsMinerals) GlobalVar.MineralsAnimal[GlobalVar.AnimalNumber] = val;
        else GlobalVar.OxygenAnimal[GlobalVar.AnimalNumber] = val;
        Button.text = val;
        Window.SetActive(false);
    }

}
