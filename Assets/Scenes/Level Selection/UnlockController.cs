using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockController : MonoBehaviour
{
    public Button level2;
    public GameObject level2Image;
    public Button level3;
    public GameObject level3Image;
    public Button level4;
    public GameObject level4Image;
    public Button level5;
    public GameObject level5Image;

    public GameObject level2Txt;
    public GameObject level3Txt;
    public GameObject level4Txt;
    public GameObject level5Txt;

    public static bool level2bought = true;
    public static bool level3bought = true;
    public static bool level4bought = true;
    public static bool level5bought = true; // unlocked by default

    void Start()
    {
        level2.enabled = false;
        level3.enabled = false;
        level4.enabled = false;
        level5.enabled = false;

        if (StoreController.bought2 == 1)
        {
            level2bought = true;
        }

        if (StoreController.bought3 == 1)
        {
            level3bought = true;
        }

        if (StoreController.bought4 == 1)
        {
            level4bought = true;
        }
        if (StoreController.bought5 == 1)
        {
            level5bought = true;
        }
    }

    void Update()
    {
        if (level2bought)
        {
            level2.enabled = true;
            level2Txt.SetActive(true);
            level2Image.SetActive(false);
        }

        if (level3bought)
        {
            level3.enabled = true;
            level3Txt.SetActive(true);
            level3Image.SetActive(false);
        }

        if (level4bought)
        {
            level4.enabled = true;
            level4Txt.SetActive(true);
            level4Image.SetActive(false);
        }

        if (level5bought)
        {
            level5.enabled = true;
            level5Txt.SetActive(true);
            level5Image.SetActive(false);
        }
    }
}
