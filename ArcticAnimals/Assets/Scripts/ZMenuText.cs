using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZMenuText : MonoBehaviour
{
    public string TextId;

    void Update()
    {
        try
        {
            gameObject.GetComponentInChildren<Text>().text = GlobalVar.TextUse[TextId];
        }
        catch
        {
            print(TextId);
        }
        
        
        
    }
}
