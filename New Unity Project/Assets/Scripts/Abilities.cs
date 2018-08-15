﻿using System.Collections;
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
    public int Ammo;
    public Sprite[] rocketImages;

    [Header("Weapon Images")]

    public Sprite selectedWeaponImage;
    public Sprite[] weaponsImages;
 

    private int weaponSelect;
    private int selectedWeapon;

    public enum Weapons
    {
        Empty,
        Minigun,
        Laser,
        Rocket,
        Bomb,
        Bagpipe
    }

    void Update()
    {
        if (currentWeapon == Weapons.Empty)
        {
            selectedWeaponImage = weaponsImages[0];
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
            case (Weapons.Bomb):
                break;
            case (Weapons.Bagpipe):
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
            weapons[0].SetActive(true);
            StartCoroutine("FireMinigun");
        }
        else if (currentWeapon == Weapons.Rocket)
        {
            if (Ammo > 0)
            {
                Instantiate(weapons[1], transform.position, Quaternion.identity);
                Ammo--;
                selectedWeaponImage = rocketImages[Ammo];  
            }
            else
            {
                currentWeapon = Weapons.Empty;
            }
        }
        else if (currentWeapon == Weapons.Laser)
        {
            weapons[2].SetActive(true);
            //laser function
        }
        else if (currentWeapon == Weapons.Bomb)
        {
            weapons[3].SetActive(true);
            //bomb function
        }
        else if (currentWeapon == Weapons.Bagpipe)
        {
            weapons[4].SetActive(true);
            //Bagpipe function
        }
    }

    public IEnumerator FireMinigun()
    {
        yield return new WaitForSeconds(1);
        //replace with tween
        weapons[0].transform.GetChild(0).transform.position = new Vector3 (weapons[0].transform.GetChild(0).transform.position.x, weapons[0].transform.GetChild(0).transform.position.y + 0.2f, weapons[0].transform.GetChild(0).transform.position.z);
        yield return new WaitForSeconds(1);
        mG.InvokeRepeating("Fire", 0, 0.1f);
        yield return new WaitForSeconds(5);
        mG.CancelInvoke("Fire");
        yield return new WaitForSeconds(1);
        //replace with tween
        weapons[0].transform.GetChild(0).transform.position = new Vector3(weapons[0].transform.GetChild(0).transform.position.x, weapons[0].transform.GetChild(0).transform.position.y - 0.2f, weapons[0].transform.GetChild(0).transform.position.z);  
        weapons[0].SetActive(false);
        currentWeapon = Weapons.Empty;
    }

    public IEnumerator RandomWeapon()
    {
        Debug.Log("called");
        weaponSelect = Random.Range(1, 15);

        for (int i = 0; i < weaponSelect; i++)
        {
            selectedWeaponImage = weaponsImages[(i + 1)];
            yield return new WaitForSeconds((0.1f * i));
        }
        LeanTween.scale(ui.Weapon.gameObject, new Vector3(0.7f, 0.7f, 0.7f), 0.4f);
        yield return new WaitForSeconds((0.4f));
        LeanTween.scale(ui.Weapon.gameObject, new Vector3(0.6f, 0.6f, 0.6f), 0.4f);

        if(selectedWeapon <= 5)
        {
            selectedWeapon = (weaponSelect);
        }
        if(selectedWeapon >= 6 && selectedWeapon <= 10)
        {
            selectedWeapon = (weaponSelect - 5);
        }
        if (selectedWeapon >= 11 && selectedWeapon <= 15)
        {
            selectedWeapon = (weaponSelect - 10);
        }
       

        if ((int) Weapons.Minigun == selectedWeapon)
        {
            currentWeapon = Weapons.Minigun;
        }

        else if ((int)Weapons.Rocket == selectedWeapon)
        {
            currentWeapon = Weapons.Rocket;
        }

        else if ((int)Weapons.Laser == selectedWeapon)
        {
            currentWeapon = Weapons.Laser;
        }

        else if ((int)Weapons.Bomb == selectedWeapon)
        {
            currentWeapon = Weapons.Bomb;
        }

        else if ((int)Weapons.Bagpipe == selectedWeapon)
        {
            currentWeapon = Weapons.Bagpipe;
        }
    }
}
