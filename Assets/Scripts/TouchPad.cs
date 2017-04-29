using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour {

    GameManager gameManager;
    Enemy_emergence enemy;
    Enemy_emergence2 enemy2;
    Enemy_emergence3 enemy3;
    Game_Timer GaTi;
    
    char[] answer = new char[11];
    string checkAnswer = "";

    int count = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemy = GameObject.Find("Enemy").GetComponent<Enemy_emergence>();
        enemy2 = GameObject.Find("Enemy2").GetComponent<Enemy_emergence2>();
        enemy3 = GameObject.Find("Enemy3").GetComponent<Enemy_emergence3>();

        GaTi = GameObject.Find("EventSystem").GetComponent<Game_Timer>();

        for (int i = 1; i < 10; i++)
            answer[i] = '0';
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectItem(int item)
    {
        if (count == GaTi.Checkcount)
            count = 0;

        count++;

        if (count == 1)
        {
            checkAnswer = "";
            gameManager.answer = "";

            for (int i = 1; i < 10; i++)
                answer[i] = '0';
        }

        answer[item] = '1';

        if (count == GaTi.Checkcount)
        {
            FindEnemy();

            for (int i = 1; i < 10; i++)
            {
                //gameManager.answer += answer[i];
                checkAnswer += answer[i];
                gameManager.answer = checkAnswer;
            }

            if(checkAnswer.Equals(enemy.CheckNum))
            {
                GameObject.Destroy(enemy.gameObject);

                gameManager.EnemyCre();
                gameManager.ScoreUpdate();

                FindEnemy();

                Debug.LogError("CREATE");
            }

            if (checkAnswer.Equals(enemy2.CheckNum))
            {
                GameObject.Destroy(enemy2.gameObject);

                gameManager.EnemyCre2();
                gameManager.ScoreUpdate();

                FindEnemy();

                Debug.LogError("CREATE");
            }

            if (checkAnswer.Equals(enemy3.CheckNum))
            {
                GameObject.Destroy(enemy3.gameObject);

                gameManager.EnemyCre3();
                gameManager.ScoreUpdate();

                FindEnemy();

                Debug.LogError("CREATE");
            }
            count = 0;
        }
    }

    void FindEnemy()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy_emergence>();
        enemy2 = GameObject.Find("Enemy2").GetComponent<Enemy_emergence2>();
        enemy3 = GameObject.Find("Enemy3").GetComponent<Enemy_emergence3>();
    }
}
