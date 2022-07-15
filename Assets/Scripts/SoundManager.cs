using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string EffectPref = "EffectPref";
    private int firstPlayInt;
    public Slider musicSlider, effectSlider;
    private float musicFloat, effectFloat;
    public AudioSource musicAudio;
    public AudioSource effectAudio;

    // Start is called before the first frame update
    void Start()
    {        
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            //Initial audio settings
            musicFloat = .125f;
            effectFloat = .100f;
            musicSlider.value = musicFloat;
            effectSlider.value = effectFloat;

            //Save values that last through different scenes
            PlayerPrefs.SetFloat(MusicPref, musicFloat); 
            PlayerPrefs.SetFloat(EffectPref, effectFloat); 
            
            //Use initial value one time
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            //Pull the user's audio preferences
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            effectFloat = PlayerPrefs.GetFloat(EffectPref);
            effectSlider.value = effectFloat;
        }
    }

    //Save the user's audio preferences
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value); 
        PlayerPrefs.SetFloat(EffectPref, effectSlider.value); 
    }

    //Save the audio settings automatically
    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }
    
    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;
        effectAudio.volume = effectSlider.value;
    }
}
