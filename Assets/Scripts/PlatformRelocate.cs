using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRelocate : MonoBehaviour
{
    public GameObject platform;
    public int amount;

    List<GameObject> platforms;

    void Start()
    {
        platforms = new List<GameObject>();

        for (int i = 0; i < amount; i++)
        {
            GameObject go = (GameObject)Instantiate(platform);
            go.SetActive(false);
            platforms.Add(go);
        }
    }

    public GameObject getGO()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (!platforms[i].activeInHierarchy)
            {
                return platforms[i];
            }
        }

        GameObject go = (GameObject)Instantiate(platform);
        go.SetActive(false);
        platforms.Add(go);
        return go;
    }
}
