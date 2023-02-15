using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreController : MonoBehaviour
{
    public GameObject level2GO;
    public Button level2;
    public GameObject level2Image;
    public GameObject level3GO;
    public Button level3;
    public GameObject level3Image;
    public GameObject level4GO;
    public Button level4;
    public GameObject level4Image;
    public GameObject level5GO;
    public Button level5;
    public GameObject level5Image;

    public static int bought2 = 0;
    public static int bought3 = 0;
    public static int bought4 = 0;
    public static int bought5 = 0;

    void Start()
    {
        level2.enabled = false;
        level3.enabled = false;
        level4.enabled = false;
        level5.enabled = false;

        bought2 = PlayerPrefs.GetInt("level2");
        bought3 = PlayerPrefs.GetInt("level3");
        bought4 = PlayerPrefs.GetInt("level4");
        bought5 = PlayerPrefs.GetInt("level5");
    }

    void Update()
    {
        if (CoinTrigger.totalCoins >= 5)
        {
            level2.enabled = true;
            level2Image.SetActive(false);
        }

        if (CoinTrigger.totalCoins >= 10)
        {
            level3.enabled = true;
            level3Image.SetActive(false);
        }

        if (CoinTrigger.totalCoins >= 15)
        {
            level4.enabled = true;
            level4Image.SetActive(false);
        }

        if (CoinTrigger.totalCoins >= 20)
        {
            level5.enabled = true;
            level5Image.SetActive(false);
        }

        if (bought2 == 1)
        {
            level2GO.SetActive(false);
        }

        if (bought3 == 1)
        {
            level3GO.SetActive(false);
        }

        if (bought4 == 1)
        {
            level4GO.SetActive(false);
        }

        if (bought5 == 1)
        {
            level5GO.SetActive(false);
        }
    }

    public void Level2UnlockButton()
    {
        bought2 = 1;
        UnlockController.level2bought = true;
        level2GO.SetActive(false);
        CoinTrigger.totalCoins = CoinTrigger.totalCoins - 5;
        CoinTrigger.Save();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        PlayerPrefs.SetInt("level2", bought2);
    }

    public void Level3UnlockButton()
    {
        bought3 = 1;
        UnlockController.level3bought = true;
        level3GO.SetActive(false);
        CoinTrigger.totalCoins = CoinTrigger.totalCoins - 10;
        CoinTrigger.Save();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        PlayerPrefs.SetInt("level3", bought3);
    }

    public void Level4UnlockButton()
    {
        bought4 = 1;
        UnlockController.level4bought = true;
        level4GO.SetActive(false);
        CoinTrigger.totalCoins = CoinTrigger.totalCoins - 15;
        CoinTrigger.Save();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        PlayerPrefs.SetInt("level4", bought4);
    }

    public void Level5UnlockButton()
    {
        bought5 = 1;
        UnlockController.level5bought = true;
        level5GO.SetActive(false);
        CoinTrigger.totalCoins = CoinTrigger.totalCoins - 20;
        CoinTrigger.Save();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        PlayerPrefs.SetInt("level5", bought5);
    }
}
