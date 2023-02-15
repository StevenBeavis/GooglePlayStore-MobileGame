using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinUI;
    private int count;

    public AudioClip coinSound;

    void Update()
    {
        count = PlayerPrefs.GetInt("Coins");
        coinUI.text = "Coins: " + count.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }








}
