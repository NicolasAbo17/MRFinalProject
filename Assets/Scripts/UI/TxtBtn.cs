using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TxtBtn : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;

    public void SetTxt(string pTxt){
        textComponent.text = pTxt;
    }
}
