using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class JumpControllerManager : MonoBehaviour
{
    // [SerializeField]
    // private GameObject baseController;
    
    [SerializeField]
    private GameObject jumpController;

    [SerializeField]
    private InputActionReference jumpModeActivate;

    private XRRayInteractor interactor;


    // Start is called before the first frame update
    void Awake()
    {
        jumpModeActivate.action.started += ActivateJump;
        jumpModeActivate.action.canceled += DeactivateJump;

        interactor = jumpController.GetComponent<XRRayInteractor>();
    }

    void OnDestroy()
    {
        jumpModeActivate.action.started -= ActivateJump;
        jumpModeActivate.action.canceled -= DeactivateJump;
    }

    private void ActivateJump(InputAction.CallbackContext context)
    {
        Debug.Log("Activate");
        interactor.enabled = true;
    }

    private void DeactivateJump(InputAction.CallbackContext context)
    {
        Debug.Log("Deactivate: " + interactor.referenceFrame.ToString());
        interactor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
