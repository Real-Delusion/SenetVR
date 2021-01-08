using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    public GameObject cardboard;
    public GameObject gamepad;
    public GameObject head;
    public GameObject button;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        count++;
        if (count == 1)
        {
            cardboard.SetActive(false);
            gamepad.SetActive(true);
        }
        if (count == 2)
        {
            gamepad.SetActive(false);
            head.SetActive(true);
            button.SetActive(false);

        }
    }
}
