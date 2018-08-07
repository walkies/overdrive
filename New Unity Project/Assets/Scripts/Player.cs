using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerMovement pM;
    public Rigidbody rB;

    void Start ()
    {

    }
	

	public void Update ()
    {
        transform.position += transform.forward * Time.deltaTime * pM.speed;
    }
}
