using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redy : MonoBehaviour {

    GameObject enemy;
    GameObject timer;
    GameObject eventSystem;
    GameObject touchpad;

	// Use this for initialization
	void Start () {

        touchpad = GameObject.Find("Touchpad");
        enemy = GameObject.Find("Enemy");
        timer = GameObject.Find("Timer");
        eventSystem = GameObject.Find("EventSystem");

        //touchpad.SetActive(false);
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
        //touchpad.SetActive(true);

        Destroy(this.gameObject);
    }
}
