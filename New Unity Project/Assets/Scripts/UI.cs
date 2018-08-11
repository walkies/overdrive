using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public float timer;
    public Text inGameTime;

    public void Start()
    {

    }

    public void Update()
    {
        timer = Time.fixedUnscaledTime;
        inGameTime.text = (" " + timer.ToString("F4"));
    }

}
