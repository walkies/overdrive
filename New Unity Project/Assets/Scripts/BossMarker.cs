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
                target.transform.Rotate(Vector3.right * (20 * Time.deltaTime));
                target.transform.localScale -= new Vector3(0.00012F, 0.00012f, 0.00012f);
            }
        }
    }
}
