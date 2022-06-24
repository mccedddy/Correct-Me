using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScoreResult : MonoBehaviour
{
    // Fields
    public TextMeshProUGUI LevelScore;
    void Start()
    {
        LevelScore.text = PlayerPrefs.GetString("Level") + "\nScore: " + PlayerPrefs.GetInt("Score"); 
    }
}
