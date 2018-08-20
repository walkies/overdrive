using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("References")]
    public UI ui;
    public PlayerMovement pM;

    [Header("Start State")]

    public Weapons currentWeapon;

    public GameObject[] weapons;
    [Header("Mini Gun")]
    public Minigun mG;

    [Header("Rocket")]
    public AudioEffectSO rocket;
    public int Ammo;
    public Sprite[] rocketImages;

    [Header("Laser")]
    public AudioEffectSO laser;
    public LineRenderer lR;
    public Light chargeUp;
    [HideInInspector]
    public RaycastHit[] hits;
    [Header("Weapon Images")]

    public Sprite selectedWeaponImage;
    public Sprite[] weaponsImages;


    public int weaponSelect;
    public int selectedWeapon;

    public enum Weapons
    {
        Empty,
        Minigun,
        Laser,
        Rocket
    }

    void Update()
    {
        if (currentWeapon == Weapons.Laser)
        {   
            hits = Physics.RaycastAll(weapons[2].transform.position, transform.forward, 400.0F);
            lR.SetPosition(0, weapons[2].transform.position);
        }
        Debug.Log(currentWeapon);
        switch (currentWeapon)   //Switch between states 
        {
            case (Weapons.Empty):
                break;
            case (Weapons.Minigun):
                break;
            case (Weapons.Laser):
                break;
            case (Weapons.Rocket):
                break;
        }
    }
    public void ActivateWeapon()
    {
        if (currentWeapon == Weapons.Empty)
        {

        }
        else if (currentWeapon == Weapons.Minigun)
        {
            Overlord.weapUse++;
            weapons[0].SetActive(true);
            StartCoroutine("FireMinigun");
        }
        else if (currentWeapon == Weapons.Rocket)
        {
            if (Ammo > 0)
            {
                Overlord.weapUse++;
                rocket.Play();
                Instantiate(weapons[1], transform.position, Quaternion.identity);
                Ammo--;
                selectedWeaponImage = rocketImages[Ammo];
            }
            else
            {
                currentWeapon = Weapons.Empty;
                selectedWeaponImage = weaponsImages[0];
            }
        }
        else if (currentWeapon == Weapons.Laser)
        {
            Overlord.weapUse++;
            weapons[2].SetActive(true);
            StartCoroutine("FireLaser");
        }
    }

    public IEnumerator FireMinigun()
    {
        yield return new WaitForSeconds(0.5f);
        //replace with tween
        mG.InvokeRepeating("Fire", 0, 0.1f);
        yield return new WaitForSeconds(5);
        mG.CancelInvoke("Fire");
        yield return new WaitForSeconds(1);
        //replace with tween
        weapons[0].SetActive(false);
        currentWeapon = Weapons.Empty;
        selectedWeaponImage = weaponsImages[0];
    }

    public IEnumerator RandomWeapon()
    {
        Debug.Log("called");
        weaponSelect = Random.Range(1, 9);

        for (int i = 0; i < weaponSelect; i++)
        {
            selectedWeaponImage = weaponsImages[(i)];
            yield return new WaitForSeconds((0.3f * (i/2)));
        }
        yield return new WaitForSeconds((1f));
        LeanTween.scale(ui.Weapon.gameObject, new Vector3(0.7f, 0.7f, 0.7f), 0.4f);
        yield return new WaitForSeconds((0.4f));
        LeanTween.scale(ui.Weapon.gameObject, new Vector3(0.6f, 0.6f, 0.6f), 0.4f);

        if (weaponSelect <= 3)
        {
            selectedWeapon = (weaponSelect);
        }
        if (weaponSelect >= 4 && selectedWeapon <= 6)
        {
            selectedWeapon = (weaponSelect - 3);
        }
        if (weaponSelect >= 7 && selectedWeapon <= 9)
        {
            selectedWeapon = (weaponSelect - 6);
        }

        if ((int)Weapons.Minigun == selectedWeapon)
        {
            selectedWeaponImage = weaponsImages[1];
            currentWeapon = Weapons.Minigun;
        }

        else if ((int)Weapons.Rocket == selectedWeapon)
        {
            selectedWeaponImage = weaponsImages[3];
            Ammo = 3;
            currentWeapon = Weapons.Rocket;
        }

        else if ((int)Weapons.Laser == selectedWeapon)
        {
            selectedWeaponImage = weaponsImages[2];
            currentWeapon = Weapons.Laser;
        }
    }

    public IEnumerator FireLaser()
    {
        laser.Play();
        for (int i = 0; i < 20; i++)
        {
            chargeUp.range += 0.025f;
            yield return new WaitForSeconds(0.025f);
        }
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.CompareTag("Boss") || hits[i].collider.gameObject.CompareTag("Obstacle"))
            {
                RaycastHit hit = hits[i];
                lR.SetPosition(1, (weapons[2].transform.position + new Vector3 (weapons[2].transform.position.x, weapons[2].transform.position.y, weapons[2].transform.position.z - 400)));
                lR.enabled = true;
                hit.transform.GetComponent<Health>().health = hit.transform.GetComponent<Health>().health - 3;
            }
        }
        for (int i = 0; i < 20; i++)
        {
            lR.startWidth += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.CompareTag("Boss") || hits[i].collider.gameObject.CompareTag("Obstacle"))
            {
                RaycastHit hit = hits[i];
                lR.SetPosition(1, (weapons[2].transform.position + new Vector3(weapons[2].transform.position.x, weapons[2].transform.position.y, weapons[2].transform.position.z - 400)));
                lR.enabled = true;
                hit.transform.GetComponent<Health>().health = hit.transform.GetComponent<Health>().health - 3;
            }
        }
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 20; i++)
        {
            lR.startWidth -= 0.01f;
            chargeUp.range -= 0.025f;
            yield return new WaitForSeconds(0.025f);
        }
        StopCoroutine("FireLaser");
        lR.enabled = false;
        lR.SetPosition(1, weapons[2].transform.position);
        weapons[2].SetActive(false);
        currentWeapon = Weapons.Empty;
        selectedWeaponImage = weaponsImages[0];
    }
}
