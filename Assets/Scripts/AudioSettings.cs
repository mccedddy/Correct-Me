using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider SoundEffectsVolume;
    public Slider BackgroundMusicVolume;

    private void Start()
    {
        // Load value to sliders
        SoundEffectsVolume.value = float.Parse(PlayerPrefs.GetString("SFXVolume"));
        BackgroundMusicVolume.value = float.Parse(PlayerPrefs.GetString("BGMVolume"));
    }
    private void Update()
    {
        // Set slider value to volume
        PlayerPrefs.SetString("SFXVolume", SoundEffectsVolume.value.ToString());
        PlayerPrefs.SetString("BGMVolume", BackgroundMusicVolume.value.ToString());
    }
}
