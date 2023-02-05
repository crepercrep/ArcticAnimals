using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DescriptionAnimals : MonoBehaviour
{
    public Transform WindContent;
    public Transform WindDescription;
    public Font font;
    public Sprite Border;
    public Text TextDescription;

    private string[] TextDoc;
    private string[] TextDesc = new string[GlobalVar.SumAnimals];
    private GameObject[] DescBtnsAnimals = new GameObject[GlobalVar.SumAnimals];
    private GameObject[] DescAnimals = new GameObject[GlobalVar.SumAnimals];
    private GameObject[] DescTextMaintenanceAnimals = new GameObject[GlobalVar.SumAnimals];
    

    private int PosY = 1050;



    void Awake()
    {
        
    
        for (int i = 0; i < GlobalVar.SumAnimals; i++)
        {
            if (GlobalVar.DescriptionAnimal[i] != null)
            {
                switch (GlobalVar.Language)
                {
                    case "Ru":
                        TextDoc = GlobalVar.DescriptionAnimalRU[i].text.Split('\n');
                        break;
                    case "En":
                        TextDoc = GlobalVar.DescriptionAnimal[i].text.Split('\n');
                        break;
                    default:
                        TextDoc = GlobalVar.DescriptionAnimal[i].text.Split('\n');
                        break;
                }

            }
            else
            {
                TextDoc = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            }
            for (int j = 4; j < TextDoc.Length; j++)
            {
                TextDesc[i] += TextDoc[j] + "\n";
            }
            //TextDesc[i] = TextDoc[4] + "\n" + TextDoc[5] + "\n" + TextDoc[6];
            
            CreateAnimalButton(i);
            CreateAnimalDescription(i);
            DescAnimals[i].SetActive(false);
        }
        //DescAnimals[GlobalVar.AnimalNumber].SetActive(true);
        SetDesc(GlobalVar.AnimalNumber);

    }
    private void OnEnable()
    {
        for (int i = 0; i < GlobalVar.SumAnimals; i++)
        {
            if (GlobalVar.PopulAnimal[i] > 0)
            {
                
                
                DescBtnsAnimals[i].GetComponentInChildren<Text>().enabled = false;
                DescBtnsAnimals[i].GetComponent<Image>().enabled = true;
                DescBtnsAnimals[i].GetComponent<Button>().enabled = true;
                if (GlobalVar.ResearchAnimal[i] > 0) DescTextMaintenanceAnimals[i].SetActive(true);
                else DescTextMaintenanceAnimals[i].SetActive(false);

            }
            else
            {
                DescBtnsAnimals[i].GetComponentInChildren<Text>().enabled = true;
                DescBtnsAnimals[i].GetComponent<Image>().enabled = false;
                DescBtnsAnimals[i].GetComponent<Button>().enabled = false;
            }
        }
    }

    private void CreateAnimalButton(int AnimalNum)
    {

        GameObject A1 = new GameObject("BTNAnimal" + AnimalNum, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        A1.transform.SetParent(WindContent);
        A1.layer = 5;
        RectTransform btnRT = A1.GetComponent<RectTransform>();
        btnRT.localPosition = new Vector3(75, PosY, 0);
        btnRT.anchoredPosition = new Vector3(75, PosY, 0);
        btnRT.localScale = new Vector3(1, 1, 1);
        btnRT.sizeDelta = new Vector2(150, 150);
        btnRT.anchorMin = new Vector2(0, (float)0.5);
        btnRT.anchorMax = new Vector2(0, (float)0.5);
        Image btnI = A1.GetComponent<Image>();
        btnI.sprite = GlobalVar.SpriteAnimal[AnimalNum];
        A1.GetComponent<Button>().onClick.AddListener(() => SetDesc(AnimalNum));

        GameObject A1Text = new GameObject("BtnText" + AnimalNum, typeof(Text));
        A1Text.transform.SetParent(A1.transform);
        A1Text.layer = 5;
        A1Text.GetComponent<Text>().text = "?";
        A1Text.GetComponent<Text>().font = font;
        A1Text.GetComponent<Text>().fontSize = 95;
        RectTransform TextRT = A1Text.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(0, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(150, 150);
        A1Text.GetComponent<Text>().color = new Color32(0, 195, 255, 255);
        A1Text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        GameObject A1Border = new GameObject("BtnBorder" + AnimalNum, typeof(Image));
        A1Border.transform.SetParent(A1.transform);
        A1Border.layer = 5;
        Image BorderImg = A1Border.GetComponent<Image>();
        BorderImg.sprite = Border;
        BorderImg.color = new Color32(0, 195, 255,255);
        RectTransform BorderRT = A1Border.GetComponent<RectTransform>();
        BorderRT.localPosition = new Vector3(0, 0, 0);
        BorderRT.localScale = new Vector3(1, 1, 1);
        BorderRT.sizeDelta = new Vector2(150, 150);

        DescBtnsAnimals[AnimalNum] = A1;
        PosY -= 150;
    }
    private void CreateAnimalDescription(int AnimalNum)
    {

        GameObject Desc = new GameObject("DescAnimal" + AnimalNum, typeof(RectTransform));
        Desc.transform.SetParent(WindDescription);
        Desc.layer = 5;
        RectTransform DescRT = Desc.GetComponent<RectTransform>();
        DescRT.localPosition = new Vector3(0, 0, 0);
        DescRT.anchoredPosition = new Vector3(0, 0, 0);
        DescRT.localScale = new Vector3(1, 1, 1);
        DescRT.sizeDelta = new Vector2(100, 100);
        DescRT.anchorMin = new Vector2((float)0.5, (float)0.5);
        DescRT.anchorMax = new Vector2((float)0.5, (float)0.5);

        
        

        GameObject DescImage = new GameObject("DescImage" + AnimalNum, typeof(Image));
        DescImage.transform.SetParent(Desc.transform);
        DescImage.layer = 5;
        Image DescImg = DescImage.GetComponent<Image>();
        DescImg.sprite = GlobalVar.ImageAnimal[AnimalNum];
        //DescImg.color = new Color(0, 0, 0);
        RectTransform DescImageRT = DescImage.GetComponent<RectTransform>();
        DescImageRT.localPosition = new Vector3(510, 140, 0);
        DescImageRT.localScale = new Vector3(1, 1, 1);
        DescImageRT.sizeDelta = new Vector2(600, 600);
        DescImageRT.anchorMin = new Vector2(1, (float)0.5);
        DescImageRT.anchorMax = new Vector2(1, (float)0.5);

        GameObject DescTextName = new GameObject("DescTextName" + AnimalNum, typeof(Text));
        DescTextName.transform.SetParent(Desc.transform);
        DescTextName.layer = 5;
        DescTextName.GetComponent<Text>().text = TextDoc[0];
        DescTextName.GetComponent<Text>().font = font;
        DescTextName.GetComponent<Text>().fontSize = 95;
        DescTextName.GetComponent<Text>().fontStyle = UnityEngine.FontStyle.Normal;
        RectTransform TextRT = DescTextName.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(510, -192, 0);
        TextRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        TextRT.sizeDelta = new Vector2(1200, 180);
        TextRT.GetComponent<Text>().color = new Color(255, 255, 255);
        TextRT.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        TextRT.anchorMin = new Vector2(1, (float)0.5);
        TextRT.anchorMax = new Vector2(1, (float)0.5);

        GameObject DescTextCSTitle = new GameObject("DescTextCSTitle" + AnimalNum, typeof(Text));
        DescTextCSTitle.transform.SetParent(Desc.transform);
        DescTextCSTitle.layer = 5;
        DescTextCSTitle.GetComponent<Text>().text = GlobalVar.TextUse["ConservationS"];
        DescTextCSTitle.GetComponent<Text>().font = font;
        DescTextCSTitle.GetComponent<Text>().fontSize = 95;
        DescTextCSTitle.GetComponent<Text>().fontStyle = UnityEngine.FontStyle.Bold;
        TextRT = DescTextCSTitle.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(510, -261, 0);
        TextRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        TextRT.sizeDelta = new Vector2(1200, 120);
        TextRT.GetComponent<Text>().color = new Color(255, 255, 255);
        TextRT.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        TextRT.anchorMin = new Vector2(1, (float)0.5);
        TextRT.anchorMax = new Vector2(1, (float)0.5);

        GameObject DescTextCSAnimal = new GameObject("DescTextCSAnimal" + AnimalNum, typeof(Text));
        DescTextCSAnimal.transform.SetParent(Desc.transform);
        DescTextCSAnimal.layer = 5;
        DescTextCSAnimal.GetComponent<Text>().text = TextDoc[1];
        DescTextCSAnimal.GetComponent<Text>().font = font;
        DescTextCSAnimal.GetComponent<Text>().fontSize = 95;
        DescTextCSAnimal.GetComponent<Text>().fontStyle = UnityEngine.FontStyle.Normal;
        TextRT = DescTextCSAnimal.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(510, -339, 0);
        TextRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        TextRT.sizeDelta = new Vector2(1200, 180);
        TextRT.GetComponent<Text>().color = new Color(255, 255, 255);
        TextRT.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        TextRT.anchorMin = new Vector2(1, (float)0.5);
        TextRT.anchorMax = new Vector2(1, (float)0.5);

        GameObject DescTextMaintenance = new GameObject("DescTextMaintenance" + AnimalNum, typeof(Text));
        DescTextMaintenance.transform.SetParent(Desc.transform);
        DescTextMaintenance.layer = 5;
        DescTextMaintenance.GetComponent<Text>().text = TextDoc[2]+"\n"+TextDoc[3];
        DescTextMaintenance.GetComponent<Text>().font = font;
        DescTextMaintenance.GetComponent<Text>().fontSize = 105;
        DescTextMaintenance.GetComponent<Text>().fontStyle = UnityEngine.FontStyle.Bold;
        TextRT = DescTextMaintenance.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(510, -440, 0);
        TextRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        TextRT.sizeDelta = new Vector2(1200, 220);
        TextRT.GetComponent<Text>().color = new Color(255, 255, 255);
        TextRT.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        TextRT.anchorMin = new Vector2(1, (float)0.5);
        TextRT.anchorMax = new Vector2(1, (float)0.5);

        /*GameObject DescText = new GameObject("DescText" + AnimalNum, typeof(Text));
        DescText.transform.SetParent(Desc.transform);
        DescText.layer = 5;
        DescText.GetComponent<Text>().text = TextDoc[4] + "\n" + TextDoc[5] + "\n" + TextDoc[6];
        DescText.GetComponent<Text>().font = font;
        DescText.GetComponent<Text>().fontSize = 45;
        DescText.GetComponent<Text>().fontStyle = UnityEngine.FontStyle.Normal;
        TextRT = DescText.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(-230, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(850, 850);
        TextRT.GetComponent<Text>().color = new Color(255, 255, 255);
        TextRT.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
        TextRT.anchorMin = new Vector2(1, (float)0.5);
        TextRT.anchorMax = new Vector2(1, (float)0.5);*/

        DescTextMaintenanceAnimals[AnimalNum] = DescTextMaintenance;
        DescAnimals[AnimalNum] = Desc;
    }
    void ClearDesc()
    {
        for (int i = 0; i < GlobalVar.SumAnimals; i++)
        {
            DescAnimals[i].SetActive(false);
        }
    }
    void SetDesc(int DescNumber)
    {
        ClearDesc();
        DescAnimals[DescNumber].SetActive(true);
        TextDescription.text = TextDesc[DescNumber];
    }


}
