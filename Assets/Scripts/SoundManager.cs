using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager SoundManagerInstance;

    void Update()
    {
        // If level starts, stop menu music
        if (SceneManager.GetActiveScene().name == "Level1" ||
            SceneManager.GetActiveScene().name == "Level2" ||
            SceneManager.GetActiveScene().name == "Level3")
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
        // Dont destroy music on switching scenes
        DontDestroyOnLoad(transform.gameObject);

        if (SoundManagerInstance == null)
        {
            SoundManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
