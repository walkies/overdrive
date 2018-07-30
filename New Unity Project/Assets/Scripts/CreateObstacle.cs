using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public TileStorage tS;
    public GameObject[] Obstacles;
    public float posX;
    public float posY;
    public int spawnIndex;
    public int spawnChance;

    void Start()
    {
        tS = FindObjectOfType<TileStorage>();
        posX = transform.position.x;
        posY = transform.position.y;
        spawnIndex = Random.Range(0, 3);

        if (gameObject.CompareTag("Roof"))
        {
            posY = 4;
            spawnChance = Random.Range(tS.Tiles[Overlord.RoofIndex].spawnAggression, 161);
        }
        else if (gameObject.CompareTag("Road"))
        {
            posY = 0;
            spawnChance = Random.Range(tS.Tiles[Overlord.RoadIndex].spawnAggression, 161);
        }
        else if (gameObject.CompareTag("LeftWall"))
        {
            posX = 11;
            spawnChance = Random.Range(tS.Tiles[Overlord.LeftWallIndex].spawnAggression, 161);
        }
        else if (gameObject.CompareTag("RightWall"))
        {
            posX = 7;
            spawnChance = Random.Range(tS.Tiles[Overlord.RightWallIndex].spawnAggression, 161);
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
