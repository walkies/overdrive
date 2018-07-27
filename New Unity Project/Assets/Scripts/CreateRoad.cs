using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoad : MonoBehaviour
{
    public Waypoints way;
    public TileStorage tS;
    private int tileLength = 200;
    private ScriptableTile[] Tiles;
    public float PosZ;

    public void Start()
    {
        tS = FindObjectOfType<TileStorage>();
        way = GetComponentInParent<Waypoints>();
        Tiles = tS.Tiles;
        PosZ = transform.position.z;
    }


    public void Lay(int tileindex)
    {
        Instantiate(Tiles[tileindex].Tile, new Vector3(transform.position.x, transform.position.y, PosZ), Quaternion.identity, transform.parent);
    }

    public void LayWithCreateRoad(int tileindex)
    {
        var go = Instantiate(Tiles[tileindex].Tile, new Vector3(transform.position.x, transform.position.y, PosZ), Quaternion.identity, transform.parent);
        go.AddComponent<CreateRoad>();
        go.AddComponent<BoxCollider>().isTrigger = true;
        go.GetComponent<BoxCollider>().size = new Vector3(30, 30, 30);
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("i have triggered");
        if (col.gameObject.CompareTag("Player"))
        {
            if (gameObject.name == ("Roof"))
            {
                for (int i = 0; i < tileLength; i++)
                {
                    if (i < (tileLength - 1))
                    {
                        Lay(Overlord.RoofIndex);
                        PosZ--;
                    }
                    else if (i == (tileLength - 1))
                    {
                        LayWithCreateRoad(Overlord.RoofIndex);
                        PosZ--;
                    }
                }
                Overlord.updateRoofIndex();
            }
            else if (gameObject.name == ("Road"))
            {
                for (int i = 0; i < tileLength; i++)
                {
                    if (i < (tileLength - 1))
                    {
                        Lay(Overlord.RoadIndex);
                        PosZ--;
                    }
                    else if (i == (tileLength - 1))
                    {
                        LayWithCreateRoad(Overlord.RoadIndex);
                        PosZ--;
                    }
                }
                Overlord.updateRoadIndex();
            }
            else if (gameObject.name == ("LeftWall"))
            {
                for (int i = 0; i < tileLength; i++)
                {
                    if (i < (tileLength - 1))
                    {
                        Lay(Overlord.LeftWallIndex);
                        PosZ--;
                    }
                    else if (i == (tileLength - 1))
                    {
                        LayWithCreateRoad(Overlord.LeftWallIndex);
                        PosZ--;
                    }             
               }
                Overlord.updateLeftWallIndex();
            }
            else if (gameObject.name == ("RightWall"))
            {
                for (int i = 0; i < tileLength; i++)
                {
                    if (i < (tileLength - 1))
                    {
                        Lay(Overlord.RightWallIndex);
                        PosZ--;
                    }
                    else if (i == (tileLength - 1))
                    {
                        LayWithCreateRoad(Overlord.RightWallIndex);
                        PosZ--;
                    }
                }
                Overlord.updateRightWallIndex();
            }
            way.GetWaypoints();
        }
    }
}
///<Summary>
/// transforms the camera to one of two positions based on keypress
///</Summary>
