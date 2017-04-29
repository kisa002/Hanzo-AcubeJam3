using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redy : MonoBehaviour {

    GameManager gameManager;

    GameObject enemy;
    GameObject enemy2;
    GameObject enemy3;

    GameObject timer;
    GameObject eventSystem;
    GameObject touchpad;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        touchpad = GameObject.Find("Touchpad");
        enemy = GameObject.Find("Enemy");
        enemy2 = GameObject.Find("Enemy2");
        enemy3 = GameObject.Find("Enemy3");

        timer = GameObject.Find("Timer");
        eventSystem = GameObject.Find("EventSystem");

        eventSystem.SetActive(false);
        enemy.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        timer.SetActive(false);
        
        StartCoroutine(Ready());
	}

    IEnumerator Ready()
    {
        yield return new WaitForSeconds(3f);

        enemy.SetActive(true);
        enemy2.SetActive(true);
        enemy3.SetActive(true);

        timer.SetActive(true);
        eventSystem.SetActive(true);

        gameManager.isRead = false;

        Destroy(this.gameObject);
    }
}
