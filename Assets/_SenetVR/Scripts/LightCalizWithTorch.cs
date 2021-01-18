using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCalizWithTorch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Flame")
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
