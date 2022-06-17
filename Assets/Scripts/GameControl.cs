using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Fields
    public Button button1;
    public Button button2;
    public TextMeshProUGUI button1text;
    public TextMeshProUGUI button2text;
    public TextMeshProUGUI definition;
    public TextMeshProUGUI scoreDisplay;
    private int score = 0;

    void Update()
    {
        // Winning condition
        if (score == 10)
            SceneManager.LoadScene("Victory");

        button1text.text = Words.wordList1[0];
        button2text.text = Words.wordList1[1];
        definition.text = Words.wordList1[2];
    }
}
