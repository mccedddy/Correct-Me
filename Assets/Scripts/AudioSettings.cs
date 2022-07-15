using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string EffectPref = "EffectPref";
    private float musicFloat, effectFloat;
    public AudioSource musicAudio;
    public AudioSource effectAudio;

    void Awake()
    {
        ContinueSettings();
    }
    
    private void ContinueSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        effectFloat = PlayerPrefs.GetFloat(EffectPref);
        
        musicAudio.volume = musicFloat;
        effectAudio.volume = effectFloat;
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicFloat); 
        PlayerPrefs.SetFloat(EffectPref, effectFloat); 
    }
}
