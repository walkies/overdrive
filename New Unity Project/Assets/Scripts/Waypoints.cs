using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [HideInInspector]
    public Transform[] wayPoints;

    void Update()
    {
        GetWaypoints();
    }

    public void GetWaypoints()
    {
        wayPoints = GetComponentsInChildren<Transform>();
    }
}
