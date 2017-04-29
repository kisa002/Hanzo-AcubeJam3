﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject EnemyPrefab = null;

    public string answer = "";
    public string[] checkNum = new string[5];

    public int hp = 5;
    public int score = 0;

    public bool isRead = true;


    private Text scoreText;
    private Text answerText;

    private Menu menu;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        answerText = GameObject.Find("AnswerText").GetComponent<Text>();

        menu = GameObject.Find("Menu").GetComponent<Menu>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score + "점";

        Dead();
    }

    public void ScoreUpdate()
    {
        AnswerText();

        ScoreUp(100);

        //Dead();
    }

    void Dead()
    {
        if (hp <= 0)
            menu.onResult();
    }

    void ScoreUp(int score)
    {
        this.score += score;
    }

    void AnswerText()
    {
        answerText.text = answer;
    }

    public void EnemyCre()
    {
        Instantiate(EnemyPrefab, new Vector2(4, 2), Quaternion.identity);
    }
}
