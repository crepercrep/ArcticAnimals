using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyntCenterWindow : MonoBehaviour
{

    public GameObject Window;
    public GameObject Lamp_off;
    public Button ButtonTake;
    public Button ButtonSynt;

    public Image Lamp1;
    public Image Lamp2;
    public Image Lamp3;
    public Image Animal;
    public Image sld1img;
    public Image sld2img;
    public Image sld3img;

    public Slider Sld1;
    public Slider Sld2;
    public Slider Sld3;

    private int minCorrect1 = 0;
    private int maxCorrect1 = 0;
    private int minCorrect2 = 0;
    private int maxCorrect2 = 0;
    private int minCorrect3 = 0;
    private int maxCorrect3 = 0;
    private int AnimalNumb = 14;
    private int SynthesizingStage = 0;


    public void BtnSynthesize()
    {
        switch (SynthesizingStage)
        {
            case 0:
                if ((GlobalVar.Matter < GlobalVar.PriceSynthesizeMatter) || (GlobalVar.DNA < GlobalVar.PriceSynthesizeDNA)) return;

                GlobalVar.Matter -= GlobalVar.PriceSynthesizeMatter;
                GlobalVar.DNA -= GlobalVar.PriceSynthesizeDNA;

                Lamp_off.SetActive(false);
                Lamp1.enabled = true;
                Lamp2.enabled = true;
                Lamp3.enabled = true;
                Animal.enabled = true;
                AnimalNumb = Random.Range(0, 3);
                Animal.sprite = GlobalVar.SpriteAnimal[AnimalNumb];
                Animal.color = new Color32(255, 255, 255, 65);
                SynthesizingStage = 1;

                byte red = (byte)Random.Range(0, 256);
                byte green = (byte)Random.Range(0, 256);
                byte blue = (byte)Random.Range(0, 256);
                sld1img.color = new Color32(red,green,blue,255);
                red = (byte)Random.Range(0, 256);
                green = (byte)Random.Range(0, 256);
                blue = (byte)Random.Range(0, 256);
                sld2img.color = new Color32(red, green, blue, 255);
                red = (byte)Random.Range(0, 256);
                green = (byte)Random.Range(0, 256);
                blue = (byte)Random.Range(0, 256);
                sld3img.color = new Color32(red, green, blue, 255);

                minCorrect1 = Random.Range(0, 950);
                maxCorrect1 = minCorrect1 + 35;
                minCorrect2 = Random.Range(0, 950);
                maxCorrect2 = minCorrect2 + 35;
                minCorrect3 = Random.Range(0, 950);
                maxCorrect3 = minCorrect3 + 35;
                
                break;

            case 1:
                int numbCorr = Random.Range(0, 3);
                switch (numbCorr)
                {
                    case 0:
                        minCorrect2 = Random.Range(0, 950);
                        maxCorrect2 = minCorrect2 + 25;
                        minCorrect3 = Random.Range(0, 950);
                        maxCorrect3 = minCorrect3 + 25;
                        break;
                    case 1:
                        minCorrect1 = Random.Range(0, 950);
                        maxCorrect1 = minCorrect1 + 25;
                        minCorrect3 = Random.Range(0, 950);
                        maxCorrect3 = minCorrect3 + 25;
                        break;
                    case 2:
                        minCorrect1 = Random.Range(0, 950);
                        maxCorrect1 = minCorrect1 + 25;
                        minCorrect2 = Random.Range(0, 950);
                        maxCorrect2 = minCorrect2 + 25;
                        break;
                }
                SynthesizingStage = 2;
                Animal.color = new Color32(255, 255, 255, 135);
                break;

            case 2:
                int numbCorr1 = Random.Range(0, 3);
                switch (numbCorr1)
                {
                    case 0:
                        minCorrect1 = Random.Range(0, 950);
                        maxCorrect1 = minCorrect1 + 15;
                        break;
                    case 1:
                        minCorrect2 = Random.Range(0, 950);
                        maxCorrect2 = minCorrect2 + 15;
                        break;
                    case 2:
                        minCorrect3 = Random.Range(0, 950);
                        maxCorrect3 = minCorrect3 + 15;
                        break;
                }
                SynthesizingStage = 3;
                Animal.color = new Color32(255, 255, 255, 195);
                break;
                
            case 3:
                ButtonTake.interactable = true;
                Lamp_off.SetActive(true);
                Lamp1.enabled = false;
                Lamp2.enabled = false;
                Lamp3.enabled = false;
                Sld1.value = 0;
                Sld2.value = 0;
                Sld3.value = 0;
                Animal.color = new Color32(255, 255, 255, 235);
                break;
        }

        

    }
    public void BtnTake()
    {
        SynthesizingStage = 0;
        Animal.enabled = false;
        GlobalVar.PopulAnimal[AnimalNumb]++;
        ButtonTake.interactable = false;
        ButtonSynt.interactable = true;
    }


    void Update()
    {
        if (SynthesizingStage == 0) return;
        int Corrects = 0;
        if ((minCorrect1 < Sld1.value) && (Sld1.value < maxCorrect1))
        {
            Lamp1.color = new Color32(50, 255, 50, 255);
            Corrects++;
        }else Lamp1.color = new Color32(255, 50, 50, 255);

        if ((minCorrect2 < Sld2.value) && (Sld2.value < maxCorrect2))
        {
            Lamp2.color = new Color32(50, 255, 50, 255);
            Corrects++;
        }else Lamp2.color = new Color32(255, 50, 50, 255);

        if ((minCorrect3 < Sld3.value) && (Sld3.value < maxCorrect3))
        {
            Lamp3.color = new Color32(50, 255, 50, 255);
            Corrects++;
        }else Lamp3.color = new Color32(255, 50, 50, 255);


        if (Corrects > 2)
        {
            ButtonSynt.interactable = true;
        }
        else
        {
            ButtonSynt.interactable = false;
        }



    }
}
