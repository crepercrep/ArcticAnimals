using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GardenWindow : MonoBehaviour
{
    public Transform WindGarden;
    
    private int PosX = 50;

    private void OnEnable()
    {
        for (int i = 0; i < GlobalVar.SumAnimals; i++)
        {
            if (GlobalVar.PopulAnimal[i] > 0)
            {
                CreateAnimalButton(i);
                
            }
        }
    }
    private void CreateAnimalButton(int AnimalNum)
    {
        if(GameObject.Find("AnimalButton" + AnimalNum))
        {
            return;
        }
        
        GameObject A1 = new GameObject("AnimalButton"+ AnimalNum, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image), typeof(Button));
        A1.transform.SetParent(WindGarden);
        A1.layer = 5;
        RectTransform btnRT = A1.GetComponent<RectTransform>();
        btnRT.localPosition = new Vector3(PosX, 0, 0);
        btnRT.localScale = new Vector3(1, 1, 1);
        btnRT.anchorMin = new Vector2(0, (float)0.5);
        btnRT.anchorMax = new Vector2(0, (float)0.5);
        Image btnI = A1.GetComponent<Image>();
        btnI.sprite = GlobalVar.SpriteAnimal[AnimalNum];
        A1.GetComponent<Button>().onClick.AddListener(() => LoadScene(AnimalNum));
        PosX += 100;
    }
    public void LoadScene(int NumAnimal)
    {
        GlobalVar.AnimalNumber = NumAnimal;
        SceneManager.LoadScene("Animal" , LoadSceneMode.Single);
    }
}
