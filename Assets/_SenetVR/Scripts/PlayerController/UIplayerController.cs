using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIplayerController : MonoBehaviour
{
    [SerializeField]
    private Image pointer;

    public void SelectedPointer()
    {
        pointer.rectTransform.DOScale(new Vector3(2, 2, 2), 1f);
    }

    public void NormalPointer()
    {
        pointer.rectTransform.DOScale(new Vector3(1,1,1), 1f);
    }
}
