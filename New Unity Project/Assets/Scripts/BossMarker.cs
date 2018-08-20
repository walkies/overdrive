using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMarker : MonoBehaviour
{
    public Abilities aB;
    public GameObject target;

    public void Start()
    {
        aB = FindObjectOfType<Abilities>();
    }


    public void Update()
    {
        if (aB.currentWeapon != 0)
        {
            if (target.activeSelf == false)
            {
                target.SetActive(true);
            }
            else
            {
                target.transform.Rotate(Vector3.forward * (20 * Time.deltaTime));
                target.transform.localScale -= new Vector3(0.0002F, 0.0002f, 0.0002f);
            }
        }
    }
}
