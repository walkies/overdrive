using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("EndIntro");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator EndIntro()
    {
        yield return new WaitForSeconds(70);
        SceneManager.LoadScene("MainMenu");
    }


}
