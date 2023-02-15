using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;
    private bool isActive;

    private float counter;
    private float initialPoints;
    private float spikeAmount;

    private PlatformDestroyer[] spikeList;

    private ScoreManager sm;
    private PlatformController pc;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        pc = FindObjectOfType<PlatformController>();
    }

    void Update()
    {
        if (isActive)
        {
            counter -= Time.deltaTime;

            if (doublePoints)
            {
                sm.points = initialPoints * 2;
            }

            if (safeMode)
            {
                pc.randomSpikeRange = 0;
            }

            if (counter <= 0)
            {
                sm.points = initialPoints;
                pc.randomSpikeRange = spikeAmount;
                isActive = false;
            }
        }
    }

    public void Triggered(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        counter = time;

        if (!isActive)
        {
            initialPoints = sm.points;
            spikeAmount = pc.randomSpikeRange;
        }

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("Spike"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }               
            }
        }

        isActive = true;
    }
}
