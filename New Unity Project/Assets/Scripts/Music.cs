using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource aS;
    private float maximum = 0.4f;
    private float minimum = 0.01f;
    void Start ()
    {
        aS = GetComponent<AudioSource>();
    }
	

	void Update ()
    {
        aS.volume = Mathf.Lerp(minimum, maximum, Time.time /1000);
        aS.pitch = Mathf.Lerp(1, 1.2f, Time.time /1000);
    }
}
