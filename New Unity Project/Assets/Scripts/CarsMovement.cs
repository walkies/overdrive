using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    public int speed;
	void Update ()
    {
        transform.position -= transform.forward * (Time.deltaTime * speed); 
	}
}
