using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingCalices : MonoBehaviour
{

    public List<GameObject> calices;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waitSeconds(1));
        LightCalices2();
    }

    private IEnumerator waitSeconds(int seconds)
    {
        LightCalices();
        yield return new WaitForSeconds(seconds);
    }

    private IEnumerator waitSeconds2(int seconds)
    {
        LightCalices2();
        yield return new WaitForSeconds(seconds);
    }

    private void LightCalices()
    {
        calices[0].transform.GetChild(1).gameObject.SetActive(true);
        calices[1].transform.GetChild(1).gameObject.SetActive(true);



    }

    private void LightCalices2()
    {
        calices[2].transform.GetChild(1).gameObject.SetActive(true);
        calices[3].transform.GetChild(1).gameObject.SetActive(true);



    }
}
