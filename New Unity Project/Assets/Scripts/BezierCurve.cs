using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public PlayerMovement pM;
    public Transform[] endlane;
    public Transform[] points;
    private int numberPoints = 50;
    private Vector3[] positions = new Vector3[50];

    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
    }


    public Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            for (int i = 1; i < numberPoints + 1; i++)
            {
                float t = 1 / (float)numberPoints;
                positions[i - 1] = CalculateQuadraticBezierPoint(t, points[0].position, points[1].position, endlane[pM.currentLane].position);
                col.transform.LookAt(endlane[pM.currentLane].position);
            }
        }
    }
}
