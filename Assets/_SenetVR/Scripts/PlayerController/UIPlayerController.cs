using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerController : MonoBehaviour
{
    // ----------------------------------------------------------------------------------
    // Elements GUI
    [Header("Elements GUI")]
    public GameObject canvas;
    public Image slicedPanel;
    public GameObject exitPanel;
    // ----------------------------------------------------------------------------------
    // Properties
    [Header("Properties")]
    private bool _stateGUI = false;
    public bool StateGUI { get => _stateGUI; set => _stateGUI = value; }

    // ----------------------------------------------------------------------------------
    // Corutine
    IEnumerator _coroutine;


    // ----------------------------------------------------------------------------------

    // ----------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        // Initial set up
        canvas.transform.DOScale(0f, 0f);
        slicedPanel.GetComponent<Image>().fillAmount = 0f;
        exitPanel.transform.DOScale(0f, 0f);
    }

    // ----------------------------------------------------------------------------------
    // Methods
    // ----------------------------------------------------------------------------------
    public void ToggleGUI()
    {
        StateGUI = !StateGUI;

        if (StateGUI)
        {
            canvas.transform.DOScale(0.0003f, .75f);
        }
        else
        {
            canvas.transform.DOScale(0f, .75f);
        }
    }

    void ToggleSlicedPanel(bool state)
    {
        if (state)
        {
            DOTweenModuleUI.DOFillAmount(slicedPanel.GetComponent<Image>(), 1f, 1f);
        } 
        else
        {
            DOTweenModuleUI.DOFillAmount(slicedPanel.GetComponent<Image>(), 0f, 1f);
        }
    }
    
    public void ToggleExitPanel(bool state)
    {
        ToggleSlicedPanel(state);

        if (state)
        {
            exitPanel.transform.DOScale(1f, 2f);
        }
        else
        {
            exitPanel.transform.DOScale(0f, 2f);
        }
    }
}
