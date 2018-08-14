using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScore : MonoBehaviour
{

    public Abilities ab;
    private int lowerScore = 10000;
    private int upperScore = 30000;

    void Update ()
    {
        if (Overlord.currentScore > lowerScore && Overlord.currentScore < upperScore)
        {
            if (ab.selectedWeaponImage == ab.weaponsImages[0])
            {
                ab.StartCoroutine("RandomWeapon");
                lowerScore = lowerScore + 20000;
                upperScore = upperScore + 30000;
            }
            else
            {

            }
        }
	}
}
