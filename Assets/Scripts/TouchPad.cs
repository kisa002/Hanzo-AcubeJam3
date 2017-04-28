using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour {

    GameManager gameManager;

    string answer = "";

    //char[] answer = new char[11];
    int count = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //for (int i = 1; i < 10; i++)
        //    answer[i] = '0';
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectItem(int item)
    {
        count++;

        if (count == 1)
            gameManager.answer = "";

        answer += item.ToString();

        if (count == 3)
        {
            gameManager.answer = answer;

            answer = "";

            count = 0;
        }

        //answer[item] = '1';

        //count++;

        //if (count == 3)
        //{
        //    gameManager.answer = "";

        //    for (int i = 1; i < 10; i++)
        //    {
        //        gameManager.answer += answer[i];
        //    }

        //    count = 0;
        //}
    }
}
