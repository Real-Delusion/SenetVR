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
     
    }

    public void StartLightingCalices()
    {
        StartCoroutine(LightCalices(1.3f));
    }

    private IEnumerator LightCalices(float seconds)
    {
        for(int i = 0; i < calices.Count ; i++)
        {
            calices[i].transform.GetChild(1).gameObject.SetActive(true);
            i++;

            if(i != calices.Count)
            {
                calices[i].transform.GetChild(1).gameObject.SetActive(true);
                yield return new WaitForSeconds(seconds);
            }
            
        }

    }



}
