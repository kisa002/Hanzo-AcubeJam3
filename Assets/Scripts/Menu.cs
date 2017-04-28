using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    GameObject pauseMenu;

	// Use this for initialization
	void Start () {
        pauseMenu = transform.FindChild("PauseMenu").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
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
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
