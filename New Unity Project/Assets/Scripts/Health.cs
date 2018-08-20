using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public UI uI;
    public int health;
    public bool Npc;
    public GameObject pS;
    public AudioSource aS;
    public Light L;

    public void Start()
    {
        uI = FindObjectOfType<UI>(); 
    }

    public void Update()
    {
        if (Npc == true)
        {
            if (health <= 0)
            {
                if (gameObject.CompareTag("Boss"))
                {
                    uI.StartCoroutine("text");
                    Overlord.ScoreDestroyTarget(300);
                }
                else
                {
                    Overlord.ScoreDestroyTarget(40);
                }

                aS.enabled = true;
                L.enabled = true;
                pS.SetActive(true);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}

