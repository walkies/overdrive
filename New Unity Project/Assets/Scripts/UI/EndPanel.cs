using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    public void Retry()
    {
        Overlord.HighScoreUpdate();
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Overlord.HighScoreUpdate();
        SceneManager.LoadScene("MainMenu");
    }
}
