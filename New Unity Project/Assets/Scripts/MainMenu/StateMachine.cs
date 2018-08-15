using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    public States currentState;
    public GameObject credits;
    public GameObject myGarage;

    public enum States
    {
        Null,
        Credits,
        MyGarage
    }


    void Start()
    {

    }


    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)   //Switch between states 
        {
            case (States.Null):
                break;
            case (States.Credits):
                break;
            case (States.MyGarage):
                break;
        }
    }

    public void Credits()
    {
        if (currentState == States.MyGarage)
        {
            myGarage.SetActive(false);
            credits.SetActive(true);
            currentState = States.Credits;
        }
        else if (currentState == States.Credits)
        {
            credits.SetActive(false);
            currentState = States.Credits;
        }
        else if (currentState != States.Credits)
        {
            credits.SetActive(true);
            currentState = States.Credits;
        }
    }

    public void Garage()
    {
        if (currentState == States.Credits)
        {
            myGarage.SetActive(true);
            credits.SetActive(false);
            currentState = States.MyGarage;
        }
        else if (currentState == States.MyGarage)
        {
            myGarage.SetActive(false);
            currentState = States.MyGarage;
        }
        else if (currentState != States.MyGarage)
        {
            myGarage.SetActive(true);
            currentState = States.MyGarage;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        DestroyGameObjectsWithTag("IntroMusic");
        SceneManager.LoadScene("SampleScene");
    }

    public static void DestroyGameObjectsWithTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
    }

}


/*
 * Sets States for combat
 * On playerturn State, neg players damage from enemys health
 * On Enemyturn State, neg enemy damage from players health
 * UnityEvents can be configured for each state
 * SetEnemy passes in scriptable stats about the Enemy 
 */

