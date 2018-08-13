using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    #region Variables
    public PlayerMovement pM;
    public float timer;
    public float closeCallTimer;
    public int multiplier = 0;
    public Text inGameTime;
    public Text inGameScore;
    public Text ScoreLaneBonus;
    public Text closeCall;
    public Text HighScore;
    public Text EndScore;
    public Text ScaleBonus;
    #endregion

    public void Start()
    {
        
    }

    public void Update()
    {

        if (closeCallTimer <= 0)
        {
            multiplier = 0;
            closeCall.gameObject.SetActive(false);
        }
        else if (closeCallTimer > 0)
        {
            closeCallTimer -= Time.deltaTime;
        }

        timer = Time.fixedUnscaledTime;
        inGameTime.text = (" " + timer.ToString("F4"));
        inGameScore.text = (" " + Overlord.currentScore.ToString());
        closeCall.text = ("Pass Bonus x" + multiplier.ToString());
        HighScore.text = (" " + PlayerPrefs.GetInt("HS"));
        EndScore.text = (" " + Overlord.currentScore.ToString());
        ScaleBonus.text = ("Bonus Multiplier: x" + Overlord.scaleBonus/27);
    }

    public void CloseCall()
    {
        multiplier++;
        closeCall.gameObject.SetActive(true);
        Overlord.ScoreCloseCall(multiplier);
        closeCallTimer = closeCallTimer + 0.78f;
    }

}
