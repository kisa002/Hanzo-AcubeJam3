using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;

public class Enemy_emergence : MonoBehaviour
{

    GameObject Cube1;
    GameObject Cube2;
    GameObject Cube3;
    GameObject Cube4;
    GameObject Cube5;
    GameObject Cube6;
    GameObject Cube7;
    GameObject Cube8;
    GameObject Cube9;

    public String CheckNum;

    public int CheckCount = 3;

    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Cube1 = transform.FindChild("Cube1").gameObject;
        Cube2 = transform.FindChild("Cube2").gameObject;
        Cube3 = transform.FindChild("Cube3").gameObject;
        Cube4 = transform.FindChild("Cube4").gameObject;
        Cube5 = transform.FindChild("Cube5").gameObject;
        Cube6 = transform.FindChild("Cube6").gameObject;
        Cube7 = transform.FindChild("Cube7").gameObject;
        Cube8 = transform.FindChild("Cube8").gameObject;
        Cube9 = transform.FindChild("Cube9").gameObject;

        this.gameObject.name = "Enemy";
    }

    int check = 0;
    void Update()
    {
        if (transform.position.x > -1.6)
        {
            this.transform.Translate(new Vector3(-0.1f, 0, 0));

        }
        else if (transform.position.x <= -1.6 && check == 0)
        {
            check += 1;
            asdfasdf();
        }
    }

    public void asdfasdf()
    {
        int[] RandNum = new int[CheckCount];
        for (int i = 0; i < RandNum.Length; i++)
        {

            RandNum[i] = UnityEngine.Random.Range(1, 10);

            for (int j = 0; j < i; j++)
            {
                if (RandNum[i] == RandNum[j])
                {
                    i--;
                    break;
                }
            }
        }
        int temp = 0;
        for (int j = 0; j < RandNum.Length; j++)
        {
            for (int k = 0; k < 2; k++)
            {
                if (RandNum[k] > RandNum[k + 1])
                {
                    temp = RandNum[k];
                    RandNum[k] = RandNum[k + 1];
                    RandNum[k + 1] = temp;
                }
            }
        }
        int tempp = 0;
        for (int i = 1; i < 10; i++)
        {
            if (RandNum[tempp] == i)
            {
                if (tempp <= RandNum.Length - 2)
                    tempp += 1;
                CheckNum += 1;
            }
            else
                CheckNum += 0;
        }
        temp = 0;
        Debug.Log(CheckNum);

        //gameManager.checkNum[0] = CheckNum;

        for (int i = 0; i < RandNum.Length; i++)
        {
            if (RandNum[i] == 1)
            {
                Cube1.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 2)
            {
                Cube2.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 3)
            {
                Cube3.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 4)
            {
                Cube4.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 5)
            {
                Cube5.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 6)
            {
                Cube6.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 7)
            {
                Cube7.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 8)
            {
                Cube8.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (RandNum[i] == 9)
            {
                Cube9.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
