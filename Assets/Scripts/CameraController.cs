using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public variables
    public PlayerController player;

    //Private variables
    private Vector3 playerPos;
    private float dist;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        playerPos = player.transform.position;
    }

    void Update()
    {
        dist = player.transform.position.x - playerPos.x;

        transform.position = new Vector3(transform.position.x + dist, transform.position.y, transform.position.z);
                    
        playerPos = player.transform.position;
    }
}
