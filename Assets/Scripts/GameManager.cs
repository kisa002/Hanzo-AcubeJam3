using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score;

    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score + "점";

        ScoreUp();
	}

    void ScoreUp()
    {
        if(Input.GetKeyDown(KeyCode.A))
            score += 100;
    }
}
