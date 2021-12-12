using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementManager : MonoBehaviour
{
    public GameObject playerCamera;
    [SerializeField]
    private TxtBtn heightBtn;
    [SerializeField]
    private TxtBtn movementBtn;

    [SerializeField]
    private ActionBasedContinuousMoveProvider moveProvider;
    [SerializeField]
    private InputActionReference moveReference;

    [SerializeField]
    private ActionBasedControllerManager actionManager;
    [SerializeField]
    private GameObject teleportController;

    [SerializeField]
    private JumpProvider jumpProvider;
    [SerializeField]
    private GameObject jumpController;

    public enum Movements{
        TELEPORT = 0,
        JUMP = 1,
        MOVE = 2
    }

    void Awake()
    {
        StartCoroutine(Initialization());
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectTypeMovement(GameSingleton.Instance.movement);
    }

    IEnumerator Initialization()
    {
        if(GameSingleton.Instance.height == 0){
            yield return new WaitForSeconds(3f);
            SetHeight();
        }else{
            heightBtn.SetTxt("Height: " + GameSingleton.Instance.height.ToString("#.00") + " cm");
        }
    }

    public void SetHeight()
    {
        GameSingleton.Instance.height = playerCamera.transform.position.y - gameObject.transform.position.y;
        heightBtn.SetTxt("Height: " + GameSingleton.Instance.height.ToString("#.00") + " cm");
    }

    public void SelectTypeMovement(Movements pMovement)
    {
        SelectTeleport(pMovement == Movements.TELEPORT);
        SelectJump(pMovement == Movements.JUMP);
        SelectMove(pMovement == Movements.MOVE);

        switch (GameSingleton.Instance.movement)
        {
            case Movements.TELEPORT:
                movementBtn.SetTxt("Teleport");
                break;
            case Movements.JUMP:
                movementBtn.SetTxt("Jump");
                break;
            case Movements.MOVE:
                movementBtn.SetTxt("Move");
                break;
        }
    }

    private void SelectJump(bool pSelected)
    {
        jumpProvider.enabled = pSelected;
        jumpController.SetActive(pSelected);
    }

    private void SelectTeleport(bool pSelected)
    {
        actionManager.enabled = pSelected;
        teleportController.SetActive(pSelected);
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

    public void NextMovement(){
        GameSingleton.Instance.movement = (Movements)(((int)GameSingleton.Instance.movement + 1)%3);
        SelectTypeMovement(GameSingleton.Instance.movement);
    }
}
