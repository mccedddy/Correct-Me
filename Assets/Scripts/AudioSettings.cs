using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider SoundEffectsVolume;
    public Slider BackgroundMusicVolume;
    public GameObject soundEffectIcon;
    public GameObject musicIcon;
    private Dictionary<string, Sprite> dictSFXSprites = new Dictionary<string, Sprite>();
    private Dictionary<string, Sprite> dictBGMSprites = new Dictionary<string, Sprite>();

    private void Start()
    {
        // Load value to sliders
        SoundEffectsVolume.value = float.Parse(PlayerPrefs.GetString("SFXVolume"));
        BackgroundMusicVolume.value = float.Parse(PlayerPrefs.GetString("BGMVolume"));

        // Load sound effect icon sprites
        Sprite[] soundEffectSprites = Resources.LoadAll<Sprite>("SoundIcon");
        foreach (Sprite soundEffectSprite in soundEffectSprites)
            dictSFXSprites.Add(soundEffectSprite.name, soundEffectSprite);

        // Load music icon sprites
        Sprite[] musicSprites = Resources.LoadAll<Sprite>("MusicIcon");
        foreach (Sprite musicSprite in musicSprites)
            dictBGMSprites.Add(musicSprite.name, musicSprite);
    }
    private void Update()
    {
        // Set slider value to volume
        PlayerPrefs.SetString("SFXVolume", SoundEffectsVolume.value.ToString());
        PlayerPrefs.SetString("BGMVolume", BackgroundMusicVolume.value.ToString());

        // Change icon sprite
        if(SoundEffectsVolume.value == 0)
        {
            soundEffectIcon.GetComponent<Image>().sprite = dictSFXSprites["SoundIcon_4"];
        }
        else
        {
            soundEffectIcon.GetComponent<Image>().sprite = dictSFXSprites["SoundIcon_0"];
        }
        if (BackgroundMusicVolume.value == 0)
        {
            musicIcon.GetComponent<Image>().sprite = dictBGMSprites["MusicIcon_1"];
        }
        else
        {
            musicIcon.GetComponent<Image>().sprite = dictBGMSprites["MusicIcon_0"];
        }
    }
}
