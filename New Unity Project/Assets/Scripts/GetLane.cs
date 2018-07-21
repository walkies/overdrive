using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLane : MonoBehaviour
{
    public GameObject[] lanes;
    void Start()
    {
        StartCoroutine("get");
    }
    IEnumerator get()
    {
        yield return new WaitForSeconds(2);
        lanes[0] = GameObject.FindGameObjectWithTag("3");
        lanes[1] = GameObject.FindGameObjectWithTag("2");
        lanes[2] = GameObject.FindGameObjectWithTag("1");
        yield return null;
        StopCoroutine("get");
    }
}
