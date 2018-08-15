using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzleFlash;

    public void Fire()
    {
        StartCoroutine("MuzzleFlash");
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    public IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        StopCoroutine("MuzzleFlash");
    }

}
