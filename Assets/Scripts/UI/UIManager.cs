using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject UI_VRMenuGameObject;

    // Start is called before the first frame update
    void Start()
    {
        UI_VRMenuGameObject.SetActive(false);
    }

   
    public void OnWorldButtonClicked() 
    {
        Debug.Log("Worlds button clicked");
    }

    public void Button2Clicked()
    {
        Debug.Log("Button 2 clicked");
    }

    public void Button3Clicked()
    {
        Debug.Log("Button 3 clicked");
    }
}
