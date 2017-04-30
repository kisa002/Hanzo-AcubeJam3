using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image img_BombGage;
    float fBombTime = 3.5f;
    float fMaxBombTime = 3.5f;    
    public GameObject pf_Cube;

    GameObject[] Cubes;
    Transform cube_holder;

    public GameObject pf_Explosion;
    Vector3 targetPos;


    int[] arrPatterns = new int[9];
    float offsetX = 3.4f;
    float offsetY = 4.5f;
    void Awake()
    {
        Cubes = new GameObject[9];
        cube_holder = new GameObject("holder").transform;
        cube_holder.parent = gameObject.transform;
        cube_holder.localPosition = new Vector3(0, 0, 0);
        cube_holder.localScale = new Vector3(1, 1, 1);

        for( int i = 0; i < arrPatterns.Length; i++ )
        {
            arrPatterns[i] = 0;
        }

        fMaxBombTime = 3.5f;
    }

    void Update()
    {
        if (transform.position.x > targetPos.x)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }

        fBombTime -= Time.deltaTime;

        img_BombGage.fillAmount = fBombTime / fMaxBombTime;

        if( fBombTime <= 0.0f)
        {
            //시간이 다 되도 폭발.
            MonsterBomb();
        }
    }

    public void MonsterBomb()
    {
        //폭발
        SoundManager.Instance.PlaySFX("BombFx");
        GameManager.Instance.ShakeCamera();
        GameManager.Instance.RemoveThisObjectInList(gameObject);
        Destroy(Instantiate(pf_Explosion, transform.position, Quaternion.identity, transform), 1.0f);
        DestroyObject(gameObject);


        GameManager.Instance.Dead();

    }


    public void SetTargetPos(Vector3 _pos)
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        targetPos = _pos;
    }


    public void CreateCube(int _redCount)
    {
        int count = 0;

        Vector3 pos = cube_holder.transform.position;
        pos.x = offsetX;
        pos.y = offsetY;

        for ( int i = 0; i < 9; i++ )
        {
            //offset move
            if (i % 3 == 0)
            {
                pos.x = offsetX;
                pos.y -= 0.6f;
            }

            Cubes[i] = Instantiate(pf_Cube, pos, Quaternion.identity, cube_holder) as GameObject;
            Cubes[i].transform.localScale = new Vector3(9, 9, 0);

            //offset move
            pos.x += 0.6f;

            //red pannel create
            int randIndex = Random.Range(0, 2);
            if (randIndex == 1)
            {
                if (count < _redCount)
                {
                    //레드패드로 지정.
                    count++;
                    arrPatterns[i] = 1;
                    Cubes[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                arrPatterns[i] = 0;
                Cubes[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if( count == 0)
        {
            int randIndex = Random.Range(0, 9);
            count++;
            arrPatterns[randIndex] = 1;
            Cubes[randIndex].GetComponent<SpriteRenderer>().color = Color.red;

        }
    }


    public bool IsKill(int[] _pattern)
    {
        for( int i = 0; i < 9; i++ )
        {
            if( arrPatterns[i] != _pattern[i] )
            {
                //Debug.Log("Dont Kill Yet");

                //하나라도 틀렸다면.
                return false;
            }
        }

        ////모든게 다 맞았따. 몬스터 죽음.
        //GameManager.Instance.enemyList.Remove(gameObject);

        //DestroyImmediate(gameObject);
        ////Debug.Log("Monster Kill");

        SoundManager.Instance.PlaySFX("BombFx");
        GameManager.Instance.ShakeCamera();
        GameManager.Instance.RemoveThisObjectInList(gameObject);
        Vector3 explosionPos = transform.position;
        explosionPos.y += 2.0f;

        Destroy(Instantiate(pf_Explosion, explosionPos, Quaternion.identity), 1.0f);
        DestroyObject(gameObject);

        //점수상승.
        GameManager.Instance.ScoreUp();
        return true;
    
    }

    //이번히트가 적중에 하나라도 맞는 부위가 있는 히트인가.
    public bool IsOneHit(int _nowPadNo)
    {
        if (arrPatterns[_nowPadNo] == 1)
        {
            //해당곳이 빨강이라면.
            //Debug.Log("One Hit");
            return true;
        }

        //잘못된곳이라면.
        //Debug.Log("All Fail");

        //하나도 안맞음 실패.
        return false;
    }


}
