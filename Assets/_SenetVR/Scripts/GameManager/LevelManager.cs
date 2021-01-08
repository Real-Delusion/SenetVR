using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    // Scena de carga
    [SerializeField]
    const string _preload = "Loader";
    // Scene Main
    [SerializeField]
    private const string _mainMenu = "MainScene";

    // Progress
    [SerializeField]
    float progress = 0f;

    // Animotor which controll the scene transition
    [SerializeField]
    private float transitionTime = 1f;

    // Properties
    public float Progress { get => progress; set => progress = value; }

    public string MainMenu => _mainMenu;

    public string Preload => _preload;


    // Carga de scenes sincrona

    // With string
    public IEnumerator LoadSinc(string scene)
    {
        // Change scene
        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(transitionTime);
    }

    // Carga de scenes asincrona
    public IEnumerator LoadAsync(string scene)
    {

        yield return null;
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            progress = async.progress;
            if (progress >= .9f)
            {
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void goMainScreen()
    {
        GameManager.LoadSceneAsync(GameManager.instance.levelManager.MainMenu);
    }
}
