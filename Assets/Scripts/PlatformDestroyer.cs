using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestroyer;

    void Start()
    {
        platformDestroyer = GameObject.Find("PlatformDestroyer");
    }

    void Update()
    {
        if (transform.position.x < platformDestroyer.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
