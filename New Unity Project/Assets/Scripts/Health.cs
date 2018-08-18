using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public bool Npc;
    public GameObject pS;
    public AudioSource aS;
    public Light L;

    public void Update()
    {
        if (Npc == true)
        {
            if (health <= 0)
            {
                aS.enabled = true;
                L.enabled = true;
                pS.SetActive(true);
                Destroy(gameObject, 1.5f);
            }
        }
    }
}

