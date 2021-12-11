using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class InputListenerButtons : MonoBehaviour
{
    List<InputDevice> devices;
    public XRNode controllerNode;

    [Tooltip("Event when the button strats being pressed")]
    public UnityEvent OnPress;

    [Tooltip("Event when the button strats being released")]
    public UnityEvent OnRelease;

    //keep track of whether we are pressing the button 
    bool isPressed = false;

    private void Awake()
    {
        devices = new List<InputDevice>();
    }

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
    }

    //Star is called before the first frame update 
    void Start()
    {
        GetDevice();
    }

    void Update()
    {

        GetDevice();
        foreach(var device in devices)
        {
            Debug.Log(device.name + "" + device.characteristics);

            if(device.isValid)
            {
                bool inputValue;

                if(device.TryGetFeatureValue(CommonUsages.secondaryButton, out inputValue ) && inputValue)
                {
                    if (!isPressed)
                    {
                        isPressed = true;
                        Debug.Log("OnPress event is called");

                        OnPress.Invoke();
                    }
                }
                else if(isPressed)
                {
                    isPressed = false;
                    OnRelease.Invoke();
                    Debug.Log("OnRelease event is called");
                }
            }
        }
    }
}
