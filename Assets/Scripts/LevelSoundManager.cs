using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSoundManager : MonoBehaviour
{
    private static LevelSoundManager LevelSoundManagerInstance;

    void Update()
    {
        // Stop music in main menu
        if (SceneManager.GetActiveScene().name == "MainMenu" ||
            SceneManager.GetActiveScene().name == "LevelScreen")
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        // Dont destroy music on switching scenes
        DontDestroyOnLoad(transform.gameObject);

        if (LevelSoundManagerInstance == null)
        {
            LevelSoundManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
