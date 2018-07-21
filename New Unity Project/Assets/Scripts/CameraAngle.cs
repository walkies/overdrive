using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    public PlayerMovement pM;
    public Camera main;
    public Vector3 newPos = new Vector3(0, 0, 0);
    public Vector3 oldPos = new Vector3(0, 0, 0);
    void Start ()
    {
 
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            main.transform.position = pM.transform.position + oldPos; 
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            main.transform.position = pM.transform.position + newPos;
        }

    }
}
