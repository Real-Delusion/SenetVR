using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SpatialTracking;
using HTC.UnityPlugin.Vive;


public class PlayerController : MonoBehaviour
{
    // ----------------------------------------------------------------------------------
    // Scripts
    // ----------------------------------------------------------------------------------
    [Header("Scripts")]
    [SerializeField]
    private UIPlayerController UIPlayerController;
    [SerializeField]
    private InstructionsUI instructionsUI;
    // ----------------------------------------------------------------------------------



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


    // ---------------------------------------------------------------------------------
    // Runetime Sequence
    // ---------------------------------------------------------------------------------
    void Start()
    {
        UIPlayerController = GetComponent<UIPlayerController>();

    }

    private void Update()
    {
        /*if (Input.GetButtonDown("")
        {
            UIPlayerController.ToggleGUI(!UIPlayerController.StateGUI);
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Observe
        if (_state == PlayerStates.Observing)
        {
            Debug.Log("Observing");

            // Cool glow made by Rosa
        }
    }
    // ---------------------------------------------------------------------------------

    public void Observe()
    {
        _state = PlayerStates.Observing;
    }

    // ---------------------------------------------------------------------------------
    // LevelsChanges
    // ---------------------------------------------------------------------------------

    public void ChangeScene(string sceneName)
    {
        GameManager.LoadSceneAsync(sceneName);
    }

    public void ExitGame()
    {
        GameManager.instance.levelManager.ExitGame();
    }
}
