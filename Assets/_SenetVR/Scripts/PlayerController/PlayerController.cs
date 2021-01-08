using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Scripts
    [Header("Scripts")]
    [SerializeField]
    private CameraPointer cameraPointer;
    [SerializeField]
    private UIplayerController uIplayerController;

    // UI
    private GameObject _uiElement;

    // Buttons PS4 controller
    //Buttons
    //Square = joystick button 0
    //X       = joystick button 1
    //Circle  = joystick button 2
    //Triangle= joystick button 3
    //L1      = joystick button 4
    //R1      = joystick button 5
    //L2      = joystick button 6
    //R2      = joystick button 7
    //Share	= joystick button 8
    //Options = joystick button 9
    //L3      = joystick button 10
    //R3      = joystick button 11
    //PS      = joystick button 12
    //PadPress= joystick button 13

    // -------------------------------- PlayerStates -----------------------------------
    public enum PlayerStates
    {
        Idle,
        Grab,
        Drop,
        Teleport,
        LightCaliz,
        UI,

    }

    private PlayerStates _state = PlayerStates.Idle;

    public PlayerStates State
    {
        get => _state;
        set
        {
            _state = value;

            // If the state is idle
            if (_state == PlayerStates.Idle)
            {

            }

            // If the state is grabbing
            if (_state == PlayerStates.Grab)
            {

            }

            // If the state is dropping
            if (_state == PlayerStates.Drop)
            {

            }

            // If the state is Teleport
            if (_state == PlayerStates.Teleport)
            {

            }

            // If the state is UI
            if (_state == PlayerStates.UI)
            {

            }

        }
    }
    // -------------------------------- PlayerStates -----------------------------------


    // For player movement (onyl for testing)
    public float speed = 7.0f;

    // Between 0 and 1;
    public float lookingAccuracy = 0.85f;

    private GameObject caliz;
    private GameObject torch;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private bool holdingTorch = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        uIplayerController = GetComponent<UIplayerController>();

        cameraPointer = GetComponentInChildren<CameraPointer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("STATE: " + _state);

        // Player movement with keyboard (ONLY FOR TESTING)
#if UNITY_EDITOR
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
#endif

        // Grabbing/Dropping an object
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (torch != null)
            {
                // The player has already the torch
                if (holdingTorch == true)
                {

                    Drop();
                    holdingTorch = false;

                }
                else
                {
                    Vector3 dir = (torch.transform.position - transform.position).normalized;
                    float dot = Vector3.Dot(dir, transform.forward);

                    Debug.Log(dot);

                    // dot is closer to 1 --> the player is looking at the object
                    // dot  is closer to 0 --> the player is looking away
                    if (dot > lookingAccuracy && _state == PlayerStates.Grab)
                    {
                        Debug.Log("Grab");

                        // grab it --> the torch tag object now is the child
                        torch.transform.parent = this.transform;

                        // Desabling physics on Rigidbody
                        torch.GetComponent<Rigidbody>().isKinematic = true;

                        // Moving torch in a nice position
                        torch.transform.position = this.transform.position + new Vector3(0.6f, -0.5f, 0.83f);

                        // Rotating a little bit the torch
                        torch.transform.Rotate(0f, 0f, 14f);

                        // Chaging player state
                        holdingTorch = true;
                    }
                }

            }
        }

        // Lighting caliz
        if (Input.GetKeyDown(KeyCode.Joystick1Button2) && _state == PlayerStates.LightCaliz && holdingTorch == true && caliz != null)
        {
            caliz.transform.GetChild(1).gameObject.SetActive(true);
        }

        // Teleport
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) && _state == PlayerStates.Teleport)
        {
            Vector3 hitPoint = cameraPointer.hit.point;
            transform.position = new Vector3(hitPoint.x, hitPoint.y + transform.position.y, hitPoint.z);
            Debug.Log(cameraPointer.hit.point);
        }

        // UI
        if (_state == PlayerStates.UI)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                GameManager.LoadSceneAsync("MainScene");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                GameManager.LoadSceneAsync("Temple1");
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                uIplayerController.ToggleHelpText(true);

            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                Application.Quit();
            }

        }

    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Torch
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableGrab()
    {
        uIplayerController.ToggleTextGrab(true);

        // Chaging player state
        _state = PlayerStates.Grab;

    }

    public void DisableGrab()
    {

        uIplayerController.ToggleTextGrab(false);

        // Chaging player state
        _state = PlayerStates.Idle;

    }

    void Drop()
    {
        Debug.Log("Drop");

        // Chaging player state
        _state = PlayerStates.Drop;

        // the torch is not the child anymore
        torch.transform.parent = null;

        // Enabling physics on Rigidbody
        torch.GetComponent<Rigidbody>().isKinematic = false;

        // In order to get more than one torch
        torch = null;

        // Chaging player state
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Enter door 
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableEnterDoor()
    {
        uIplayerController.ToggleTextDoor(true);
        _state = PlayerStates.EnterDoor;
    }

    public void DisableEnterDoor()
    {
        uIplayerController.ToggleTextDoor(false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Lighting caliz
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableLightCaliz()
    {
        uIplayerController.ToggleTextLightCaliz(true);
        _state = PlayerStates.LightCaliz;
    }

    public void DisableLightCaliz()
    {
        uIplayerController.ToggleTextLightCaliz(false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Movement teleport
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableModeTeleport()
    {
        uIplayerController.ToggleTextTeleport(true);
        _state = PlayerStates.Teleport;
    }

    public void DisableModeTeleport()
    {
        uIplayerController.ToggleTextTeleport(false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // UI
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableModeUI()
    {
        uIplayerController.ToggleTextUI(true);
        _state = PlayerStates.UI;
    }

    public void DisableModeUI()
    {
        uIplayerController.ToggleTextUI(false);
        uIplayerController.ToggleHelpText(false);

        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("ON TRIGGER ENTER");

        if (col.gameObject.tag == "Torch")
        {
            if (holdingTorch == false)
            {
                // if we don't hold anything
                torch = col.gameObject;
            }
        }

        if (col.gameObject.tag == "Caliz")
        {
            caliz = col.gameObject;
        }

    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log("ON TRIGGER EXIT");

        if (col.gameObject.tag == "Torch")
        {

            torch = null;

        }

        if (col.gameObject.tag == "Caliz")
        {

            caliz = null;

        }
    }
}
