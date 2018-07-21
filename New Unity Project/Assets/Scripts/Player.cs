using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GetLane getLane;
    public PlayerMovement pM;
    public Waypoints pathToFollow;
    public Rigidbody rB;

    void Start ()
    {
        pM = GetComponentInParent<PlayerMovement>();
        getLane = GetComponentInParent<GetLane>();
        pathToFollow = getLane.lanes[pM.currentLane].GetComponent<Waypoints>();
    }
	

	public void Update ()
    {
        pathToFollow = getLane.lanes[pM.currentLane].GetComponent<Waypoints>();
        rB.position = Vector3.MoveTowards(transform.position, pathToFollow.wayPoints[pM.CurrentWaypoint].position, Time.deltaTime * pM.speed);
        float distance = Vector3.Distance(pathToFollow.wayPoints[pM.CurrentWaypoint].position, transform.position);

        if (distance <= pM.reachDistance)
        {
            pM.CurrentWaypoint++;
        }

        if (pM.CurrentWaypoint >= pathToFollow.wayPoints.Length)
        {
            pM.CurrentWaypoint = 0;
        }
    }
}
