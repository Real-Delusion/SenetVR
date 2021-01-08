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

    // Scaler Properties
    private Vector3 _activatedScale = Vector3.one;
    private Vector3 _deactivatedScale = Vector3.zero;
    [Header("Transition Properties")]
    [SerializeField]
    private float _pointerTransition = 1f;
    [SerializeField]
    private float _activatedTextTransition = 1f;
    [SerializeField]
    private float _deactivetedTextTransition = 1f;

    public void TogglePointerMode(bool state)
    {
        if (state)
        {
            pointer.rectTransform.DOScale(new Vector3(2, 2, 2), _pointerTransition);
        }
        else
        {
            pointer.rectTransform.DOScale(new Vector3(1, 1, 1), _pointerTransition);
        }
    }

    public void ToggleTextTeleport(bool state)
    {
        textPointer.text = "Press R2 to move";
        if (state)
        {
            textPointer.rectTransform.DOScale(_activatedScale, _activatedTextTransition);
        }
        else
        {
            textPointer.rectTransform.DOScale(_deactivatedScale, _deactivetedTextTransition);
        }
    }

    public void ToggleTextGrab(bool state)
    {
        textPointer.text = "Press X to grab";
        if (state)
        {
            textPointer.rectTransform.DOScale(_activatedScale, _activatedTextTransition);
        }
        else
        {
            textPointer.rectTransform.DOScale(_deactivatedScale, _deactivetedTextTransition);
        }
    }

    public void ToggleTextLightCaliz(bool state)
    {
        textPointer.text = "Press O to light";
        if (state)
        {
            textPointer.rectTransform.DOScale(_activatedScale, _activatedTextTransition);
        }
        else
        {
            textPointer.rectTransform.DOScale(_deactivatedScale, _deactivetedTextTransition);
        }
    }

    public void ToggleTextUI(bool state)
    {
        textPointer.text = "";
        if (state)
        {
            textPointer.rectTransform.DOScale(_activatedScale, _activatedTextTransition);
        }
        else
        {
            textPointer.rectTransform.DOScale(_deactivatedScale, _deactivetedTextTransition);
        }
    }

    public void ToggleHelpText(bool state)
    {
        textPointer.text = "Look back";
        if (state)
        {
            textPointer.rectTransform.DOScale(_activatedScale, _activatedTextTransition);
        }
        else
        {
            textPointer.rectTransform.DOScale(_deactivatedScale, _deactivetedTextTransition);
        }
    }

    public void ToggleTextDoor(bool state)
    {
        textPointer.text = "Press Q to enter";
        if (state)
        {
            textPointer.rectTransform.DOScale(_activatedScale, _activatedTextTransition);
        }
        else
        {
            textPointer.rectTransform.DOScale(_deactivatedScale, _deactivetedTextTransition);
        }
    }
}
