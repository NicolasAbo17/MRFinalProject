using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementManager : MonoBehaviour
{
    public GameObject playerCamera;
    [HideInInspector]
    public float height;

    [SerializeField]
    private InputActionReference rotateAction;
    private int rotateNum = 0;

    [SerializeField]
    private ActionBasedContinuousMoveProvider moveProvider;
    [SerializeField]
    private InputActionReference moveReference;

    [SerializeField]
    private ActionBasedControllerManager actionManager;

    [SerializeField]
    private JumpProvider jumpProvider;

    public enum Movements{
        TELEPORT = 0,
        JUMP = 1,
        MOVE = 2
    }

    void Awake()
    {
        StartCoroutine(initialization());
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectTypeMovement(Movements.JUMP);
    }

    IEnumerator initialization()
    {
        yield return new WaitForSeconds(3f);
        setHeight();
    }

    void setHeight()
    {
        height = playerCamera.transform.position.y - gameObject.transform.position.y;
    }

    public void SelectTypeMovement(Movements pMovement)
    {
        SelectTeleport(pMovement == Movements.TELEPORT);
        SelectJump(pMovement == Movements.JUMP);
        SelectMove(pMovement == Movements.MOVE);
    }

    private void SelectTeleport(bool pSelected)
    {
        actionManager.enabled = pSelected;
    }

    private void SelectJump(bool pSelected)
    {
        jumpProvider.enabled = pSelected;
    }

    private void SelectMove(bool pSelected)
    {
        if (pSelected)
        {
            moveProvider.leftHandMoveAction = new InputActionProperty(moveReference);
        }
        else
        {
            moveProvider.leftHandMoveAction = new InputActionProperty();
        }
    }
}
