using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTrigger : MonoBehaviour
{
    public int coinValue = 1;
    public static int totalCoins = 20;
    public ParticleSystem coin;
   // public AudioClip pickup;
    public float volume = 0.5f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           // AudioSource.PlayClipAtPoint(pickup, transform.position);
            totalCoins = totalCoins + coinValue;
            Save();
            gameObject.SetActive(false);
            coin.Play();
           
            
            
        }
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("Coins", totalCoins);
    }
}
