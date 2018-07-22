using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoad : MonoBehaviour
{

    public int tileLength;
    public GameObject Tile;
    public int PosZ = -21;



    public void Awake()
    {
        for (int i = 0; i < tileLength; i++)
        {
            Lay();
            PosZ--;
        }
    }

    public void Lay()
    {
        Instantiate(Tile, new Vector3 (transform.position.x, transform.position.y,PosZ), Quaternion.identity, transform.parent);
    }
}
