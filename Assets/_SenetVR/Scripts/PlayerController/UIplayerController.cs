using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIplayerController : MonoBehaviour
{
    [Header("Pointer")]
    [SerializeField]
    private Image pointer;
    [SerializeField]
    private Text textPointer;

    public void TogglePointerMode(bool state)
    {
        if (state)
        {
            pointer.rectTransform.DOScale(new Vector3(2, 2, 2), 1f);
        }
        else
        {
            pointer.rectTransform.DOScale(new Vector3(1, 1, 1), 1f);
        }
    }

    public void ToggleTextTeleport(bool state)
    {
        textPointer.text = "Press Fire to move";
        if (state)
        {
            textPointer.rectTransform.DOScale(new Vector3(.1f, .1f, .1f), .3f);
        }
        else
        {
            textPointer.rectTransform.DOScale(new Vector3(0, 0, 0), .1f);
        }
    }

    public void ToggleTextGrab(bool state)
    {
        textPointer.text = "Press E to grab";
        if (state)
        {
            textPointer.rectTransform.DOScale(new Vector3(1, 1, 1), .3f);
        }
        else
        {
            textPointer.rectTransform.DOScale(new Vector3(0, 0, 0), .1f);
        }
    }

    public void ToggleTextLightCaliz(bool state)
    {
        textPointer.text = "Press Q to light";
        if (state)
        {
            textPointer.rectTransform.DOScale(new Vector3(1, 1, 1), .3f);
        }
        else
        {
            textPointer.rectTransform.DOScale(new Vector3(0, 0, 0), .1f);
        }
    }
}
