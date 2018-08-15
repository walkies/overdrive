using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : MonoBehaviour
{
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("Colour", 0, 0.2f);
    }
	void Update ()
    {
        transform.position -= transform.forward;
	}

    public void Colour()
    {
        Color newColor = new Color(Random.Range(2, 6), Random.Range(6, 10), Random.Range(6, 10), 0.5f);
        rend.material.color = newColor;
    }

    public void OnTriggerEnter()
    {

    }
}
