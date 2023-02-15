using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text highscoreTxt;

    public float scoreCounter;
    public float highscoreCounter;
    public float points;
    public static bool isIncreasing;

    void Start()
    {
        isIncreasing = true;

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreCounter = PlayerPrefs.GetFloat("Highscore");
        }
    }

    void Update()
    {
        if (isIncreasing)
        {
            scoreCounter += points * Time.deltaTime;
        }
        
        if (scoreCounter > highscoreCounter)
        {
            highscoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("Highscore", highscoreCounter);
        }

        scoreTxt.text = "Score: " + Mathf.Round(scoreCounter);
        highscoreTxt.text = "Highscore: " + Mathf.Round(highscoreCounter);
    }
}
