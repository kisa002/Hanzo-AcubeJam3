﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    GameObject pauseMenu;
    GameObject resultMenu;

	// Use this for initialization
	void Start () {
        pauseMenu = transform.FindChild("PauseMenu").gameObject;
        resultMenu = transform.FindChild("ResultMenu").gameObject;
	}
	
	// Update is called once per frame
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

    public void GoToMain()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Main");
    }
}
