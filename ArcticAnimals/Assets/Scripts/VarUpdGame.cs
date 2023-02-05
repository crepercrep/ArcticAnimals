using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarUpdGame : MonoBehaviour
{
    public Text DNA;
    public Text Matter;
    public Text GetDNA;
    public Text GetMatter;
    public Text DNAPerHour;
    public Text MatterPerHour;
    public Text DNAMax;
    public Text MatterMax;
    public Text ForfeitDNAFood;
    public Text ForfeitMatterFood;
    public Text ForfeitDNACollapse;
    public Text ForfeitMatterCollapse;
    public Text CollapseCD;

    public Text SliderText;

    public GameObject MinePrice;
    public GameObject MineBtnEnter;
    public GameObject ManualWind;

    private void Start()
    {
        if (GlobalVar.FirstPlay)
        {
            Camera.BlockCamera();
            ManualWind.SetActive(true);
            GlobalVar.PopulAnimal[0] += 1;
            GlobalVar.PopulAnimal[3] += 1;
            GlobalVar.FirstPlay = false;
        }
    }
    public void SliderChange(Slider Slider)
    {
        SliderText.text = "" + Slider.value;
    }
    void Update()
    {

        DNA.text = "" + GlobalVar.DNA;
        Matter.text = "" + GlobalVar.Matter;
        //DNAPerHour.text = ((GlobalVar.QuarryDNASpeed-(GlobalVar.QuarryForfeitDNAFood+GlobalVar.QuarryForfeitDNACollapse)) * 360) + "/h";
        //MatterPerHour.text = ((GlobalVar.QuarryMatterSpeed-(GlobalVar.QuarryForfeitMatterFood+GlobalVar.QuarryForfeitMatterCollapse)) * 360) + "/h";
        DNAPerHour.text = (GlobalVar.QuarryDNASpeed * 3600) + "/h";
        MatterPerHour.text = (GlobalVar.QuarryMatterSpeed * 3600) + "/h";
        DNAMax.text = "/" + GlobalVar.QuarryDNAMax;
        MatterMax.text = "/" + GlobalVar.QuarryMatterMax;
        ForfeitDNAFood.text = "-" + (GlobalVar.QuarryForfeitDNAFood*3600) + "/h";
        ForfeitMatterFood.text = "-" + (GlobalVar.QuarryForfeitMatterFood * 3600) + "/h";
        ForfeitDNACollapse.text = "-" + (GlobalVar.QuarryForfeitDNACollapse * 3600) + "/h";
        ForfeitMatterCollapse.text = "-" + (GlobalVar.QuarryForfeitMatterCollapse * 3600) + "/h";

        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        
        int dna = GlobalVar.QuarryDNAMax-(int)(((GlobalVar.QuarryDNA - nowtime)*GlobalVar.QuarryDNASpeed) + 0.9f);
        int matter = GlobalVar.QuarryMatterMax-(int)(((GlobalVar.QuarryMatter - nowtime) * GlobalVar.QuarryMatterSpeed) + 0.9f);
        if (dna > GlobalVar.QuarryDNAMax) dna = GlobalVar.QuarryDNAMax;
        if (matter > GlobalVar.QuarryMatterMax) matter = GlobalVar.QuarryMatterMax;
        if (dna < 1) dna = 0;
        if (matter < 1) matter = 0;
        /*long dna = 49-((GlobalVar.QuarryDNA - nowtime) / (432*4));
        long matter = 49-((GlobalVar.QuarryMatter - nowtime) / (432*2));
        if (dna > 49) dna = 50;
        if (matter > 49) matter = 50;
        if (dna < 1) dna = 0;
        if (matter < 1) matter = 0;*/
        GetDNA.text = ""+dna;
        GetMatter.text = "" + matter;

        long collapsecd = (GlobalVar.QuarryCollapseCD - nowtime);
        long min = 0;
        long sec = 0;
        if (collapsecd > 0)
        {
            min = collapsecd / 60;
            sec = collapsecd % 60;
            CollapseCD.text = string.Format("{0:00}:{1:00}", min, sec);
            MinePrice.SetActive(false);
        }
        else
        {
            if (MineBtnEnter.active)
            {
                CollapseCD.text = "";
                MinePrice.SetActive(true);
            }else MinePrice.SetActive(false);

        }



    }
}
