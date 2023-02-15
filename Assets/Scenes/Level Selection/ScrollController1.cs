using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollController1 : MonoBehaviour
{
    public GameObject scrollbar;
    private float scrollpos = 0;
    float[] pos;

    void Start()
    {

    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            scrollpos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollpos < pos[i] + (distance / 2) && scrollpos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollpos < pos[i] + (distance / 2) && scrollpos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    public void BackButton()
    {
        StartCoroutine(BackButtonDelay());
    }

    IEnumerator BackButtonDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        StartCoroutine(Level1Delay());
    }

    IEnumerator Level1Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        StartCoroutine(Level2Delay());
    }

    IEnumerator Level2Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        StartCoroutine(Level3Delay());
    }

    IEnumerator Level3Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }
    public void Level4()
    {
        StartCoroutine(Level4Delay());
    }

    IEnumerator Level4Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(5);
    }

    public void Level5()
    {
        StartCoroutine(Level5Delay());
    }

    IEnumerator Level5Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(6);
    }
}
