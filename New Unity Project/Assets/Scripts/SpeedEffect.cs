using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public PlayerMovement pM;
    public ParticleSystem pS;
    public ParticleSystem.EmissionModule pSE;

    void Start()
    {
        pSE = pS.emission;
    }

    void Update ()
    {
        pSE.rateOverTime = (pM.speed / 3);
    }
}
