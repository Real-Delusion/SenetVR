using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraProgreso : MonoBehaviour
{
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = GameManager.instance.levelManager.Progress;
    }
}
