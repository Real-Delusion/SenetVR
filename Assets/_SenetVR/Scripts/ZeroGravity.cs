using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{

    public float FloatStrenght = 0.03f;

    private Vector3[] direction = { Vector3.up, Vector3.forward, Vector3.back };

    private int randomDirection = 0;
    private List<float> randomRotation = new List<float>();
    private bool stopMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        randomDirection = Random.Range(0, 2);

        float x = Random.Range(-0.3f, 0.3f);
        float y = Random.Range(-0.3f, 0.3f);
        float z = Random.Range(-0.3f, 0.3f);

        randomRotation.Add(x);
        randomRotation.Add(y);
        randomRotation.Add(z);

        StartCoroutine(StopMovement(8.0f));

    }

    // Update is called once per frame
    void Update()
    {

        if (stopMovement == false)
        {
            transform.GetComponent<Rigidbody>().AddForce(direction[0] * 0.03f);
            transform.GetComponent<Rigidbody>().AddForce(direction[randomDirection] * FloatStrenght);
            transform.Rotate(randomRotation[0], randomRotation[1], randomRotation[2]);
        }

        // When the object is stopped it will keep rotating
        transform.Rotate(randomRotation[0], randomRotation[1], randomRotation[2]);

    }

    private IEnumerator StopMovement(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        stopMovement = true;
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }


}
