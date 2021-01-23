﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        GameManager.instance.levelManager.goMainScreen();
    }

    public void GoToTemple1() 
    { 
        GameManager.LoadSceneAsync("Temple1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChargeVideo360()
    {

    }
}