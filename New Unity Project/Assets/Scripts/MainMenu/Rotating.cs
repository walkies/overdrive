﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0.1f, 0);
    }
}