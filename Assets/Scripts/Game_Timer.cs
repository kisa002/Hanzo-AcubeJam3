using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Timer : MonoBehaviour {

    private Text Timer;

    public int min = 1;
    public int sec = 3;

    public Enemy_emergence Encount;

    void Start ()
    {
        Timer = GameObject.Find("Timer").GetComponent<Text>();
        StartCoroutine(Timer_minus());
        Encount = GameObject.Find("EventSystem").GetComponent<Enemy_emergence>();
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
                Encount.CheckCount = 3;
                StopCoroutine(Timer_minus());
            }
        }
        if(min == 1 && sec == 30)
        {
            Encount.CheckCount = 4;
        }
        if(min == 1 && sec == 0)
            Encount.CheckCount = 5;
        if (min == 0 && sec == 30)
            Encount.CheckCount = 6;
        StartCoroutine(Timer_minus());
    }
}
