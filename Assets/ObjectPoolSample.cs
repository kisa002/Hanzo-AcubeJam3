using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolSample : MonoBehaviour
{

    // Use this for initialization
    //void Start()
    //{
    //    StartCoroutine("Shot");
    //}

    //IEnumerator Shot()
    //{
    //    string[] names = { "Bullet1", "Bullet2", "Bullet3", "Bullet4", "Bullet5" };
    //    while (true)
    //    {
    //        string name = names[Random.Range(0, 5)];
    //        GameObject obj = ObjectPoolManager.Instance.Get(name);
    //        if (obj == null)
    //        {
    //            yield return new WaitForSeconds(1);
    //            continue;
    //        }

    //        obj.transform.position = Vector3.zero;

    //        yield return new WaitForSeconds(1);
    //    }
    //}
}