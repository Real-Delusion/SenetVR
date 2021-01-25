using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        GameManager.LoadRandomScene();
    }

    public void loadMainScene()
    {
        GameManager.LoadSceneAsync("MainScene");
    }


}
