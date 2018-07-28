using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public TileCollection tC;
    public GameObject[] Obstacles;
    public float posX;
    public float posY;
    public int spawnIndex;
    public int spawnChance;

    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        spawnIndex = Random.Range(0, 3);

        if (gameObject.CompareTag("Roof"))
        {
            posY = 4;
            spawnChance = Random.Range(tC.sT[Overlord.RoofIndex].spawnAggression, 101);
        }
        else if (gameObject.CompareTag("Road"))
        {
            posY = 0;
            spawnChance = Random.Range(tC.sT[Overlord.RoadIndex].spawnAggression, 101);
        }
        else if (gameObject.CompareTag("LeftWall"))
        {
            posX = 11;
            spawnChance = Random.Range(tC.sT[Overlord.LeftWallIndex].spawnAggression, 101);
        }
        else if (gameObject.CompareTag("RightWall"))
        {
            posX = 7;
            spawnChance = Random.Range(tC.sT[Overlord.RightWallIndex].spawnAggression, 101);
        }
        SpawnObstacle();
    }

    public void SpawnObstacle()
    {
        if (spawnChance == 100)
        {
            Instantiate(Obstacles[spawnIndex], new Vector3(posX, posY, transform.position.z), Quaternion.identity, transform.parent);
        }
    }
}
