using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    GameObject pauseMenu;
    GameObject resultMenu;

    private void OnLevelWasLoaded(int level)
    {
        if(level != 0)
        {
            //pauseMenu = transform.FindChild("PauseMenu").gameObject;
            //resultMenu = transform.FindChild("ResultMenu").gameObject;
        }
    }

    void Start () {
        pauseMenu = transform.FindChild("PauseMenu").gameObject;
        resultMenu = transform.FindChild("ResultMenu").gameObject;
	}
	
	void Update () {
		
	}

    public void onResult()
    {
        resultMenu.SetActive(true);
    }

    public void Stop()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void LoadMain()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Main");
    }

    public void GameStart()
    {
        Application.LoadLevel("Game");
    }

    public void LoadShop()
    {
        Application.LoadLevel("Shop");
    }
}
