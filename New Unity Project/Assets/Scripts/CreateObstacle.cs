using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject[] Obstacles;
    public float posX;
    public float posY;
    public int spawnIndex;
    public int spawnChance;

    void Start()
    {
        Destroy(gameObject, 45);

        posX = transform.position.x;
        posY = transform.position.y;
        spawnIndex = Random.Range(0, 3);

        if (gameObject.CompareTag("Roof"))
        {
            posY = 4;
            spawnChance = Random.Range(Overlord.roofAggression, 201);
        }
        else if (gameObject.CompareTag("Road"))
        {
            posY = 0;
            spawnChance = Random.Range(Overlord.roadAggression, 201);
        }
        else if (gameObject.CompareTag("LeftWall"))
        {
            posX = 11;
            spawnChance = Random.Range(Overlord.leftWallAggression, 201);
        }
        else if (gameObject.CompareTag("RightWall"))
        {
            posX = 7;
            spawnChance = Random.Range(Overlord.rightWallAggression, 201);
        }
        SpawnObstacle();
    }

    public void SpawnObstacle()
    {
        if (spawnChance == 200)
        {
            Instantiate(Obstacles[spawnIndex], new Vector3(posX, posY, transform.position.z), Quaternion.identity, transform.parent);
        }
    }
}
