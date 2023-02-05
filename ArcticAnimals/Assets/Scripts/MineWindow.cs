using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineWindow : MonoBehaviour
{
    private static int LengthButtons = 9;
    private static int HeightButtons = 4;

    private static int SumButton = LengthButtons*HeightButtons+1;

    public Transform Mine;
    public Sprite ButtonImage;
    public Font font;
    public Button BtnStartMine;
    public Text TxtDNA;
    public Text TxtMatter;


    public List<int> TempBtnsIds;
    public List<int> BtnsIds;

    private bool IsCollapse = false;

    private int DNAReward = 0;
    private int MatterReward = 0;

    private float AddRisk = 0.5f;
    private float PosX = 100;
    private float PosY = 300;
    private float time = 0;

    

    private int[] BtnMineDNA = new int[SumButton];
    private int[] BtnMineMatter = new int[SumButton];
    private float[] BtnMineRisk = new float[SumButton];

    private Text[] TextBtnReward = new Text[SumButton];
    private Text[] TextBtnRisk = new Text[SumButton];
    private GameObject[] BtnsMine = new GameObject[SumButton];

    
    void Awake()
    {
        for (int id = 1; id < SumButton; id++)
        {
            BtnsIds.Add(id);
        }
        int BtnId = 1;
        for (int i = 0; i < HeightButtons; i++)
        {
            for (int j = 0; j < LengthButtons; j++)
            {
                
                CreateMineButton(BtnId);
                BtnId++;
                PosX += 200;
            }
            PosX = 100;
            PosY -= 200;
        }
    }

    private void CreateMineButton(int ButtonId)
    {
        GameObject A1 = new GameObject("BtnMine" + ButtonId, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        A1.transform.SetParent(Mine);
        A1.layer = 5;
        RectTransform btnRT = A1.GetComponent<RectTransform>();
        btnRT.localPosition = new Vector3(PosX, PosY, 0);
        btnRT.anchoredPosition = new Vector3(PosX, PosY, 0);
        btnRT.localScale = new Vector3(1, 1, 1);
        btnRT.sizeDelta = new Vector2(200, 200);
        btnRT.anchorMin = new Vector2(0, (float)0.5);
        btnRT.anchorMax = new Vector2(0, (float)0.5);
        Image btnI = A1.GetComponent<Image>();
        btnI.sprite = ButtonImage;
        A1.GetComponent<Button>().onClick.AddListener(() => CheckCollapse(ButtonId));

        GameObject A1Text = new GameObject("TxtMineReward" + ButtonId, typeof(Text));
        A1Text.transform.SetParent(A1.transform);
        A1Text.layer = 5;
        A1Text.GetComponent<Text>().text = "|d-|m-|";
        A1Text.GetComponent<Text>().font = font;
        A1Text.GetComponent<Text>().fontSize = 45;
        RectTransform TextRT = A1Text.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(0, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(200, 150);
        A1Text.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        A1Text.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
        
        GameObject A1Text1 = new GameObject("TxtMineRisk" + ButtonId, typeof(Text));
        A1Text1.transform.SetParent(A1.transform);
        A1Text1.layer = 5;
        A1Text1.GetComponent<Text>().text = "|!-!|";
        A1Text1.GetComponent<Text>().fontStyle = FontStyle.Bold;
        A1Text1.GetComponent<Text>().font = font;
        A1Text1.GetComponent<Text>().fontSize = 45;
        RectTransform TextRT1 = A1Text1.GetComponent<RectTransform>();
        TextRT1.localPosition = new Vector3(0, 0, 0);
        TextRT1.localScale = new Vector3(1, 1, 1);
        TextRT1.sizeDelta = new Vector2(200, 125);
        A1Text1.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        A1Text1.GetComponent<Text>().alignment = TextAnchor.LowerCenter;

        BtnsMine[ButtonId] = A1;
        TextBtnReward[ButtonId] = A1Text.GetComponent<Text>();
        TextBtnRisk[ButtonId] = A1Text1.GetComponent<Text>();

        A1.SetActive(false);
        A1Text.GetComponent<Text>().enabled = false;
        A1Text1.GetComponent<Text>().enabled = false;
    }
    private void CheckCollapse(int BtnId)
    {
        if (!TextBtnReward[BtnId].isActiveAndEnabled) return;
        float CheckCollapse = Random.Range(0f, 100f);
        if (BtnMineRisk[BtnId]< CheckCollapse)
        {
            CollapseFalse(BtnId);
        }
        else
        {
            CollapseTrue(BtnId);
        }
    }

    
    private void CollapseFalse(int btnid)
    {
        DNAReward += BtnMineDNA[btnid];
        MatterReward += BtnMineMatter[btnid];
        TxtDNA.text =""+ DNAReward;
        TxtMatter.text = "" + MatterReward;
        BtnsMine[btnid].SetActive(false);
        RiskAdd();

        int[] CloseBtnsId = new int[] { btnid - 1, btnid + 1, btnid - LengthButtons, btnid + LengthButtons };
        for (int i = 0; i < 4; i++)
        {
            bool IsReal = true;
            int ClsId = CloseBtnsId[i];
            switch (i)
            {
                case 0:
                    if ((ClsId % 9) == 0) IsReal = false;
                    break;
                case 1:
                    if ((ClsId % 9) == 1) IsReal = false;
                    break;
                case 2:
                    if (ClsId <= 0) IsReal = false;
                    break;
                case 3:
                    if (ClsId >= SumButton) IsReal = false;
                    break;
            }
            if (IsReal)
            {
                TextBtnReward[ClsId].enabled = true;
                TextBtnRisk[ClsId].enabled = true;
            }
        }
    }

    private void RiskAdd()
    {
        for (int id = 1; id < SumButton; id++)
        {
            BtnMineRisk[id] += AddRisk;
            TextBtnRisk[id].text = "|" + BtnMineRisk[id].ToString("0.0") + "%" + "|";
        }
    }

    private void CollapseTrue(int btnid)
    {
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        GlobalVar.QuarryCollapseCD = nowtime+300;

        if (!(GlobalVar.QuarryForfeitDNACollapse > 0))
        {
            float DNAPart = GlobalVar.QuarryDNASpeed / 10;
            float MatterPart = GlobalVar.QuarryMatterSpeed / 10;
            GlobalVar.QuarryForfeitDNACollapse = Random.Range(DNAPart , DNAPart * 3);
            GlobalVar.QuarryForfeitMatterCollapse = Random.Range(MatterPart , MatterPart * 3);
            float dnaspeed = GlobalVar.QuarryDNASpeed - GlobalVar.QuarryForfeitDNACollapse;
            float matterspeed = GlobalVar.QuarryMatterSpeed - GlobalVar.QuarryForfeitMatterCollapse;
            GlobalVar.QuarryChangeDNASpeed(dnaspeed);
            GlobalVar.QuarryChangeMatterSpeed(matterspeed);
        }


        TempBtnsIds.AddRange(BtnsIds.ToArray());
        DNAReward = 0;
        MatterReward = 0;
        for (int id = 1; id < SumButton; id++)
        {
            BtnsMine[id].GetComponent<Button>().interactable = false;
        }
        IsCollapse = true;
        TextBtnReward[btnid].text = GlobalVar.TextUse["Collapse"];
        TextBtnRisk[btnid].text = GlobalVar.TextUse["ERROR"];
    }

    public void StartMine()
    {
        if (GlobalVar.Matter < GlobalVar.PriceMineMatter) return;
        long nowtime = ((System.DateTime.Now.Ticks / 10000000));
        if (GlobalVar.QuarryCollapseCD > nowtime) return;
        GlobalVar.Matter -= GlobalVar.PriceMineMatter;
        BtnStartMine.gameObject.SetActive(false);
        
        for (int id = 1; id < SumButton; id++)
        {
            BtnsMine[id].SetActive(true);
            BtnsMine[id].GetComponent<Button>().interactable = true;
            TextBtnReward[id].enabled = false;
            TextBtnRisk[id].enabled = false;

            BtnMineDNA[id] = Random.Range(0, 6);
            BtnMineMatter[id] = Random.Range(3, 15);
            BtnMineRisk[id] = Random.Range(0.2f, 2.4f)+ AddRisk;

            TextBtnReward[id].text = "|"+BtnMineDNA[id] + "|"+ BtnMineMatter[id]+ "|";
            TextBtnRisk[id].text = "|"+BtnMineRisk[id].ToString("0.0")+"%"+ "|";

        }
        int start = Random.Range(1, 37);
        TextBtnReward[start].enabled = true;
        BtnMineDNA[start] = 0;
        BtnMineMatter[start] = 0;
        BtnMineRisk[start] = -0.1f;
        CheckCollapse(start);
    }
    public void StopMine()
    {
        if ((GlobalVar.QuarryForfeitDNACollapse > 0))
        {
            if (MatterReward > 35)
            {
                float dnaspeed = GlobalVar.QuarryDNASpeed + GlobalVar.QuarryForfeitDNACollapse;
                float matterspeed = GlobalVar.QuarryMatterSpeed + GlobalVar.QuarryForfeitMatterCollapse;
                GlobalVar.QuarryChangeDNASpeed(dnaspeed);
                GlobalVar.QuarryChangeMatterSpeed(matterspeed);
                GlobalVar.QuarryForfeitDNACollapse = 0;
                GlobalVar.QuarryForfeitMatterCollapse = 0;
            }
        }
        IsCollapse = false;
        BtnStartMine.gameObject.SetActive(true);
        TxtDNA.text = "0";
        TxtMatter.text = "0";
        GlobalVar.DNA += DNAReward;
        GlobalVar.Matter += MatterReward;
        DNAReward = 0;
        MatterReward = 0;
        for (int id = 1; id < SumButton; id++)
        {
            BtnsMine[id].SetActive(false);
        }
    }

    private void Update()
    {
        if (IsCollapse)
        {
            if (time < Time.time)
            {
                int IsCollapseId = TempBtnsIds[Random.Range(0,TempBtnsIds.Count)];
                TempBtnsIds.Remove(IsCollapseId);
                TextBtnReward[IsCollapseId].enabled = true;
                TextBtnRisk[IsCollapseId].enabled = true;
                TextBtnReward[IsCollapseId].text = GlobalVar.TextUse["Collapse"];
                TextBtnRisk[IsCollapseId].text = GlobalVar.TextUse["ERROR"];
                IsCollapseId++;
                time = Time.time + 0.07f;
            }
            if (TempBtnsIds.Count<1)
            {
                IsCollapse = false;
            }
        }
    }
}
