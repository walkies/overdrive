using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBonus : MonoBehaviour
{
    public bool Switch;

    public void Update()
    {
        if (Switch == false)
        {
            StartCoroutine("LerpScale");
        }
    }

    public IEnumerator LerpScale()
    {
        Switch = true;
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 1);
        yield return new WaitForSeconds(1);
        LeanTween.scale(gameObject, new Vector3(0.9f, 0.9f, 0.9f), 1);
        yield return new WaitForSeconds(1);
        Switch = false;
        StopCoroutine("LerpScale");
    }

}
