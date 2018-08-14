using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private int spawnChance;
    public GameObject powerUp;
    public int powerSpawnMax; 

	public void Start ()
    {
        powerSpawnMax = Overlord.powerUpMax;
        spawnChance = Random.Range(0,powerSpawnMax);

        if (spawnChance == 100)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.5f);
        }
	}
}
