using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public UI ui;
    public Weapons currentWeapon;
    public PlayerMovement pM;

    public GameObject[] weapons;

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

    void Start()
    {
        selectedWeaponImage = weaponsImages[0];
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
