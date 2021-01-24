using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingCalices : MonoBehaviour
{

    public GameObject activator;
    public Material doorGlowMaterial;
    public float waitValue = 1.5f;
    public List<GameObject> calices;

    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if the fire of the caliz activator is enabled to start the epic lighting
        if (activator.transform.GetChild(1).gameObject.activeInHierarchy == enabled && calices[0].transform.GetChild(1).gameObject.activeInHierarchy == false)
        {
            StartLightingCalices();
        }
    }

    public void StartLightingCalices()
    {
        StartCoroutine(LightCalices(waitValue));
    }

    private IEnumerator LightCalices(float seconds)
    {
        for (int i = 0; i < calices.Count; i++)
        {

            yield return new WaitForSeconds(seconds);

            // Setting active the fire of the caliz
            calices[i].transform.GetChild(1).gameObject.SetActive(true);
            i++;

            if (i != calices.Count)
            {
                // Setting active the fire of the caliz
                calices[i].transform.GetChild(1).gameObject.SetActive(true);

               calices[i].transform.GetChild(2).gameObject.SetActive(true);

            }

            if (i == calices.Count - 1)
            {
                // Activating door when the last calices are lighted
                StartCoroutine(ActivateDoor(seconds));

            }


        }

    }

    private IEnumerator ActivateDoor(float seconds)
    {

        yield return new WaitForSeconds(seconds);

        Debug.Log("Door activated");

        // Changing door-basic material to door-glow material
        door.GetComponent<MeshRenderer>().material = doorGlowMaterial;

        door.GetComponent<AudioSource>().enabled = true;


    }

}
