using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoad : MonoBehaviour
{
    public Waypoints way;
    public TileStorage tS;
    private int tileLength = 200;
    public ScriptableTile[] Tiles;
    public float PosZ;

    public void Start()
    {
        tS = FindObjectOfType<TileStorage>();
        way = GetComponentInParent<Waypoints>();
        Tiles = tS.Tiles;
        PosZ = transform.position.z;
    }

    ///<Summary>
    /// Spawns tile equal to tile index, at transform position - pos.z
    ///</Summary>
    public void Lay(int tileindex)
    {
        Instantiate(Tiles[tileindex].Tile, new Vector3(transform.position.x, transform.position.y, PosZ), Quaternion.identity, transform.parent);
    }

    ///<Summary>
    /// Spawns tile equal to tile index, at transform position - pos.z
    /// Adds CreateRoad
    /// Adds BoxCollider, sets size and as a trigger 
    ///</Summary>
    public void LayWithCreateRoad(int tileindex)
    {
        var go = Instantiate(Tiles[tileindex].Tile, new Vector3(transform.position.x, transform.position.y, PosZ), Quaternion.identity, transform.parent);
        go.AddComponent<CreateRoad>();
        go.AddComponent<BoxCollider>().isTrigger = true;
        go.GetComponent<BoxCollider>().size = new Vector3(110, 110, 110);
    }


    ///<Summary>
    /// Checks what tile called it 
    /// Spawns down that lane
    /// if the tile is the last one spawned add extra components to it
    ///</Summary>
    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("i have triggered");
        if (col.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Roof"))
            {
                StartCoroutine("CreateRoofTile");
            }
            else if (gameObject.CompareTag("Road"))
            {
                StartCoroutine("CreateRoadTile");
            }
            else if (gameObject.CompareTag("LeftWall"))
            {
                StartCoroutine("CreateLeftWallTile");
            }
            else if (gameObject.CompareTag("RightWall"))
            {
                StartCoroutine("CreateRightWallTile");
            }
            way.GetWaypoints();
           // Resources.UnloadUnusedAssets();
        }
    }
    private IEnumerator CreateRoofTile()
    {
        for (int i = 0; i < tileLength; i++)
        {
            yield return new WaitForSeconds(0.05f);
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
        StopCoroutine("CreateRoofTile");
    }

    private IEnumerator CreateRoadTile()
    {
        for (int i = 0; i < tileLength; i++)
        {
            yield return new WaitForSeconds(0.05f);
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
        StopCoroutine("CreateRoadTile");
    }

    private IEnumerator CreateLeftWallTile()
    {
        for (int i = 0; i < tileLength; i++)
        {
            yield return new WaitForSeconds(0.05f);
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
        StopCoroutine("CreateLeftWallTile");
    }

    private IEnumerator CreateRightWallTile()
    {
        for (int i = 0; i < tileLength; i++)
        {
            yield return new WaitForSeconds(0.05f);
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
        StopCoroutine("CreateRightWallTile");
    }
}


