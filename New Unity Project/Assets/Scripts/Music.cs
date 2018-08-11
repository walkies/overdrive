using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource aS;
    private float maximum = 0.3f;
    private float minimum = 0.1f;
    void Start ()
    {
        aS = GetComponent<AudioSource>();      
    }
	

	void Update ()
    {
        aS.volume = Mathf.Lerp(minimum, maximum, Time.time /700);
        aS.pitch = Mathf.Lerp(1, 1.2f, Time.time /820);
    }
}
///<Summary>
/// Lerps volume and pitch to a certain value over time
///</Summary>
