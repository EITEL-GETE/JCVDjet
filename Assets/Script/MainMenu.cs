using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        StopCoroutine(ChangeScene());
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        StartCoroutine(ChangeScene());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainScene");
    }
}
