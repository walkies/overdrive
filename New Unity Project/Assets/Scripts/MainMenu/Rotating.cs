using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public int spinSpeed;
    public void Update()
    {
        transform.Rotate(Vector3.up * (spinSpeed * Time.deltaTime));
    }
}
