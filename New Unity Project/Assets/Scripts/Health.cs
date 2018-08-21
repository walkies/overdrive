using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public UI uI;
    public int health;
    public bool Npc;
    public GameObject pS;
    public AudioSource aS;
    public Light L;
    public bool doOnce;
    public GameObject endScreen;

    public void Start()
    {
        uI = FindObjectOfType<UI>();
        endScreen = GameObject.FindGameObjectWithTag("EndPanel");
    }

    public void Update()
    {
        if (Npc == true)
        {
            if (health <= 0)
            {
                if (doOnce == false)
                {
                    if (gameObject.CompareTag("Boss"))
                    {
                        uI.StartCoroutine("text");
                        Overlord.crimesSolved++;
                        Overlord.ScoreDestroyTarget(2000);
                        doOnce = true;
                    }
                    else
                    {
                        Overlord.casual++;
                        Overlord.ScoreDestroyTarget(200);
                        doOnce = true;
                    }
                }
                aS.enabled = true;
                L.enabled = true;
                pS.SetActive(true);
                Destroy(gameObject, 0.2f);
            }
        }
        else
        {
            if (health <= 0)
            {
                StartCoroutine("death");
            }
        }
    }
    public IEnumerator death()
    {
        yield return new WaitForSeconds(4); 
        endScreen.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        SceneManager.LoadScene("EndScore");
    }
}

