using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    private string gameObjectName;
    private AudioSource audioSource;

    void Start()
    {
        gameObjectName = gameObject.name;
        audioSource = gameObject.GetComponent<AudioSource>();

        // Set default volume to 1
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetString("SFXVolume", "1");
        }
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetString("BGMVolume", "1");
        }
    }

    void Update()
    {
        // Load volume
        if (gameObjectName == "SoundEffects")
        {
            audioSource.volume = float.Parse(PlayerPrefs.GetString("SFXVolume"));
        }
        if (gameObjectName == "BackgroundMusic")
        {
            audioSource.volume = float.Parse(PlayerPrefs.GetString("BGMVolume"));
        }
    }
}
