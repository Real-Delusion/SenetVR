using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeroglificos : MonoBehaviour {

    Animator lightsAnim;
    // Start is called before the first frame update
    void Start () {
        lightsAnim = this.gameObject.transform.GetChild (0).gameObject.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter (Collider c) {
        if (c.tag == "Flame") {
            Debug.Log ("Cool glow");

            // Insert cool glow animation around the jeroglifico
            lightsAnim.SetTrigger ("Hieroglyphs");

            //lightsAnim.ResetTrigger ("Hieroglyphs");
        }
    }
}