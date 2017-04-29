﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour {

    GameManager gameManager;
    Enemy_emergence enemy;
    
    char[] answer = new char[11];
    string checkAnswer;

    int count = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy_emergence>();

        for (int i = 1; i < 10; i++)
            answer[i] = '0';
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectItem(int item)
    {
        if (count == 3)
            count = 0;
        count++;

        if (count == 1)
        {
            gameManager.answer = "";

            for (int i = 1; i < 10; i++)
                answer[i] = '0';
        }

        answer[item] = '1';

        if (count == 3)
        {
            for (int i = 1; i < 10; i++)
            {
                //gameManager.answer += answer[i];
                checkAnswer += answer[i];
                gameManager.answer = checkAnswer;
            }

            if (checkAnswer.Equals(enemy.CheckNum)) // 몬스터 삭제!
            {
                GameObject.Destroy(enemy.gameObject);
                gameManager.EnemyCre();
            }
                

            count = 0;
        }
    }
}
