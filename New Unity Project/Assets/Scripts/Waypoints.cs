using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] wayPoints;

    void Start()
    {
        wayPoints = GetComponentsInChildren<Transform>();
    }
}
