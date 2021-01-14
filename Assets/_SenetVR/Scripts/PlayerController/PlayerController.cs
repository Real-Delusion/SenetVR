using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    // Scripts
    [Header ("Scripts")]
    [SerializeField]
    private CameraPointer cameraPointer;
    [SerializeField]
    private UIplayerController uIplayerController;
    [SerializeField]
    private InstructionsUI instructionsUI;

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

    // Torch and caliz
    private GameObject _caliz;
    private GameObject _torch;
    private bool holdingTorch = false;
    public float lookingAccuracy = 0.85f; // Between 0 and 1; To grab and drop
    private Vector3 moveDirection = Vector3.zero;

    // Main camera
    [Header ("Camera")]
    [SerializeField]
    public GameObject cameraPlayer;

    // Observe propertie
    [Header ("Observe mecanic:")]
    public Transform target;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 1F;

    // Player Movement Charactercontroller
    // For player movement (onyl for testing)
    [Header ("Character Controller Properties")]
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float speed = 7.0f;
    [SerializeField]
    private float gravity = -9.81f;

    // GRAVITY SYSTEM
    [Header ("Gravity")]
    [SerializeField]
    private Transform groundChecker;
    [SerializeField]
    private float groundDistance = .4f;
    [SerializeField]
    private LayerMask groundLayer;
    private bool _isGrounded;

    // -------------------------------- PlayerStates -----------------------------------
    public enum PlayerStates {
        Idle,
        Grab,
        Drop,
        Teleport,
        LightCaliz,
        UI,
        EnterDoor,
        Introduction,
        Observe,
        Observing
    }

    public PlayerStates _state = PlayerStates.Idle;

    public PlayerStates State {
        get => _state;
        set {
            _state = value;

            // If the state is idle
            if (_state == PlayerStates.Idle) {

            }

            // If the state is grabbing
            if (_state == PlayerStates.Grab) {

            }

            // If the state is dropping
            if (_state == PlayerStates.Drop) {

            }

            // If the state is Teleport
            if (_state == PlayerStates.Teleport) {

            }

            // If the state is UI
            if (_state == PlayerStates.UI) {

            }

            // If the state is EnterDoor
            if (_state == PlayerStates.EnterDoor) {

            }

            // If the state is Introduction
            if (_state == PlayerStates.Introduction) {

            }

        }
    }
    // -------------------------------- PlayerStates -----------------------------------

    // Start is called before the first frame update
    void Start () {
        characterController = GetComponent<CharacterController> ();

        uIplayerController = GetComponent<UIplayerController> ();

        cameraPointer = GetComponentInChildren<CameraPointer> ();

        instructionsUI = GameObject.FindGameObjectWithTag ("Instructions").GetComponent<InstructionsUI> ();

    }

    // Update is called once per frame
    void FixedUpdate () {
        Debug.Log ("STATE: " + _state);
        // Gravity check
        gravityAction ();
        // Player movement with keyboard (ONLY FOR TESTING)
#if UNITY_EDITOR
        moveAxes ();
#endif

        // Grabbing/Dropping an object
        if (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.X)) {
            if (_torch != null) {
                // The player has already the torch
                if (holdingTorch == true) {

                    Drop ();
                    holdingTorch = false;

                } else {
                    Vector3 dir = (_torch.transform.position - transform.position).normalized;
                    float dot = Vector3.Dot (dir, transform.forward);

                    Debug.Log (dot);

                    // dot is closer to 1 --> the player is looking at the object
                    // dot  is closer to 0 --> the player is looking away
                    if (dot > lookingAccuracy && _state == PlayerStates.Grab) {
                        Debug.Log ("Grab");

                        // grab it --> the torch tag object now is the child
                        _torch.transform.parent = cameraPlayer.transform;

                        // Desabling physics on Rigidbody
                        _torch.GetComponent<Rigidbody> ().isKinematic = true;

                        // Moving torch in a nice position
                        _torch.transform.position = this.transform.position + new Vector3 (.30f, -0.15f, 0.27f);

                        // Rotating a little bit the torch
                        _torch.transform.Rotate (32f, 0f, -6f);

                        // Chaging player state
                        holdingTorch = true;
                    }
                }

            }
        }

        // Lighting caliz
        if (Input.GetKeyDown (KeyCode.Joystick1Button2) && _state == PlayerStates.LightCaliz && holdingTorch == true && _caliz != null) {
            _caliz.transform.GetChild (1).gameObject.SetActive (true);
        }

        // Teleport
        if (Input.GetKeyDown (KeyCode.T) || Input.GetKeyDown (KeyCode.Joystick1Button7) && _state == PlayerStates.Teleport) {
            Vector3 hitPoint = cameraPointer.hit.point;
            transform.position = new Vector3 (hitPoint.x, transform.position.y, hitPoint.z);
            Debug.Log (cameraPointer.hit.point);
        }

        // UI
        if (_state == PlayerStates.UI) {

            // Play
            if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
                GameManager.LoadSceneAsync ("Temple1");
            }

            // Video
            if (Input.GetKeyDown (KeyCode.Joystick1Button0)) {
                GameManager.LoadSceneAsync ("Video360");
            }

            // Help
            if (Input.GetKeyDown (KeyCode.Joystick1Button2)) { }

            // Quit
            if (Input.GetKeyDown (KeyCode.Joystick1Button3)) {
                Application.Quit ();
            }
        }

        // EnterDoor
        if (Input.GetKeyDown (KeyCode.Joystick1Button0) && _state == PlayerStates.EnterDoor) {
            // Load random scene
            GameManager.LoadRandomScene ();
        }

        // Instrucctions
        if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Joystick1Button1) && _state == PlayerStates.Introduction) {
            instructionsUI.NextImg ();
        }

        // Observe
        if (Input.GetKeyDown ("q") || Input.GetKeyDown (KeyCode.Joystick1Button0) && _state == PlayerStates.Observe) {
            _state = PlayerStates.Observing;
        }

        if (_state == PlayerStates.Observing) {
            //Debug.Log("Observing");
            // Disable player controls
            this.transform.GetChild (0).gameObject.GetComponent<TrackedPoseDriver> ().enabled = false;

            // Zoom in to the jeroglificos
            float minFov = 50f;
            float maxFov = 100f;
            float sensitivity = 10f;

            transform.LookAt (target);
            float fov = Camera.main.fieldOfView;
            fov -= Time.deltaTime * sensitivity;
            fov = Mathf.Clamp (fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;

        }

    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Torch
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableGrab () {
        uIplayerController.ToggleTextGrab (true);

        // Chaging player state
        _state = PlayerStates.Grab;

    }

    public void DisableGrab () {

        uIplayerController.ToggleTextGrab (false);

        // Chaging player state
        _state = PlayerStates.Idle;

    }

    void Drop () {
        Debug.Log ("Drop");

        // Chaging player state
        _state = PlayerStates.Drop;

        // the torch is not the child anymore
        _torch.transform.parent = null;

        // Enabling physics on Rigidbody
        _torch.GetComponent<Rigidbody> ().isKinematic = false;

        // In order to get more than one torch
        _torch = null;

        // Chaging player state
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Observe
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableObserve () {
        uIplayerController.ToggleTextDoor (true);
        _state = PlayerStates.Observe;
    }

    public void DisableObserve () {
        uIplayerController.ToggleTextDoor (false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // UI
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableModeUI () {
        uIplayerController.ToggleTextUI (true);
        _state = PlayerStates.UI;
    }

    public void DisableModeUI () {
        uIplayerController.ToggleTextUI (false);
        uIplayerController.ToggleHelpText (false);

        _state = PlayerStates.Idle;
    }

    public void IntroMode (bool state) {
        if (state) {
            _state = PlayerStates.Introduction;
        } else {
            _state = PlayerStates.Idle;
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // EnterDoor
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableEnterDoor () {
        uIplayerController.ToggleTextObserver (true);
        _state = PlayerStates.EnterDoor;
    }

    public void DisableEnterDoor () {
        uIplayerController.ToggleTextObserver (false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Lighting caliz
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableLightCaliz () {
        uIplayerController.ToggleTextLightCaliz (true);
        _state = PlayerStates.LightCaliz;
    }

    public void DisableLightCaliz () {
        uIplayerController.ToggleTextLightCaliz (false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Movement teleport
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    public void EnableModeTeleport () {
        uIplayerController.ToggleTextTeleport (true);
        _state = PlayerStates.Teleport;
    }

    public void DisableModeTeleport () {
        uIplayerController.ToggleTextTeleport (false);
        _state = PlayerStates.Idle;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Player Movement Character Controller
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    private void moveAxes () {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move (move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move (velocity * Time.deltaTime);

    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------------------------------------------------------
    // Gravity
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    private void gravityAction () {
        _isGrounded = Physics.CheckSphere (groundChecker.position, groundDistance, groundLayer);

        if (_isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

    }
    //-------------------------------------------------------------------------------------------------------------------------------------------------

    void OnTriggerEnter (Collider col) {
        //Debug.Log("ON TRIGGER ENTER");

        if (col.gameObject.tag == "Torch") {
            if (holdingTorch == false) {
                // if we don't hold anything
                _torch = col.gameObject;
            }
        }

        if (col.gameObject.tag == "Caliz") {
            _caliz = col.gameObject;
        }

    }

    void OnTriggerExit (Collider col) {
        //Debug.Log("ON TRIGGER EXIT");

        if (col.gameObject.tag == "Torch") {

            _torch = null;

        }

        if (col.gameObject.tag == "Caliz") {

            _caliz = null;

        }
    }
}