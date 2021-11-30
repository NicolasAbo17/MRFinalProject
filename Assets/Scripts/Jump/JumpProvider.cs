using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class JumpProvider : MonoBehaviour
{
    // [SerializeField]
    // private GameObject baseController;

    [SerializeField]
    private GameObject jumpController;

    [SerializeField]
    private InputActionReference jumpModeActivate;

    private XRRayInteractor interactor;
    private ActionBasedContinuousMoveProvider moveProvider;
    private CharacterController characterController;

    private float originalSpeed = 0f;
    private float fastSpeed = 20f;
    private bool moving = false;
    private Vector3 objective = Vector3.zero;


    // Start is called before the first frame update
    void Awake()
    {
        jumpModeActivate.action.started += ActivateJump;
        jumpModeActivate.action.canceled += DeactivateJump;

        interactor = jumpController.GetComponent<XRRayInteractor>();
        moveProvider = gameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        characterController = gameObject.GetComponent<CharacterController>();

        originalSpeed = moveProvider.moveSpeed;
    }

    void OnDestroy()
    {
        jumpModeActivate.action.started -= ActivateJump;
        jumpModeActivate.action.canceled -= DeactivateJump;
    }

    private void ActivateJump(InputAction.CallbackContext context)
    {
        if (!moving)
        {
            Debug.Log("Activate");
            interactor.enabled = true;
        }
    }

    private void DeactivateJump(InputAction.CallbackContext context)
    {
        if (!moving)
        {
            interactor.enabled = false;
            if (interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                moveProvider.moveSpeed = fastSpeed;
                objective = hit.point;
               
                moving = true;  
            }
        }
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            Vector3 direction = objective - transform.position;
            if (direction.magnitude <= 0.5)
            {
                transform.position = objective;

                moveProvider.moveSpeed = originalSpeed;
                moving = false;
            }
            else
            {
                characterController.Move(direction.normalized);
            }
        }
    }

}
