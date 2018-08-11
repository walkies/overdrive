using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{

	void Update ()
    {
        transform.position -= transform.forward * (Time.deltaTime * 3); 
	}
}
