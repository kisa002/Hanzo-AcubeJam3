using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;

    //분.초.
    float min = 0;
    float sec = 0;

    Coroutine co_timer;
    bool bStart = false;


    void Awake()
    {
        timerText = GetComponent<Text>();
    }
    
    public void StartTimer()
    {
        bStart = true;
        timerText.text = "" + min + ":" + sec;
    }

    void Update()
    {
        if(bStart)
        {
            sec += Time.deltaTime;
            if (sec >= 60)
            {
                sec = 0;
                min++;
            }
            timerText.text = string.Format("{0:N0}", min) + string.Format("{0:N3}", sec);
        }
    }


    public void StopTimer()
    {
        bStart = false;
    }

    public int GetTime()
    {
        return (int)(min * 60) + (int)sec;
    }
}
