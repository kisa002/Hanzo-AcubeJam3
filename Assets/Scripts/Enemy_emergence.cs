using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_emergence : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
    }

    // Update is called once per frame
    private int count = 0;

	void Update ()
    {
        StartCoroutine(Enemy_move());
    }

    IEnumerator Enemy_move()
    {
        yield return new WaitForSeconds(0.1f);

        if(count >= 500)
        {

        }
        else
        {
            count += 1;
            this.transform.Translate(new Vector3(-0.01f, 0, 0));
        }   

        StartCoroutine(Enemy_move());
    }
}
