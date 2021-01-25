using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputVRManager : MonoBehaviour
{
    [Header("Actions")]
    public SteamVR_Action_Boolean press = null;

    [Header("Scrpits")]
    public UIPlayerController uIPlayerController;

    // Start is called before the first frame update
    void Awake()
    {
        press.onStateDown += PressRelease;
    }

    void OnDestroy()
    {
        press.onStateDown -= PressRelease;
    }

    private void PressRelease(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        uIPlayerController.ToggleGUI();
    }
}
