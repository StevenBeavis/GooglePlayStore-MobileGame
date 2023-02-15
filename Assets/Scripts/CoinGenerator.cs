using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public PlatformRelocate relocator;

    public float dist;

    public void Generator(Vector3 pos)
    {
        GameObject go = relocator.getGO();
        go.transform.position = pos;
        go.SetActive(true);

        GameObject go2 = relocator.getGO();
        go2.transform.position = new Vector3(pos.x - dist, pos.y, pos.z);
        go2.SetActive(true);

        GameObject go3 = relocator.getGO();
        go3.transform.position = new Vector3(pos.x + dist, pos.y, pos.z);
        go3.SetActive(true);
    }
}
