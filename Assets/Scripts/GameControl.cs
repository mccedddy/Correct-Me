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
    private Dictionary<string, Sprite> dictSprites = new Dictionary<string, Sprite>();
    List<string> wordList;

    private void Start()
    {
        // Load sprites
        Sprite[] sprites = Resources.LoadAll<Sprite>("UI");
        foreach (Sprite sprite in sprites)
            dictSprites.Add(sprite.name, sprite);

        // Set required score, word list to be used and playerprefs level
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            wordList = Words.wordList1;
            scoreRequired = 10;
            PlayerPrefs.SetString("Level", "Level 1");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            wordList = Words.wordList2;
            scoreRequired = 20;
            PlayerPrefs.SetString("Level", "Level 2");
        }
        else
        {
            wordList = Words.wordList3;
            scoreRequired = 30;
            PlayerPrefs.SetString("Level", "Level 3");
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
            if(correctAnswer == "button1") // Change sprite and load next word
            {
                button1.GetComponent<Image>().sprite = dictSprites["UI_2"];
                if (!nextWordStarted)
                {
                    StartCoroutine("NextWord");
                    nextWordStarted = true;
                }
            }
            else // Defeat
            {
                if (!indexAdded) // Change sprite and load defeat screen
                {
                    button1.GetComponent<Image>().sprite = dictSprites["UI_5"];
                    StartCoroutine("Defeat");
                    indexAdded = true;
                }
            }
            // Disable button
            button1.interactable = false;
        });

        // Button 2
        button2.onClick.AddListener(() =>
        {
            if (correctAnswer == "button2") // Change sprite and load next word
            {
                button2.GetComponent<Image>().sprite = dictSprites["UI_2"];
                if (!nextWordStarted)
                {
                    StartCoroutine("NextWord");
                    nextWordStarted = true;
                }
            }
            else // Defeat
            {
                if (!indexAdded) // Change sprite and load defeat screen
                {
                    button2.GetComponent<Image>().sprite = dictSprites["UI_5"];
                    StartCoroutine("Defeat");
                    indexAdded = true;
                }
            }
            // Disable button
            button2.interactable = false;
        });

        // Change score display and set playerprefs score
        scoreDisplay.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);

        indexAdded = false;
        nextWordStarted = false;
    }
    private IEnumerator NextWord()
    {
        // Wait 0.5 second
        yield return new WaitForSeconds(0.5f);

        // Add score
        score += 1;

        // Set playerprefs score
        PlayerPrefs.SetInt("Score", score);

        // Return sprites to default
        button1.GetComponent<Image>().sprite = dictSprites["UI_1"];
        button2.GetComponent<Image>().sprite = dictSprites["UI_1"];

        // Activate buttons
        button1.interactable = true;
        button2.interactable = true;

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
    private IEnumerator Defeat()
    {
        // Wait 0.5 second
        yield return new WaitForSeconds(0.5f);

        // Load defeat screen
        SceneManager.LoadScene("Defeat");
    }
}
