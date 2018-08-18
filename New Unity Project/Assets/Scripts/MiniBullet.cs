using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : MonoBehaviour
{
    public Renderer rend;
    public Rigidbody rb;
    public GameObject l;
    public int damage;
    public bool spin;

    void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("Colour", 0, 0.2f);
    }
	void Update ()
    {
       
        if (spin == true)
        {
            rb.AddForce(transform.forward * 1000);
            transform.Rotate(Vector3.forward * (120 * Time.deltaTime));
            GetComponent<BoxCollider>().size = GetComponent<BoxCollider>().size + new Vector3 (1f, 1f, 1f) * Time.deltaTime;
        }
        else
        {
            rb.AddForce(-transform.forward * 3000);
        }
	}

    public void Colour()
    {
        Color newColor = new Color(Random.Range(2, 6), Random.Range(6, 10), Random.Range(6, 10), 0.5f);
        rend.material.color = newColor;
    }

    public void OnTriggerEnter(Collider col)
    {    
        if (col.gameObject.CompareTag("Boss"))
        {
            col.gameObject.GetComponent<Health>().health = col.gameObject.GetComponent<Health>().health - damage;
            l.SetActive(true);
            Destroy(gameObject, 0.01f);
        }
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("works");
            col.gameObject.GetComponent<Health>().health = col.gameObject.GetComponent<Health>().health - damage;
            l.SetActive(true);
            Destroy(gameObject, 0.01f);
        }
    }
}
