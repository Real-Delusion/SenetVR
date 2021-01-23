using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeroglificos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Flame")
        {
            Debug.Log("Cool glow");

            // Insert cool low animation around the jeroglifico
        }
    }
}
