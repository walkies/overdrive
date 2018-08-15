using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMusic : MonoBehaviour
{
    public AudioSource bagPipes;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            DontDestroyOnLoad(this.gameObject);
            bagPipes.Play();
        }
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (GameObject.FindGameObjectWithTag("IntroMusic") == null)
            {
                bagPipes.Play();
            }
            else
            {

            }     
        }
    }
}
