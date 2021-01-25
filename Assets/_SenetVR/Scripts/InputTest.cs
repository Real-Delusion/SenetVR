using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputTest : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Debug.Log(SteamVR_Input.GetState ("/actions/htc_viu/in/viu_press_00", SteamVR_Input_Sources.LeftHand));
        /* if (SteamVR_Input.GetState("/actions/htc_viu/in/viu_press_00")) {
             Debug.Log("Hello");
         }*/
    }
}