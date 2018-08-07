using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backFire : MonoBehaviour
{
    public ParticleSystem pS;
    public PlayerMovement pM;
    public AudioEffectSO aSO;

    public void Start()
    {
        StartCoroutine("backfire");
    }

    IEnumerator backfire()
    {
        yield return new WaitForSeconds(25);
        pS.Play();
        aSO.Play();
        StartCoroutine("backfire");
    }
}
