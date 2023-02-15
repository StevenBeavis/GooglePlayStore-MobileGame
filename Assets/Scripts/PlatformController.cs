using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    //Public variables
    public float maxHeightChange;
    public float randomCoinRange;
    public float randomSpikeRange;
    public float randomPowerupRange;
    public float dist;
    public float min;
    public float max;
    public float powerupHeight;
    public Transform genPoint;
    public Transform heightPoint;
    public GameObject platform;
    public PlatformRelocate spikeRelocate;
    public PlatformRelocate powerupRelocate;
    public PlatformRelocate[] script;

    //Private variables
    private int selector;
    private float width;   
    private float minHeight;
    private float maxHeight;
    private float heightChange;
    private float[] widths;
    private CoinGenerator coin;

    void Start()
    {
        widths = new float[script.Length];

        for (int i = 0; i < script.Length; i++)
        {
            widths[i] = script[i].platform.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = heightPoint.position.y;

        coin = FindObjectOfType<CoinGenerator>();
    }

    void Update()
    {
        if (transform.position.x < genPoint.position.x)
        {
            dist = Random.Range(min, max);

            selector = Random.Range(0, script.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            if (Random.Range(0, 100) < randomPowerupRange)
            {
                GameObject newPowerup = powerupRelocate.getGO();

                newPowerup.transform.position = transform.position + new Vector3(dist / 2, Random.Range(1, powerupHeight), 0);

                newPowerup.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (widths[selector] / 2) + dist, heightChange, transform.position.z);

            GameObject newGO = script[selector].getGO();

            newGO.transform.position = transform.position;
            newGO.transform.rotation = transform.rotation;
            newGO.SetActive(true);

            if (Random.Range (0f, 100f) < randomCoinRange)
            {
                coin.Generator(new Vector3(transform.position.x + 3.0f, transform.position.y + 1.0f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomSpikeRange)
            {
                GameObject newSpike = spikeRelocate.getGO();

                float spikeXPos = Random.Range(-widths[selector] / 2 + 4f, widths[selector] - 1);

                Vector3 spikePosition = new Vector3(spikeXPos, 0.55f, 0f);
                
                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }
            
            transform.position = new Vector3(transform.position.x + (widths[selector] / 2), transform.position.y, transform.position.z);

        }
    }
}
