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
        StartCoroutine(AnimateText("After all crime has been successfully wiped from the future, officers are sent back in time to chase down and hunt some of the worst criminals.                                                                          Through the magic of science, the future cops have been able to pipeline all traffic into a single stream making it easy to track and hunt criminals."));
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
            yield return new WaitForSeconds(0.08F);
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(AnimateText("Max O’verDrive from the O'verDrive clan, a space cop from the future with a passion for justice, is traversing this pipeline and hunting wanted criminals while preserving the integrity of the future."));
        yield return new WaitForSeconds(18);
        StopAllCoroutines();
    }

}