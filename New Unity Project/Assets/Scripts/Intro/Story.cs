using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    private string str;
    public Text story;
    void Start()
    {
        StartCoroutine(AnimateText("In the future, all crimes have been successfully wiped from the streets.                                            Bored, and in fear of losing their careers, the future cops built a time tunnel using the magic of science.                                                                                                                  Into it, they put all the past crimes.                                                                                         You are Max O’Verdrive, a future cop of the clan O’Verdrive with a passion for justice and a cool car.                                                                                                           It’s time to keep the street clean.                                                                                 Of crimes."));
    }

    void Update()
    {
        story.text = "" + str;
    }

    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        str = "";
        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.020F);
        }
        yield return new WaitForSeconds(10);
        StopAllCoroutines();
    }

}