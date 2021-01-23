using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SpatialTracking;


public class PlayerController : MonoBehaviour
{

    // Scripts
    [Header("Scripts")]
    [SerializeField]
    private UIPlayerController UIPlayerController;
    [SerializeField]
    private InstructionsUI instructionsUI;
    public Transform target;
    public Camera camera;



    // -------------------------------- PlayerStates -----------------------------------
    public enum PlayerStates
    {
        Idle,
        UI,
        EnterDoor,
        Observe,
        Observing
    }

    public PlayerStates _state = PlayerStates.Idle;

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

           
            // If the state is UI
            if (_state == PlayerStates.UI)
            {

            }

            // If the state is EnterDoor
            if (_state == PlayerStates.EnterDoor)
            {

            }

            // If the state is Observe
            if (_state == PlayerStates.Observe)
            {

            }

            // If the state is Observing
            if (_state == PlayerStates.Observing)
            {

            }



        }
    }
    // -------------------------------- PlayerStates -----------------------------------

    // Start is called before the first frame update
    void Start()
    {
        UIPlayerController = GetComponent<UIPlayerController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Observe
        if (_state == PlayerStates.Observing)
        {
            Debug.Log("Observing");

            // Disable player controls (Player --> ViveCameraRig --> Camera
            //camera.gameObject.GetComponent<TrackedPoseDriver>().enabled = false;

            // Zoom in to the jeroglificos
            float minFov = 50f;
            float maxFov = 80f;
            float sensitivity = 10f;

            transform.LookAt(target);
            /*float fov = camera.fieldOfView;
            fov -= Time.deltaTime * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            camera.fieldOfView = fov;*/

        }
    }

    public void Observe()
    {
        _state = PlayerStates.Observing;
    }
}
