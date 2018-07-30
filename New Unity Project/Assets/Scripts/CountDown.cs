using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

	void Start ()
    {
        Destroy(gameObject, 45);
	}
}
