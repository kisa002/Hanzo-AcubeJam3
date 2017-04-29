using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redy : MonoBehaviour {

    GameManager gameManager;

    GameObject enemy;
    GameObject timer;
    GameObject eventSystem;
    GameObject touchpad;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        touchpad = GameObject.Find("Touchpad");
        enemy = GameObject.Find("Enemy");
        timer = GameObject.Find("Timer");
        eventSystem = GameObject.Find("EventSystem");

        eventSystem.SetActive(false);
        enemy.SetActive(false);
        timer.SetActive(false);
        
        StartCoroutine(Ready());
	}

    IEnumerator Ready()
    {
        yield return new WaitForSeconds(3f);

        enemy.SetActive(true);
        timer.SetActive(true);
        eventSystem.SetActive(true);

        gameManager.isRead = false;

        Destroy(this.gameObject);
    }
}
