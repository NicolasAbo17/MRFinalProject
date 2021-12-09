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
    private GameObject camera;

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
    private float height;
    private float offsetHeight = 0.1f;
    private bool pointing = false;

    // Start is called before the first frame update
    void Awake()
    {
        jumpModeActivate.action.started += ActivateJump;
        jumpModeActivate.action.canceled += DeactivateJump;

        interactor = jumpController.GetComponent<XRRayInteractor>();
        moveProvider = gameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        characterController = gameObject.GetComponent<CharacterController>();

        originalSpeed = moveProvider.moveSpeed;

        StartCoroutine(initialization());
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
            pointing = true;
            interactor.enabled = true;
        }
    }

    private void DeactivateJump(InputAction.CallbackContext context)
    {      
        pointing = false;
        interactor.enabled = false;
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

    void Update() {
        if (camera.transform.position.y - gameObject.transform.position.y >= height+offsetHeight && !moving){
            interactor.enabled = false;
            if (interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                objective = hit.point;

                moveProvider.moveSpeed = (objective - transform.position).magnitude*2f;
                
                moving = true;
            }
        }
    }


    IEnumerator initialization(){
        yield return new WaitForSeconds(5f);
        setHeight();
    }

    void setHeight(){
        height = camera.transform.position.y - gameObject.transform.position.y;
    }

}
