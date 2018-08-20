using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject casings;
    public GameObject casingsPos;
    public GameObject muzzleFlash;
    public AudioEffectSO minigun;

    public void Fire()
    {
        StartCoroutine("MuzzleFlash");
        minigun.Play();
        Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x + Random.Range(-1.9f , -0.9f), transform.rotation.y + Random.Range(-1, 1), transform.rotation.z));
        Instantiate(casings, casingsPos.transform.position, Quaternion.Euler(transform.rotation.x + Random.Range(-3, 3), transform.rotation.y + Random.Range(-3, 3), transform.rotation.z + Random.Range(-3, 3)));
    }
    public IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        StopCoroutine("MuzzleFlash");
    }
}
