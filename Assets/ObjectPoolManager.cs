using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트 풀 클래스
/// </summary>
public class ObjectPool
{
    public GameObject source;
    public int maxAmount;           // 풀의 오브젝트 개수
    public GameObject folder;       // 하이라키에서 구별을 위한 빈오브젝트

    public List<GameObject> unusedList = new List<GameObject>();    // 미사용 오브젝트 리스트     
}

/// <summary>
/// 오브젝트 풀 매니저 싱글톤
/// </summary>
public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public int defaultAmount = 10;
    public GameObject[] poolList;
    public int[] poolAmount;

    Dictionary<string, ObjectPool> objectPoolList = new Dictionary<string, ObjectPool>();

    // Use this for initialization
    void Start()
    {
        StartCoroutine("InitObjectPool");
    }


    IEnumerator InitObjectPool()
    {
        for (int i = 0; i < poolList.Length; i++)
        {
            ObjectPool objectPool = new ObjectPool();
            objectPool.source = poolList[i];
            objectPoolList[poolList[i].name] = objectPool;

            // 하이라키에 추가한다 
            GameObject folder = new GameObject();
            folder.name = poolList[i].name;
            folder.transform.parent = this.transform;
            objectPool.folder = folder;

            int amount = defaultAmount;
            if (poolAmount.Length > i && poolAmount[i] != 0)
                amount = poolAmount[i];

            for (int j = 0; j < amount; j++)
            {
                GameObject inst = Instantiate(objectPool.source);
                inst.SetActive(false);
                inst.transform.parent = folder.transform;
                objectPool.unusedList.Add(inst);

                // 한번에 풀을 생성할때의 부하를 줄이기 위해서 코루틴을 사용한다
                yield return new WaitForEndOfFrame();
            }
            objectPool.maxAmount = amount;
        }
    }

    public GameObject Get(string name)
    {
        if (!objectPoolList.ContainsKey(name))
        {
            Debug.Log("[ObjectPoolManager] Can't Find ObjectPool! - " + name);
            return null;
        }

        ObjectPool pool = objectPoolList[name];
        if (pool.unusedList.Count > 0)
        {
            GameObject obj = pool.unusedList[0];
            pool.unusedList.RemoveAt(0);
            obj.SetActive(true);
            return obj;
        }
        else // 사용 가능한 오브젝트가 없을때
        {
            GameObject obj = Instantiate(pool.source);
            obj.transform.parent = pool.folder.transform;
            return obj;
        }
    }

    public void Free(GameObject obj)
    {
        string keyName = obj.transform.parent.name;
        if (!objectPoolList.ContainsKey(keyName))
        {
            Debug.Log("[ObjectPoolManager] Can't Find Free ObjectPool! - " + name);
            return;
        }

        ObjectPool pool = objectPoolList[keyName];
        obj.SetActive(false);
        pool.unusedList.Add(obj);
    }
}
