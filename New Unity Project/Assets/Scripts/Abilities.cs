using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Weapons currentWeapon;
    public PlayerMovement pM;

    public GameObject[] weapons;

    public Image selectedWeaponImage;
    public Image[] weaponsImages;

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
            // do nothing 
        }
        else if (currentWeapon == Weapons.Minigun)
        {
            weapons[0].SetActive(true);
            StartCoroutine("FireMinigun");
        }
        else if (currentWeapon == Weapons.Rocket)
        {
            weapons[1].SetActive(true);
            //rocket function
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
        //invoke repeating 
        yield return new WaitForSeconds(1);
        weapons[0].SetActive(false);
        currentWeapon = Weapons.Empty;
    }

    public IEnumerator RandomWeapon()
    {
        weaponSelect = Random.Range(0, 14);

        for (int i = 0; i < weaponSelect; i++)
        {
            selectedWeaponImage = weaponsImages[i];
            yield return new WaitForSeconds((0.1f * i));
        }

        selectedWeapon = (weaponSelect / 3) + 1;

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
