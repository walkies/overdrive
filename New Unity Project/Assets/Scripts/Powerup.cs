using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Abilities ab;
    public ParticleSystem pS;
    public Renderer rend;
    public bool Switch;

    void Awake()
    {
        ab = FindObjectOfType<Abilities>();
        pS = GetComponent<ParticleSystem>();
        rend = transform.GetChild(0).GetComponent<Renderer>();
    }

    void Start()
    {
        InvokeRepeating("Colour", 0, 1);
    }

    void Update ()
    {
        if (Switch == false)
        {
            StartCoroutine("LerpScale");
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ab.RandomWeapon();
            pS.Play();
            Destroy(gameObject, 0.5f);
        }
    }

    public IEnumerator LerpScale()
    {
        Switch = true;
        LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y +0.2f, transform.position.z), 1);
        yield return new WaitForSeconds(1);
        LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y -0.2f, transform.position.z), 1);
        yield return new WaitForSeconds(1);
        Switch = false;
        StopCoroutine("LerpScale");
    }

    public void Colour()
    {
        Color newColor = new Color(Random.Range(1,4), Random.Range(4, 8), Random.Range(4, 8), 1.0f);
        rend.material.color = newColor;
    }
}
