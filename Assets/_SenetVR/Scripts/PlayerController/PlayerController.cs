using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Scripts
    [Header("Scripts")]
    [SerializeField]
    private CameraPointer cameraPointer;
    [SerializeField]
    private UIplayerController uIplayerController;

    // -------------------------------- PlayerStates -----------------------------------
    public enum PlayerStates
    {
        Idle,
        Grab,
        Drop,
        HoldingTorch,
        Teleport,
        LightCaliz,

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

            // If the state is holdingTorch
            if (_state == PlayerStates.HoldingTorch)
            {

            }

            // If the state is Teleport
            if (_state == PlayerStates.Teleport)
            {

            }


        }
    }
    // -------------------------------- PlayerStates -----------------------------------


    // For player movement (onyl for testing)
    public float speed = 7.0f;

    // Between 0 and 1;
    public float lookingAccuracy = 0.85f;

    public GameObject caliz;

    private GameObject torch;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;


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
        //Debug.Log("STATE: " + _state);

        // Player movement with keyboard (ONLY FOR TESTING)
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);

        // Grabbing/Dropping an object
        if (Input.GetKeyDown("e"))
        {
            if (torch != null)
            {
                // The player has already the torch
                if (_state == PlayerStates.HoldingTorch)
                {

                    Drop();

                }
                else
                {
                    Vector3 dir = (torch.transform.position - transform.position).normalized;
                    float dot = Vector3.Dot(dir, transform.forward);

                    Debug.Log(dot);

                    // dot is closer to 1 --> the player is looking at the object
                    // dot  is closer to 0 --> the player is looking away
                    if (dot > lookingAccuracy)
                    {
                        Grab();
                    }
                }

            }
        }

        if (Input.GetKeyDown("q") && _state == PlayerStates.LightCaliz)
        {
            caliz.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (Input.GetKeyDown("f") && _state == PlayerStates.Grab)
        {
            // grab it --> the torch tag object now is the child
            torch.transform.parent = this.transform;

            // Desabling physics on Rigidbody
            torch.GetComponent<Rigidbody>().isKinematic = true;

            // Moving torch in a nice position
            torch.transform.position = this.transform.position + new Vector3(0.6f, -0.5f, 0.83f);

            // Rotating a little bit the torch
            torch.transform.Rotate(0f, 0f, 14f);

            // Chaging player state
            _state = PlayerStates.HoldingTorch;
        }

        if (Input.GetButtonDown("Fire1") && _state == PlayerStates.Teleport)
        {
            Vector3 hitPoint = cameraPointer.hit.point;
            transform.position = new Vector3(hitPoint.x, hitPoint.y + transform.position.y, hitPoint.z);
            Debug.Log(cameraPointer.hit.point);
        }

    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Torch
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    public void Grab()
    {
        Debug.Log("Grab");

        uIplayerController.ToggleTextTeleport(true);

        // Chaging player state
        _state = PlayerStates.Grab;

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


    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("ON TRIGGER ENTER");

        if (col.gameObject.tag == "Torch")
        {
            if (_state == PlayerStates.Idle)
            {
                // if we don't hold anything
                torch = col.gameObject;
            }
        }

        if(col.gameObject.tag == "Caliz" && _state == PlayerStates.HoldingTorch)
        {
            caliz = col.gameObject;
        }

    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log("ON TRIGGER EXIT");

        if (col.gameObject.tag == "Torch")
        {
            if (_state == PlayerStates.Idle)
            {
                torch = null;
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Lighting caliz
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    public void LightCaliz()
    {
        uIplayerController.ToggleTextTeleport(true);
        _state = PlayerStates.LightCaliz;
    }

    public void PutOutCaliz()
    {
        uIplayerController.ToggleTextTeleport(false);
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
}
