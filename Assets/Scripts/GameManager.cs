using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int hp = 5;
    public int score = 0;

    private Text scoreText;
    private Menu menu;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        menu = GameObject.Find("Menu").GetComponent<Menu>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score + "점";

        ScoreUp(100);

        Dead();
	}

    void Dead()
    {
        if(hp <= 0)
            menu.onResult();
    }

    void ScoreUp(int score)
    {
        if (Input.GetKeyDown(KeyCode.A))
            this.score += score;
    }
}
