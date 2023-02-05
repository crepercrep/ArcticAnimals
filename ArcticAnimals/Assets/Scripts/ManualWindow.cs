using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualWindow : MonoBehaviour
{
    public Transform WindContent;
    public Transform WindManual;
    public Font font;
    public Text TextManual;
    public Sprite BtnBack;

    private string[] TextDoc;
    private string[] ManualText = new string[11];
    private GameObject[] ManualBtns = new GameObject[11];
    private int PosY = -50;

    void Awake()
    {
        for (int i = 0; i < 11; i++)
        {
            if (GlobalVar.ManualText[i] != null)
            {
                switch (GlobalVar.Language)
                {
                    case "Ru":
                        TextDoc = GlobalVar.ManualTextRU[i].text.Split('\n');
                        break;
                    case "En":
                        TextDoc = GlobalVar.ManualText[i].text.Split('\n');
                        break;
                    default:
                        TextDoc = GlobalVar.ManualText[i].text.Split('\n');
                        break;
                }

            }
            else
            {
                TextDoc = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            }
            for (int j = 1; j < TextDoc.Length; j++)
            {
                ManualText[i] += TextDoc[j] + "\n";
            }

            CreateManualButton(i);
        }
        SetManualText(0);   
    }

    private void OnEnable()
    {
        for (int i = 0; i < 11; i++)
        {
            if (GlobalVar.OpenManual[i] > 0)
            {
                ManualBtns[i].GetComponent<Button>().enabled = true;
                ManualBtns[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                ManualBtns[i].GetComponent<Button>().enabled = false;
                ManualBtns[i].GetComponent<Image>().color = new Color32(195, 195, 195, 255);
            }
        }
    }
    private void CreateManualButton(int ButtonNumber)
    {

        GameObject A1 = new GameObject("BTNManual" + ButtonNumber, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        A1.transform.SetParent(WindContent);
        A1.layer = 5;
        RectTransform btnRT = A1.GetComponent<RectTransform>();
        btnRT.localPosition = new Vector3(0, PosY, 0);
        btnRT.anchoredPosition = new Vector3(0, PosY, 0);
        btnRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        btnRT.sizeDelta = new Vector2(1000, 200);
        btnRT.anchorMin = new Vector2(0.5f, 1f);
        btnRT.anchorMax = new Vector2(0.5f, 1f);
        Image btnI = A1.GetComponent<Image>();
        btnI.sprite = BtnBack;
        A1.GetComponent<Button>().onClick.AddListener(() => SetManualText(ButtonNumber));

        GameObject A1Text = new GameObject("BtnText" + ButtonNumber, typeof(Text));
        A1Text.transform.SetParent(A1.transform);
        A1Text.layer = 5;
        A1Text.GetComponent<Text>().text = TextDoc[0];
        A1Text.GetComponent<Text>().font = font;
        A1Text.GetComponent<Text>().fontSize = 95;
        RectTransform TextRT = A1Text.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(0, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(1000, 200);
        A1Text.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        A1Text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        ManualBtns[ButtonNumber] = A1;
        PosY -= 100;
    }

    void SetManualText(int ButtonNumber)
    {
        TextManual.text = ManualText[ButtonNumber];
    }

}
