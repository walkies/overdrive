﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{

    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 0.5f);
    }
}
