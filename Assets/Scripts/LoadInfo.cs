using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInfo : MonoBehaviour
{
    public Text coinTxt;

    public static void LoadCoinInfo()
    {
        CoinTrigger.totalCoins = PlayerPrefs.GetInt("Coins");
    }

    void Start()
    {
        LoadCoinInfo();
        CoinDisplay();
    }   

    void Update()
    {
        if (UnlockController.level2bought == true)
        {
            CoinDisplay();
        }

        if (UnlockController.level3bought == true)
        {
            CoinDisplay();
        }

        if (UnlockController.level4bought == true)
        {
            CoinDisplay();
        }

        if (UnlockController.level5bought == true)
        {
            CoinDisplay();
        }
    }

    public void CoinDisplay()
    {
        coinTxt.text = "Coins: " + CoinTrigger.totalCoins.ToString();
    }
    
}
