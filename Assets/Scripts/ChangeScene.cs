using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    // LoadAsync
    public void BeginLoadLevel(string sceneName)
    {
        StartCoroutine(LoadMenuAsync(sceneName));
    }
    public static IEnumerator LoadMenuAsync(string sceneName)
    {
        var progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!progress.isDone)
        {
            // Check each frame if the scene has completed
            yield return null;
        }

        // Code after this point is executed after the new scene has loaded
        SceneManager.LoadScene(sceneName);
    }
}