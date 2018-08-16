using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public bool Timer;

    public void Update()
    {
        if (Input.anyKeyDown != true)
        {
            if (Timer == false)
            {
                StartCoroutine("IntroTimer");
            }
        }

        else
        {
            Timer = false;
            StopCoroutine("IntroTimer");
        }
    }

    IEnumerator IntroTimer()
    {
        Timer = true;
        yield return new WaitForSeconds(60);
        Destroy(GameObject.FindGameObjectWithTag("IntroMusic"));
        SceneManager.LoadScene("Intro");
    }

}
