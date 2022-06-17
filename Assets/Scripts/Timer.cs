using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    // Fields
    private TextMeshProUGUI timer;
    private float time = 10;

    private void Start()
    {
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
