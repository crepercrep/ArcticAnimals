using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResearchWindow : MonoBehaviour
{
    private static int QuestionsSum = 15;


    public Transform WindContent;
    public Transform WindResearch;
    public Font font;
    public Sprite BtnImage;

    private Button CheckBtn;

    private string[] TextDoc;
    private GameObject[] Questions = new GameObject[QuestionsSum];
    private Image[] QuestionsBtns = new Image[QuestionsSum];
    private Image[] AnswerBtns0 = new Image[QuestionsSum];
    private Image[] AnswerBtns1 = new Image[QuestionsSum];
    private Image[] AnswerBtns2 = new Image[QuestionsSum];
    private bool[] QuestionHaveAnswer = new bool[QuestionsSum];
    private bool[] AnswersCorrect = new bool[QuestionsSum];

    private int QuestionNowOpen = 0;
    private int PosY = 1050;

    private void Awake()
    {
        if (GlobalVar.ResearchQuestionsAnimal[GlobalVar.AnimalNumber] != null)
        {
            switch (GlobalVar.Language)
            {
                case "Ru":
                    TextDoc = GlobalVar.ResearchQuestionsAnimalRU[GlobalVar.AnimalNumber].text.Split('\n');
                    break;
                case "En":
                    TextDoc = GlobalVar.ResearchQuestionsAnimal[GlobalVar.AnimalNumber].text.Split('\n');
                    break;
                default:
                    TextDoc = GlobalVar.ResearchQuestionsAnimal[GlobalVar.AnimalNumber].text.Split('\n');
                    break;
            }

        }
        else
        {
            TextDoc = GlobalVar.ResearchQuestionsAnimal[0].text.Split('\n');
        }
        for (int i = 0; i < QuestionsSum; i++)
        {
            

            CreateQuestionButton(i);
            CreateQuestion(i);
            Questions[i].SetActive(false);
        }
        CreateImageAndButton();
        OpenQuestion(0);

    }
    
    private void CreateImageAndButton()
    {
        GameObject DescImage = new GameObject("QuestionImage", typeof(Image));
        DescImage.transform.SetParent(WindResearch);
        DescImage.layer = 5;
        Image DescImg = DescImage.GetComponent<Image>();
        DescImg.sprite = GlobalVar.ImageAnimal[GlobalVar.AnimalNumber];
        //DescImg.color = new Color(0, 0, 0);
        RectTransform DescImageRT = DescImage.GetComponent<RectTransform>();
        DescImageRT.localPosition = new Vector3(-400, 140, 0);
        DescImageRT.localScale = new Vector3(1, 1, 1);
        DescImageRT.sizeDelta = new Vector2(600, 600);
        DescImageRT.anchorMin = new Vector2(1, (float)0.5);
        DescImageRT.anchorMax = new Vector2(1, (float)0.5);

        GameObject A1 = new GameObject("BtnCheckAnswer" , typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        A1.transform.SetParent(WindResearch);
        A1.layer = 5;
        RectTransform btnRT = A1.GetComponent<RectTransform>();
        btnRT.localPosition = new Vector3(680, -119, -1);
        btnRT.anchoredPosition = new Vector3(680, -119, -1);
        btnRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        btnRT.sizeDelta = new Vector2(2000, 160);
        btnRT.anchorMin = new Vector2(0, 0.5f);
        btnRT.anchorMax = new Vector2(0, 0.5f);
        Image btnI = A1.GetComponent<Image>();
        btnI.sprite = BtnImage;
        btnI.color = new Color32(0, 155, 255, 155);
        A1.GetComponent<Button>().onClick.AddListener(() => CheckVariants());
        A1.GetComponent<Button>().interactable = false;

        GameObject A1Text = new GameObject("BtnCheckAnswerText", typeof(Text));
        A1Text.transform.SetParent(A1.transform);
        A1Text.layer = 5;
        A1Text.GetComponent<Text>().text = GlobalVar.TextUse["CheckRR"];
        A1Text.GetComponent<Text>().font = font;
        A1Text.GetComponent<Text>().fontSize = 95;
        A1Text.GetComponent<Text>().fontStyle = FontStyle.Bold;
        RectTransform TextRT = A1Text.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(0, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(2000, 160);
        A1Text.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        A1Text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        CheckBtn = A1.GetComponent<Button>();
    }
    private void CreateQuestionButton(int QuestionNumber)
    {

        GameObject A1 = new GameObject("BtnQuestion" + QuestionNumber, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
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
        btnI.sprite = BtnImage;
        btnI.color = new Color32(255, 125, 255, 75);
        A1.GetComponent<Button>().onClick.AddListener(() => OpenQuestion(QuestionNumber));

        GameObject A1Text = new GameObject("BtnText" + QuestionNumber, typeof(Text));
        A1Text.transform.SetParent(A1.transform);
        A1Text.layer = 5;
        A1Text.GetComponent<Text>().text = ""+ (QuestionNumber+1);
        A1Text.GetComponent<Text>().font = font;
        A1Text.GetComponent<Text>().fontSize = 95;
        RectTransform TextRT = A1Text.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(0, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(150, 150);
        A1Text.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        A1Text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        QuestionsBtns[QuestionNumber] = btnI;

        PosY -= 150;
    }
    private void CreateQuestion(int QuestionNumber)
    {
        int NextPartNumb = 5 * QuestionNumber;
        GameObject Question = new GameObject("Question" + QuestionNumber, typeof(RectTransform));
        Question.transform.SetParent(WindResearch);
        Question.layer = 5;
        RectTransform DescRT = Question.GetComponent<RectTransform>();
        DescRT.localPosition = new Vector3(0, 0, 0);
        DescRT.anchoredPosition = new Vector3(0, 0, 0);
        DescRT.localScale = new Vector3(1, 1, 1);
        DescRT.sizeDelta = new Vector2(0, 0);
        DescRT.anchorMin = new Vector2(0, 0);
        DescRT.anchorMax = new Vector2(1, 1);
        

        GameObject QuestionText = new GameObject("QuestionText" + QuestionNumber, typeof(Text));
        QuestionText.transform.SetParent(Question.transform);
        QuestionText.layer = 5;
        QuestionText.GetComponent<Text>().text = TextDoc[0 + NextPartNumb];
        QuestionText.GetComponent<Text>().font = font;
        QuestionText.GetComponent<Text>().fontSize = 155;
        QuestionText.GetComponent<Text>().fontStyle = UnityEngine.FontStyle.Normal;
        RectTransform TextRT = QuestionText.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(680, 190, 0);
        TextRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        TextRT.sizeDelta = new Vector2(2000, 1000);
        TextRT.GetComponent<Text>().color = new Color(255, 255, 255);
        TextRT.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
        TextRT.anchorMin = new Vector2(0, (float)0.5);
        TextRT.anchorMax = new Vector2(0, (float)0.5);

        
        try
        {
            CreateAnswerButton(QuestionNumber, Question.transform, -230, TextDoc[1 + NextPartNumb], 0, int.Parse(TextDoc[4 + NextPartNumb]));
            CreateAnswerButton(QuestionNumber, Question.transform, -340, TextDoc[2 + NextPartNumb], 1, int.Parse(TextDoc[4 + NextPartNumb]));
            CreateAnswerButton(QuestionNumber, Question.transform, -450, TextDoc[3 + NextPartNumb], 2, int.Parse(TextDoc[4 + NextPartNumb]));
        }
        catch
        {
            print(TextDoc[0 + NextPartNumb]);
            print(TextDoc[1 + NextPartNumb]);
            print(TextDoc[2 + NextPartNumb]);
            print(TextDoc[3 + NextPartNumb]);
            print(TextDoc[4 + NextPartNumb]);
        }
        
        Questions[QuestionNumber] = Question;

    }
    private void CreateAnswerButton(int QuestNumb, Transform QuestionT, float Y,string Text,int BtnID,int CorrectBtnID)
    {
        GameObject A1 = new GameObject("BtnAnswer" + BtnID, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        A1.transform.SetParent(QuestionT);
        A1.layer = 5;
        RectTransform btnRT = A1.GetComponent<RectTransform>();
        btnRT.localPosition = new Vector3(1030, Y, -1);
        btnRT.anchoredPosition = new Vector3(1030, Y, -1);
        btnRT.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        btnRT.sizeDelta = new Vector2(3400, 160);
        btnRT.anchorMin = new Vector2(0, 0.5f);
        btnRT.anchorMax = new Vector2(0, 0.5f);
        Image btnI = A1.GetComponent<Image>();
        btnI.sprite = BtnImage;
        btnI.color = new Color32(0, 155, 255, 155);
        A1.GetComponent<Button>().onClick.AddListener(() => ChooseVariant(btnI, BtnID, CorrectBtnID));
        /*var colors = A1.GetComponent<Button>().colors;
        colors.selectedColor = new Color32(0, 255, 55,255);
        A1.GetComponent<Button>().colors = colors;*/

        GameObject A1Text = new GameObject("BtnAnswerText" + BtnID, typeof(Text));
        A1Text.transform.SetParent(A1.transform);
        A1Text.layer = 5;
        A1Text.GetComponent<Text>().text = Text;
        A1Text.GetComponent<Text>().font = font;
        A1Text.GetComponent<Text>().fontSize = 95;
        RectTransform TextRT = A1Text.GetComponent<RectTransform>();
        TextRT.localPosition = new Vector3(0, 0, 0);
        TextRT.localScale = new Vector3(1, 1, 1);
        TextRT.sizeDelta = new Vector2(3400, 160);
        A1Text.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
        A1Text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        switch (BtnID)
        {
            case 0:
                AnswerBtns0[QuestNumb] = btnI;
                break;
            case 1:
                AnswerBtns1[QuestNumb] = btnI;
                break;
            case 2:
                AnswerBtns2[QuestNumb] = btnI;
                break;
        }
    }

    private void ChooseVariant(Image ImgBtn,int btnID,int CorrectID)
    {

        CheckBtn.GetComponent<Image>().color = new Color32(0, 155, 255, 155);
        CheckBtn.GetComponentInChildren<Text>().text = GlobalVar.TextUse["CheckRR"];

        QuestionsBtns[QuestionNowOpen].color = new Color32(0, 255, 55, 255);
        AnswerBtns0[QuestionNowOpen].color = new Color32(0, 155, 255, 155);
        AnswerBtns1[QuestionNowOpen].color = new Color32(0, 155, 255, 155);
        AnswerBtns2[QuestionNowOpen].color = new Color32(0, 155, 255, 155);
        ImgBtn.color = new Color32(0, 255, 55, 255);
        QuestionHaveAnswer[QuestionNowOpen] = true;

        if (btnID == CorrectID) AnswersCorrect[QuestionNowOpen] = true;
        else AnswersCorrect[QuestionNowOpen] = false;
        bool HaveFalse = QuestionHaveAnswer.Any(x => !x);
        if (!HaveFalse) CheckBtn.interactable = true;
        
    }

    private void CheckVariants()
    {
        bool HaveFalse = AnswersCorrect.Any(x => !x);
        if (!HaveFalse)
        {
            CheckBtn.GetComponent<Image>().color = new Color32(25, 255, 175, 255);
            CheckBtn.GetComponentInChildren<Text>().text = GlobalVar.TextUse["MaintenanceCR"];
            GlobalVar.ResearchAnimal[GlobalVar.AnimalNumber] = 1;
        }
        else
        {
            CheckBtn.GetComponent<Image>().color  = new Color32(225, 155, 155, 255);
            CheckBtn.GetComponentInChildren<Text>().text = GlobalVar.TextUse["ResultsAI"];
        }
    }

    void ClearQuestion()
    {
        for (int i = 0; i < QuestionsSum; i++)
        {
            Questions[i].SetActive(false);
        }
    }
    void OpenQuestion(int QuestionNumber)
    {
        ClearQuestion();
        QuestionNowOpen = QuestionNumber;
        Questions[QuestionNumber].SetActive(true);
    }
}
