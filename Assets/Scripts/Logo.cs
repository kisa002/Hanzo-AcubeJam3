using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

    Renderer renderer;

    public float alpha = 0f;

	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponent<Renderer>();

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);

        if (alpha > 1f)
            StartCoroutine(FadeOut());
        else
        {
            yield return new WaitForSeconds(0.1f);

            alpha += 0.1f;

            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);

        if (alpha < 0f)
        {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Main");
        }
        else
        {
            yield return new WaitForSeconds(0.1f);

            alpha -= 0.1f;

            StartCoroutine(FadeOut());
        }
    }
}
