using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceOnButtons : MonoBehaviour
{
    public string PriceName;
    private Text TxtPrice;
    private void Start()
    {
        TxtPrice = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        
        switch (PriceName)
        {
            case "Mine":
                TxtPrice.text = "-" + GlobalVar.PriceMineMatter;
                break;
            case "SyntDNA":
                TxtPrice.text = "-" + GlobalVar.PriceSynthesizeDNA;
                break;
            case "SyntMatter":
                TxtPrice.text = "-" + GlobalVar.PriceSynthesizeMatter;
                break;
            case "Feed":
                TxtPrice.text = "-" + GlobalVar.PriceFeedMatter;
                break;
            default:
                TxtPrice.text = "???";
                break;
        }
    }
}
