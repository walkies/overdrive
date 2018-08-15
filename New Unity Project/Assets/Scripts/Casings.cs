using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casings : MonoBehaviour
{
    public Rigidbody rb;
    private int rando;

    void Start()
    {
        rando = Random.Range(1000, 2220);
        rb.AddForce(transform.right * rando);
    }

}