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
    private int currentWordIndex = 0;
    private int situation;
    private string correctAnswer;
    private bool indexAdded = false;
    private int scoreRequired = 10;
    private bool nextWordStarted = false;
    List<string> wordList;

    private void Start()
    {
        // Set required score and word list to be used
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            wordList = Words.wordList1;
            scoreRequired = 10;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            wordList = Words.wordList2;
            scoreRequired = 20;
        }
        else
        {
            wordList = Words.wordList3;
            scoreRequired = 30;
        }

        // Randomize answer position
        situation = Random.Range(0, 2);
    }
    void Update()
    {
        // Randomize answer position
        if (situation == 0)
        {
            button1text.text = wordList[currentWordIndex];
            button2text.text = wordList[currentWordIndex + 1];
            correctAnswer = "button1";
        }
        else
        {
            button1text.text = wordList[currentWordIndex + 1];
            button2text.text = wordList[currentWordIndex];
            correctAnswer = "button2";
        }
        definition.text = wordList[currentWordIndex + 2];

        // Button 1
        button1.onClick.AddListener(() =>
        {
            if(correctAnswer == "button1")
            {
                if (!nextWordStarted)
                {
                    StartCoroutine("NextWord");
                    nextWordStarted = true;
                }
            }
            else
            {
                if (!indexAdded)
                {
                    SceneManager.LoadScene("Defeat");
                    indexAdded = true;
                }
            }
        });

        // Button 2
        button2.onClick.AddListener(() =>
        {
            if (correctAnswer == "button2")
            {
                if (!nextWordStarted)
                {
                    StartCoroutine("NextWord");
                    nextWordStarted = true;
                }
            }
            else
            {
                if (!indexAdded)
                {
                    SceneManager.LoadScene("Defeat");
                    indexAdded = true;
                }
            }
        });

        // Change score display
        scoreDisplay.text = "Score: " + score.ToString();

        indexAdded = false;
        nextWordStarted = false;
    }
    private IEnumerator NextWord()
    {
        // Wait 1 second
        yield return new WaitForSeconds(0.5f);

        // Add score
        score += 1;

        // Winning condition
        if (score == scoreRequired)
        {
            SceneManager.LoadScene("Victory");
        }
        else // Move index
        {
            currentWordIndex += 3;
        }

        // Randomize position
        situation = Random.Range(0, 2);
        Debug.Log("Next!");
    }
}
