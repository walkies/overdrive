using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScale : MonoBehaviour
{
    public Image image;
    public Color tempColor;
    public int timeToActivate;
    public float alpha;
    public float intervals;

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine("AlphaOverTime");
        tempColor = image.color;
    }

    void Update()
    {
        image.color = tempColor;
    }

    IEnumerator AlphaOverTime()
    {
        yield return new WaitForSeconds(timeToActivate);
        for (int i = 0; i < 40; i++)
        {
            tempColor.a -= alpha;
            yield return new WaitForSeconds(intervals);
        }
    }

}
