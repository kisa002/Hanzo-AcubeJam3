using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPad : MonoBehaviour {

    GameManager gameManager;
    Enemy_emergence enemy;
    Game_Timer gaTi;
    
    char[] answer = new char[11];
    string checkAnswer = "";

    int count = 0;

    bool use = false;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //enemy = GameObject.Find("Enemy").GetComponent<Enemy_emergence>();

        //gaTi = GameObject.Find("EventSystem").GetComponent<Game_Timer>();

        //for (int i = 1; i < 10; i++)
        //    answer[i] = '0';
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.isRead)
            gameStart();
	}

    void gameStart()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy_emergence>();

        gaTi = GameObject.Find("EventSystem").GetComponent<Game_Timer>();

        GaTi();

        for (int i = 1; i < 10; i++)
            answer[i] = '0';
    }

    IEnumerator GaTi()
    {
        yield return new WaitForSeconds(1f);

        gaTi = GameObject.Find("EventSystem").GetComponent<Game_Timer>();
    }

    public void SelectItem(int item)
    {
        if (count == gaTi.Checkcount)
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

        if (count == gaTi.Checkcount)
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
            count = 0;
        }
    }

    void FindEnemy()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy_emergence>();
    }
}
