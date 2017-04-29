using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Timer : MonoBehaviour {

    private Text Timer;

    public int min = 2;
    public int sec = 1;

    public int Checkcount = 3;

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
        if(min == 2)
        {
            Checkcount = 3;
        }
        if(min == 1)
        {
            if(sec == 30)
            {
                Checkcount = 4;
            }
            if (sec == 0)
                Checkcount = 5;
        }
        if(min == 0)
        {
            if (sec == 30)
                Checkcount = 6;
        }

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
