using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GetLane getLane;
    public Waypoints pathToFollow;
    public ScriptableStats sS;
    public Rigidbody rB;

    public int CurrentWaypoint = 0;
    private float reachDistance = 1f;
    public float rotationspeed = 0.01f;
    public int currentLane = 1;
    public float speed;
    private float timeCount = 1.0f;
    public float lockOut;

    Vector3 lastPosition;
    Vector3 CurrentPosition;

    void Start()
    {
        pathToFollow = getLane.lanes[currentLane].GetComponent<Waypoints>();
        lastPosition = transform.position;
    }

    void Update()
    {
        pathToFollow = getLane.lanes[currentLane].GetComponent<Waypoints>();
        float distance = Vector3.Distance(pathToFollow.wayPoints[CurrentWaypoint].position, transform.position);

        rB.position = Vector3.MoveTowards(transform.position, pathToFollow.wayPoints[CurrentWaypoint].position, Time.deltaTime * speed);

        #region Input
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time > lockOut)
        {
            if (currentLane == 2)
            {
                if (speed >= 5.5)
                {
                    lockOut = Time.time + timeCount;
                    pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
                }
            }
            else if (currentLane == 5)
            {
                lockOut = Time.time + timeCount;
                if (speed >= 8)
                {
                    lockOut = Time.time + timeCount;
                    pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
                }
            }
            else if (currentLane == 8)
            {
                if (speed >= 8)
                {
                    lockOut = Time.time + timeCount;
                    pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
                }
            }
            else if (currentLane == 11)
            {
                if (speed >= 5.5)
                {
                    lockOut = Time.time + timeCount;
                    currentLane = 0;
                }
            }
            else if (currentLane >= 0 && currentLane <= 1)
            {
                pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
            }
            else if (currentLane >= 3 && currentLane <= 4)
            {
                pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
            }
            else if (currentLane >= 6 && currentLane <= 7)
            {
                pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
            }
            else if (currentLane >= 9 && currentLane <= 11)
            {
                pathToFollow = getLane.lanes[currentLane++].GetComponent<Waypoints>();
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time > lockOut)
        {
            if (currentLane == 0)
            {
                if (speed >= 5.5)
                {
                    lockOut = Time.time + timeCount;
                    pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
                }
            }
            else if (currentLane == 9)
            {
                lockOut = Time.time + timeCount;
                if (speed >= 8)
                {
                    lockOut = Time.time + timeCount;
                    pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
                }
            }
            else if (currentLane == 6)
            {
                if (speed >= 8)
                {
                    lockOut = Time.time + timeCount;
                    pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
                }
            }
            else if (currentLane == 3)
            {
                if (speed >= 5.5)
                {
                    lockOut = Time.time + timeCount;
                    currentLane = 2;
                }
            }
            else if (currentLane >= 1 && currentLane <= 2)
            {
                pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
            }
            else if (currentLane >= 4 && currentLane <= 5)
            {
                pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
            }
            else if (currentLane >= 7 && currentLane <= 8)
            {
                pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
            }
            else if (currentLane >= 10 && currentLane <= 11)
            {
                pathToFollow = getLane.lanes[currentLane--].GetComponent<Waypoints>();
            }
        }
        #endregion

        if (speed < sS.topSpeed)
        {
            speed += Time.deltaTime * sS.Acceleration;
        }

        if (distance <= reachDistance)
        {
            CurrentWaypoint++;
        }

        if (CurrentWaypoint >= pathToFollow.wayPoints.Length)
        {
            CurrentWaypoint = 0;
        }


    }
}

