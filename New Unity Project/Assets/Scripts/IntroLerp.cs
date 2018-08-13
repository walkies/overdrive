using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLerp : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    void Start ()
    {
        LeanTween.move(gameObject, new Vector3(x, y, z), 4);
	}

}
