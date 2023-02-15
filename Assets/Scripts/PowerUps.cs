using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool doublePoints;
    public bool safeMode;

    public float timer;

    public Sprite[] powerupSprites;

    private PowerUpManager pm;

    void Awake()
    {
        int selector = Random.Range(0, 2);

        switch (selector)
        {
            case 0: doublePoints = true;
                break;

            case 1: safeMode = true;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[selector];
    }
    void Start()
    {
        pm = FindObjectOfType<PowerUpManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pm.Triggered(doublePoints, safeMode, timer);
        }
        gameObject.SetActive(false);
    }
}
