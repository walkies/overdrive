using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, 0);
        }
    } 
}
