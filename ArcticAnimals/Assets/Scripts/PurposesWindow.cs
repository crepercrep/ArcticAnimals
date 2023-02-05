using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurposesWindow : MonoBehaviour
{
    public Transform WindContent;
    public Font font;
    public Sprite ButtonSprite;

    List<Button> PurposeBtns = new List<Button>();
    List<Text> PurposeTexts = new List<Text>();

    private int PurposeId = 0;

    private void Awake()
    {
        CreatePurpose(PurposeId,GlobalVar.TextUse["Purpose0"], GlobalVar.TextUse["DNA:"]+"100");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose1"], GlobalVar.TextUse["DNA:"] + "250");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose2"], GlobalVar.TextUse["DNA:"] + "500");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose3"], GlobalVar.TextUse["DNA:"] + "1000");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose4"], GlobalVar.TextUse["DNA:"] + "5000");

        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose5"], GlobalVar.TextUse["Matter:"] + "200");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose6"], GlobalVar.TextUse["Matter:"] + "500");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose7"], GlobalVar.TextUse["Matter:"] + "1000");

        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose8"], GlobalVar.TextUse["Matter:"] + "200");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose9"], GlobalVar.TextUse["Matter:"] + "500");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose10"], GlobalVar.TextUse["Matter:"] + "1000");

        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose11"], GlobalVar.TextUse["Matter:"] + "200");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose12"], GlobalVar.TextUse["Matter:"] + "500");
        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose13"], GlobalVar.TextUse["Matter:"] + "1000");

        CreatePurpose(PurposeId, GlobalVar.TextUse["Purpose14"], "?%#"+ GlobalVar.TextUse["ERROR"] + "?%#");

        int StateLength = GlobalVar.PurposesState.Length;
        if(StateLength < PurposeId)
        {
            int difference = PurposeId - StateLength;
            for (int i = 0; i < difference; i++) GlobalVar.PurposesState += "0";
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < GlobalVar.PurposesState.Length; i++)
        {
            if(GlobalVar.PurposesState[i] == '1')
            {
                PurposeBtns[i].GetComponent<Image>().color = new Color32(75, 155, 125, 255);
                PurposeBtns[i].GetComponentInChildren<Text>().text =GlobalVar.TextUse["Received"] + "\n";
                PurposeTexts[i].color = new Color32(195, 195, 195, 255);
            }
            else
            {
                if (PurposeCheck(i))
                {
                    PurposeBtns[i].interactable = true;
                }
            }
        }
    }
    private void CreatePurpose(int ID,string Text,string RewardText)
    {
        GameObject PurposeText = new GameObject("PurposeText" + PurposeId, typeof(Text));
        PurposeText.transform.SetParent(WindContent);
        PurposeText.layer = 5;
        Text PurposeTextText = PurposeText.GetComponent<Text>();
        PurposeTextText.text = "\n" + Text +"\n";
        PurposeTextText.font = font;
        PurposeTextText.fontSize = 115;
        PurposeTextText.color = new Color(255, 255, 255);
        PurposeTextText.alignment = TextAnchor.MiddleLeft;
        PurposeTextText.fontStyle = UnityEngine.FontStyle.Normal;
        RectTransform PurposeTextRT = PurposeText.GetComponent<RectTransform>();
        PurposeTextRT.localPosition = new Vector3(0, 0, 0);
        PurposeTextRT.localScale = new Vector3(1, 1, 1);
        PurposeTextRT.sizeDelta = new Vector2(2500, 300);
        PurposeTextRT.anchorMin = new Vector2(1, (float)0.5);
        PurposeTextRT.anchorMax = new Vector2(1, (float)0.5);

        PurposeTexts.Add(PurposeTextText);

        GameObject PurposeBtn = new GameObject("PurposeButton" + PurposeId, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        PurposeBtn.transform.SetParent(PurposeText.transform);
        PurposeBtn.layer = 5;
        Image PurposeBtnImage = PurposeBtn.GetComponent<Image>();
        PurposeBtnImage.sprite = ButtonSprite;
        PurposeBtnImage.color = new Color32(75, 255, 125, 255);
        PurposeBtn.GetComponent<Button>().onClick.AddListener(() => PurposeGet(ID));
        PurposeBtn.GetComponent<Button>().interactable = false;
        RectTransform PurposeBtnRT = PurposeBtn.GetComponent<RectTransform>();
        PurposeBtnRT.localPosition = new Vector3(-600, 0, 0);
        PurposeBtnRT.anchoredPosition = new Vector3(-600, 0, 0);
        PurposeBtnRT.localScale = new Vector3(1, 1, 1);
        PurposeBtnRT.sizeDelta = new Vector2(1000, 300);
        PurposeBtnRT.anchorMin = new Vector2(0, 0.5f);
        PurposeBtnRT.anchorMax = new Vector2(0, 0.5f);

        GameObject PurposeBtnText = new GameObject("PurposeButtonText" + PurposeId, typeof(Text));
        PurposeBtnText.transform.SetParent(PurposeBtn.transform);
        PurposeBtnText.layer = 5;
        Text PurposeBtnTextText = PurposeBtnText.GetComponent<Text>();
        PurposeBtnTextText.text = GlobalVar.TextUse["Get"]+"\n";
        PurposeBtnTextText.font = font;
        PurposeBtnTextText.fontSize = 95;
        PurposeBtnTextText.color = new Color32(255, 255, 255, 255);
        PurposeBtnTextText.alignment = TextAnchor.MiddleCenter;
        PurposeBtnTextText.fontStyle = UnityEngine.FontStyle.Bold;
        RectTransform PurposeBtnTextRT = PurposeBtnText.GetComponent<RectTransform>();
        PurposeBtnTextRT.localPosition = new Vector3(0, 0, 0);
        PurposeBtnTextRT.localScale = new Vector3(1, 1, 1);
        PurposeBtnTextRT.sizeDelta = new Vector2(1000, 300);
        

        GameObject PurposeBtnText1 = new GameObject("PurposeButtonTextReward" + PurposeId, typeof(Text));
        PurposeBtnText1.transform.SetParent(PurposeBtn.transform);
        PurposeBtnText1.layer = 5;
        Text PurposeBtnTextText1 = PurposeBtnText1.GetComponent<Text>();
        PurposeBtnTextText1.text = "\n" + RewardText;
        PurposeBtnTextText1.font = font;
        PurposeBtnTextText1.fontSize = 85;
        PurposeBtnTextText1.color = new Color32(255, 255, 255, 255);
        PurposeBtnTextText1.alignment = TextAnchor.MiddleCenter;
        PurposeBtnTextText1.fontStyle = UnityEngine.FontStyle.Normal;
        RectTransform PurposeBtnTextRT1 = PurposeBtnText1.GetComponent<RectTransform>();
        PurposeBtnTextRT1.localPosition = new Vector3(0, 0, 0);
        PurposeBtnTextRT1.localScale = new Vector3(1, 1, 1);
        PurposeBtnTextRT1.sizeDelta = new Vector2(1000, 300);

        PurposeBtns.Add(PurposeBtn.GetComponent<Button>());



        PurposeId++;
    }
    private bool PurposeCheck(int PurposeID)
    {
        int AllPopulation = 0;
        for (int i = 0; i < GlobalVar.SumAnimals; i++) AllPopulation += GlobalVar.PopulAnimal[i];
        switch (PurposeID)
        {
            case 0:
                if (AllPopulation > 9) return true;
                return false;
            case 1:
                if (AllPopulation > 24) return true;
                return false;
            case 2:
                if (AllPopulation > 99) return true;
                return false;
            case 3:
                if (AllPopulation > 499) return true;
                return false;
            case 4:
                if (AllPopulation > 999) return true;
                return false;
            case 5:
                if (GlobalVar.PopulAnimal[0] > 24) return true;
                return false;
            case 6:
                if (GlobalVar.PopulAnimal[0] > 99) return true;
                return false;
            case 7:
                if (GlobalVar.PopulAnimal[0] > 249) return true;
                return false;
            case 8:
                if (GlobalVar.PopulAnimal[1] > 24) return true;
                return false;
            case 9:
                if (GlobalVar.PopulAnimal[1] > 99) return true;
                return false;
            case 10:
                if (GlobalVar.PopulAnimal[1] > 249) return true;
                return false;
            case 11:
                if (GlobalVar.PopulAnimal[2] > 24) return true;
                return false;
            case 12:
                if (GlobalVar.PopulAnimal[2] > 99) return true;
                return false;
            case 13:
                if (GlobalVar.PopulAnimal[2] > 249) return true;
                return false;
            case 14:
                bool HavePopul = true;
                for (int i = 0; i < 3; i++)
                {
                    if (GlobalVar.PopulAnimal[i] < 1) HavePopul = false;
                }
                if (HavePopul) return true;
                return false;
            default:
                return false;
        }
    }
    private void PurposeGet(int PurposeID)
    {
        switch (PurposeID)
        {
            case 0:
                GlobalVar.DNA += 100;
                PurposeChangeState(PurposeID, '1');
                break;
            case 1:
                GlobalVar.DNA += 250;
                GlobalVar.OpenManual[1] = 1;
                PurposeChangeState(PurposeID, '1');
                break;
            case 2:
                GlobalVar.DNA += 500;
                GlobalVar.OpenManual[2] = 1;
                PurposeChangeState(PurposeID, '1');
                break;
            case 3:
                GlobalVar.DNA += 1000;
                GlobalVar.OpenManual[3] = 1;
                PurposeChangeState(PurposeID, '1');
                break;
            case 4:
                GlobalVar.DNA += 5000;
                GlobalVar.OpenManual[4] = 1;
                PurposeChangeState(PurposeID, '1');
                break;
            case 5:
                GlobalVar.Matter += 200;
                PurposeChangeState(PurposeID, '1');
                break;
            case 6:
                GlobalVar.Matter += 500;
                PurposeChangeState(PurposeID, '1');
                break;
            case 7:
                GlobalVar.Matter += 1000;
                PurposeChangeState(PurposeID, '1');
                break;
            case 8:
                GlobalVar.Matter += 200;
                PurposeChangeState(PurposeID, '1');
                break;
            case 9:
                GlobalVar.Matter += 500;
                PurposeChangeState(PurposeID, '1');
                break;
            case 10:
                GlobalVar.Matter += 1000;
                PurposeChangeState(PurposeID, '1');
                break;
            case 11:
                GlobalVar.Matter += 200;
                PurposeChangeState(PurposeID, '1');
                break;
            case 12:
                GlobalVar.Matter += 500;
                PurposeChangeState(PurposeID, '1');
                break;
            case 13:
                GlobalVar.Matter += 1000;
                PurposeChangeState(PurposeID, '1');
                break;
            case 14:
                GlobalVar.DNA += 1;
                GlobalVar.Matter += 1;
                GlobalVar.PopulAnimal[14] += 1;
                GlobalVar.OpenManual[10] = 1;
                PurposeChangeState(PurposeID, '1');
                break;
        }
    }
    private void PurposeChangeState(int PurposeID,char Value)
    {
        char[] States = GlobalVar.PurposesState.ToCharArray();
        States[PurposeID] = Value;
        GlobalVar.PurposesState = new string(States);
        PurposeBtns[PurposeID].interactable = false;
        PurposeBtns[PurposeID].GetComponent<Image>().color = new Color32(75, 155, 125, 255);
        PurposeBtns[PurposeID].GetComponentInChildren<Text>().text = GlobalVar.TextUse["Received"]+ "\n";
        PurposeTexts[PurposeID].color = new Color32(195, 195, 195, 255);

    }
}
