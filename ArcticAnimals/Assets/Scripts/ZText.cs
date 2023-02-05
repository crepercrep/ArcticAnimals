using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZText : MonoBehaviour
{
    public string TextId;
    void Awake()
    {
        if(TextId.Equals("")) gameObject.GetComponentInChildren<Text>().text = GlobalVar.TextUse[gameObject.name];
        else gameObject.GetComponentInChildren<Text>().text = GlobalVar.TextUse[TextId];
    }

}
