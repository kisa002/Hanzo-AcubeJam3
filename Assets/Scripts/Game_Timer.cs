using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Timer : MonoBehaviour {

    private Text Timer;

    public int min = 5;
    public int sec = 0;

    void Start ()
    {
        Timer = GameObject.Find("Timer").GetComponent<Text>();
        StartCoroutine(Timer_minus());
    }

	void Update ()
    {
        Timer.text = (min + " : " + sec);
    }

    IEnumerator Timer_minus()
    {
        yield return new WaitForSeconds(1f);
        sec--;
        if(sec <= -1)
        {
            sec = 59;
            min--;
            if(min <= -1)
            {
                min = 0;
                StopCoroutine(Timer_minus());
            }

        }
        StartCoroutine(Timer_minus());
    }
}
