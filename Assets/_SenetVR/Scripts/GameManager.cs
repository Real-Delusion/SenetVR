using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RealDelusion.Utils;

public class GameManager : MonoBehaviour
{
    // Singleton
    [Header("Singleton")]
    public static GameManager instance = null;

    //-----------------------------------------------------------------------------------------------
    // Scripts Managers
    //-----------------------------------------------------------------------------------------------
    [Header("Scripts")]
    public LevelManager levelManager;

    // Current scene name
    Scene currentScene;


    //-----------------------------------------------------------------------------------------------
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;

            // Get different component managers
            levelManager = GetComponent<LevelManager>();

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) //If instance already exists and it's not this:
        {
            DestroyImmediate(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }

        // Get actual scene name
        currentScene = SceneManager.GetActiveScene();
    }

    // Called at start of scene
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Called at the end of scene
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Each time a scene is loaded (called second)
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Get actual scene name
        currentScene = SceneManager.GetActiveScene();
    }

    //-----------------------------------------------------------------------------------------------
    // Update
    //-----------------------------------------------------------------------------------------------

    void Update()
    {
    }

    //-----------------------------------------------------------------------------------------------
    // Scenes
    //-----------------------------------------------------------------------------------------------

    // Carga de scenes sincrona
    public static void LoadScene(string scene)
    {
        instance.StartCoroutine(instance.levelManager.LoadSinc(scene));
        //SceneManager.LoadScene(level);
    }
    // Carga de scenes asincrona
    public static void LoadSceneAsync(string scene)
    {
        SceneManager.LoadScene(instance.levelManager.Preload, LoadSceneMode.Additive);
        instance.StartCoroutine(instance.levelManager.LoadAsync(scene));
    }

        public static void LoadRandomScene()
    {
        // Create scenes dictionary
        Dictionary<string, int> scenes =   new Dictionary<string, int>();
        string scenePrefix = "Temple";

        // Add
        for (int i = 2; i < 6; i++)
        {
            string scene = scenePrefix + i;
            
            if (scene == SceneManager.GetActiveScene().name)
            {
                // Add current scene with 0 weight
                scenes.Add(scene, 0);
            }
            else
            {
                // Add other scenes with same weight (> 0)
                scenes.Add(scene, 10);
            }

        }

        // Select random scene
        string selectedScene = RandomUtils.RandomWeighted(scenes);
        LoadSceneAsync(selectedScene);
    }

}
