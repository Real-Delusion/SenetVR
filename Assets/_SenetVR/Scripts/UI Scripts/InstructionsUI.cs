using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    public GameObject cardboard;
    public GameObject gamepad;
    public GameObject head;
    public GameObject button;

    private int _count = 0;

    public void NextImg()
    {

        _count++;
        if (_count == 1)
        {
            cardboard.SetActive(false);
            gamepad.SetActive(true);
        }
        if (_count == 2)
        {
            gamepad.SetActive(false);
            head.SetActive(true);
            button.SetActive(false);

        }
    }

    public void ResetCount()
    {
        _count = 0;
    }
}
