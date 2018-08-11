using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoad : MonoBehaviour
{
    public List<GameObject> Tiles = new List<GameObject>();
    public GameObject vision;
    public GameObject visionPanel;
    private int tileLength = 400;
    public float PosZ;

    public void Awake()
    {
        #region Tiles
        Tiles.Add(Resources.Load<GameObject>("Roof"));
        Tiles.Add(Resources.Load<GameObject>("Road"));
        Tiles.Add(Resources.Load<GameObject>("LeftWall"));
        Tiles.Add(Resources.Load<GameObject>("RightWall"));
        #endregion
        PosZ = transform.position.z;
        vision = (Resources.Load<GameObject>("Vision"));
        visionPanel = (Resources.Load<GameObject>("VisionPanel")); ;
    }

    ///<Summary>
    /// Spawns tile equal to tile index, at transform position - pos.z
    ///</Summary>
    public void Lay(int tileindex)
    {
        Instantiate(Tiles[tileindex], new Vector3(transform.position.x, transform.position.y, PosZ), Quaternion.identity, transform.parent);
    }

    ///<Summary>
    /// Spawns tile equal to tile index, at transform position - pos.z
    /// Adds CreateRoad
    /// Adds BoxCollider, sets size and as a trigger 
    ///</Summary>
    public void LayWithCreateRoad(int tileindex)
    {
        var go = Instantiate(Tiles[tileindex], new Vector3(transform.position.x, transform.position.y, PosZ), Quaternion.identity, transform.parent);
        go.AddComponent<CreateRoad>();
        go.AddComponent<BoxCollider>().isTrigger = true;
        go.GetComponent<BoxCollider>().size = new Vector3(200, 200, 200);
    }

    public void CameraRoad()
    {
        Instantiate(visionPanel, new Vector3(transform.position.x -1, transform.position.y + 2.8f, PosZ), Quaternion.Euler(90,0,0), transform.parent);
        Instantiate(vision, new Vector3(9.08f, 1.42f, 3.44f), Quaternion.Euler(0, 180, 0), transform.parent);
    }

    public void ResetRoad()
    {
        PosZ = 0;
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
                if (FindObjectOfType<ResetPos>() == true)
                {
                    ResetRoad();
                    StartCoroutine("CreateRoofTile");
                }
                else
                {
                    StartCoroutine("CreateRoofTile");
                }
            }
            else if (gameObject.CompareTag("Road"))
            {
                if (FindObjectOfType<ResetPos>() == true)
                {
                    ResetRoad();
                    StartCoroutine("CreateRoadTile");
                }
                else
                {
                    StartCoroutine("CreateRoadTile");
                }
            }
            else if (gameObject.CompareTag("LeftWall"))
            {
                if (FindObjectOfType<ResetPos>() == true)
                {
                    ResetRoad();
                    StartCoroutine("CreateLeftWallTile");
                }
                else
                {
                    StartCoroutine("CreateLeftWallTile");
                }
            }
            else if (gameObject.CompareTag("RightWall"))
            {
                if (FindObjectOfType<ResetPos>() == true)
                {
                    ResetRoad();
                    StartCoroutine("CreateRightWallTile");
                }
                else
                {
                    StartCoroutine("CreateRightWallTile");
                }
            }
        }
    }

    private IEnumerator CreateRoofTile()
    {
        for (int i = 0; i < tileLength; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (i < (tileLength - 1))
            {
                Lay(0);
                PosZ--;
            }
            else if (i == (tileLength - 1))
            {
                LayWithCreateRoad(0);
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
            yield return new WaitForSeconds(0.001f);
            if (i < (tileLength - 1))
            {
                Lay(1);
                PosZ--;
            }
            else if (i == (tileLength - 1))
            {
                if (Overlord.activateReset % 27 == 0)
                {
                    CameraRoad();
                    LayWithCreateRoad(1);
                    PosZ--;
                    Overlord.ActivateReset();
                }
                else
                {
                    LayWithCreateRoad(1);
                    PosZ--;
                    Overlord.ActivateReset();
                }
            }
        }
        Overlord.updateRoadIndex();
        StopCoroutine("CreateRoadTile");
    }

    private IEnumerator CreateLeftWallTile()
    {
        for (int i = 0; i < tileLength; i++)
        {
            yield return new WaitForSeconds(0.001f);
            if (i < (tileLength - 1))
            {
                Lay(2);
                PosZ--;
            }
            else if (i == (tileLength - 1))
            {
                LayWithCreateRoad(2);
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
            yield return new WaitForSeconds(0.001f);
            if (i < (tileLength - 1))
            {
                Lay(3);
                PosZ--;
            }
            else if (i == (tileLength - 1))
            {
                LayWithCreateRoad(3);
                PosZ--;
            }
        }
        Overlord.updateRightWallIndex();
        StopCoroutine("CreateRightWallTile");
    }
}


