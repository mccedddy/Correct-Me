using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    // Fields
    private TextMeshProUGUI timer;
    private float time = 60;

    private void Start()
    {
        // Set time per level
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            time = 30;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            time = 45;
        }
        else
        {
            time = 60;
        }

        // Set timer
        timer = gameObject.transform.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        float timeRounded;
        // Time decreases per second
        time -= 1 * Time.deltaTime;
        timeRounded = Mathf.Round(time);
        timer.text = "Time: " + timeRounded.ToString();

        // When timer runs out
        if(timeRounded == 0)
        {
            Debug.Log("You Lose");
            SceneManager.LoadScene("Defeat");
        }
    }
}
