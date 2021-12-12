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
    private MovementManager movementManager;

    private float originalSpeed = 0f;

    private bool moving = false;
    private bool pointing = false;

    private Vector3 objective = Vector3.zero;
    private const float offsetHeight = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        jumpModeActivate.action.started += ActivateJump;
        jumpModeActivate.action.canceled += DeactivateJump;

        interactor = jumpController.GetComponent<XRRayInteractor>();
        
        moveProvider = gameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        characterController = gameObject.GetComponent<CharacterController>();
        movementManager = gameObject.GetComponent<MovementManager>();

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
        if (pointing && !moving &&
        movementManager.playerCamera.transform.position.y - gameObject.transform.position.y >= 
        GameSingleton.Instance.height + offsetHeight){
            interactor.enabled = false;
            if (interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                objective = hit.point;

                moveProvider.moveSpeed = (objective - transform.position).magnitude*2f;
                
                moving = true;
            }
        }
    }
}
