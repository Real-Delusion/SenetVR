using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    public GameObject[] images;

    private int _count = 0;

    //public void NextImg()
    //{

    //    _count++;
    //    if (_count == 1)
    //    {
    //        cardboard.SetActive(false);
    //        gamepad.SetActive(true);
    //    }
    //    if (_count == 2)
    //    {
    //        gamepad.SetActive(false);
    //        head.SetActive(true);
    //        button.SetActive(false);

    //    }
    //}
    private void Start()
    {
        foreach (var img in images)
        {
            img.transform.DOScale(0f, 0f);
        }

        images[0].transform.DOScale(1f, 0f);
    }

    public void NextImg()
    {
        _count++;

        if (_count < images.Length)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (i == _count)
                {
                    images[i].transform.DOScale(1f, .75f);
                }
                else
                {
                    images[i].transform.DOScale(0f, 0f);
                }
            }
        }
        else
        {
            ResetCount();
            for (int i = 0; i < images.Length; i++)
            {
                if (i == _count)
                {
                    images[i].transform.DOScale(1f, .75f);
                }
                else
                {
                    images[i].transform.DOScale(0f, 0f);
                }
            }
        }
    }

    public void ResetCount()
    {
        _count = 0;
    }
}
