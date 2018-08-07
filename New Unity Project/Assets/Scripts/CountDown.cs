using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public int destroyTime = 30;

	void Start ()
    {
        Destroy(gameObject, destroyTime);
	}
}
