using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public struct monsterSlot
{
    public bool bIsOn;
    public Vector3 slotPos;
    public GameObject monsterObj;
}

public class GameManager : Singleton<GameManager>
{
    public GameObject canvas;
    public GameObject BackGroundObject;

    public GameObject pf_fxDie;

    public GameObject EnemyPrefab = null;

    public int score = 0;

    public Text scoreText;
    public Menu menu;
    public Timer timer;

    public GameObject StartUI;
    public GameObject TouchPad;

    int levelCount = 3;
    float monsterCreateTime = 1.8f;

    public monsterSlot[] enemyList = new monsterSlot[3];

    Coroutine monsterCreateCo;
    //레벨 로드될때 초기화 하기.
    public void OnLevelWasLoaded(int level)
    {
        //Debug.Log("OnlevelLoaded");
        if (monsterCreateCo != null)
            StopCoroutine(monsterCreateCo);

    }

    public void MonsterListClear()
    {
        for (int i = 0; i < enemyList.Length; i++)
        {
            enemyList[i].bIsOn = false;
            enemyList[i].monsterObj = null;
            enemyList[i].slotPos = new Vector3(-1.5f + (i * 2), 0, 0);
        }
    }

    // Use this for initialization
    IEnumerator Start()
    {
        yield return StartCoroutine(WaitStartLogo());
        monsterCreateCo = StartCoroutine(MonsterCreate());
        timer.StartTimer();

        score = 0;
        scoreText.text = score + "";

        MonsterListClear();

        StartUI.SetActive(false);
        BackGroundObject.SetActive(true);
        TouchPad.GetComponent<TouchPad>().SetStart();

        Screen.SetResolution(1080, 1920, true);
    }

    IEnumerator WaitStartLogo()
    {
        yield return new WaitForSeconds(3.0f);
    }

    IEnumerator MonsterCreate()
    {
        //CreateEnemy(levelCount);

        while (true)
        {
            yield return new WaitForSeconds(monsterCreateTime);

            //Debug.Log("Create" + monsterCreateTime);

            //생성시에 슬롯체크 및 목표장소 설정
            for (int i = 0; i < enemyList.Length; i++)
            {
                if (enemyList[i].bIsOn == false)
                {
                    enemyList[i].bIsOn = true;
                    enemyList[i].monsterObj = CreateEnemy(levelCount, enemyList[i].slotPos);
                    break;
                }
            }
        }
    }



    public void Dead()
    {
        Vector3 exPos = transform.position;
        exPos.x = -1.5f;
        exPos.y += 3;

        exPos.z = -5;
        //Vector3 exPos = Camera.main.WorldToScreenPoint(transform.position);
        Destroy(Instantiate(pf_fxDie, exPos, Quaternion.identity, transform), 2.0f);
        SoundManager.Instance.PlaySFX("BombFx");
        int time = timer.GetTime();
        timer.StopTimer();

        if (monsterCreateCo != null)
            StopCoroutine(monsterCreateCo);

        BackGroundObject.SetActive(false);
        menu.onResult(time, score);

    }


    //void AnswerText()
    //{
    //    answerText.text = answer;
    //}

    public GameObject CreateEnemy(int _levelCount, Vector3 _pos)
    {
        GameObject Enemy = Instantiate(EnemyPrefab, new Vector2(4, 1f), Quaternion.identity) as GameObject;
        Enemy.GetComponent<Enemy>().SetTargetPos(_pos);
        Enemy.GetComponent<Enemy>().CreateCube(_levelCount);
        return Enemy;
    }

    //죽였으면 패턴인식기 배열 초기화 하기위한 return.
    public bool CheckHit(int[] _inputs, int _nowPadNo)
    {
        int count = 0;

        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i].bIsOn == false) continue;

            //하나라도 맞았는가.
            if (enemyList[i].monsterObj.GetComponent<Enemy>().IsOneHit(_nowPadNo))
            {
                count++;

                //죽을놈 죽기.
                if (enemyList[i].monsterObj.GetComponent<Enemy>().IsKill(_inputs))
                {
                    //몬스터 죽음.
                    ShakeCamera();


                    //CreateEnemy(levelCount);

                    return true;
                }
            }
        }

        //하나도 안맞음.
        if (count == 0)
        {
            //몬스터 전체가 폭발.

            for (int i = 0; i < enemyList.Length; i++)
            {
                if (enemyList[i].bIsOn == false) continue;

                enemyList[i].monsterObj.GetComponent<Enemy>().MonsterBomb();
            }

            Debug.Log("GameOver");
            //게임오버.
            Dead();

            return true;
        }

        return false;
    }


    public void RemoveThisObjectInList(GameObject obj)
    {
        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i].monsterObj == obj)
            {
                enemyList[i].bIsOn = false;
            }
        }
    }

    public void ShakeCamera()
    {
        Camera.main.GetComponent<Shake>().SetShake();
    }

    public void ScoreUp()
    {
        score += 10;
        if (score == 100)
        {
            levelCount++;
            monsterCreateTime -= 0.15f;
        }
        else if (score == 200)
        {
            levelCount++;
            monsterCreateTime -= 0.15f;
        }
        else if (score == 300)
        {
            levelCount++;
            monsterCreateTime -= 0.15f;
        }
        else if (score > 400)
        {
            levelCount++;
            monsterCreateTime -= 0.15f;

        }
        scoreText.text = score + "";

    }
}
