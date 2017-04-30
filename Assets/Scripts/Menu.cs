using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject bgObject;

    public GameObject pauseMenu;
    public GameObject resultMenu;
    public GameObject black;
    public Text TimeText;
    public Text ScoreText;
	
    public void onResult(int resultsec, int score)
    {
        black.SetActive(true);
        resultMenu.SetActive(true);
        int min = (int)(resultsec / 60f);
        int sec = (int)(resultsec % 60f);

        TimeText.text = "" + min + "분" + " " + sec + "초";
        ScoreText.text = score + "점";
    }

    public void Stop()
    {
        black.SetActive(true);
        pauseMenu.SetActive(true);

        bgObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        black.SetActive(false);
        pauseMenu.SetActive(false);

        bgObject.SetActive(true);

        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");

    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

}
