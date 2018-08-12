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
    public float revs;
    public int revGaugeNum;
    public Text inGameTime;
    public Text inGameScore;
    public Text ScoreLaneBonus;
    public Text closeCall;
    public Text HighScore;
    public Text EndScore;
    public Text Speed;
    public Image Revs;
    public Sprite[] revGauge;
    #endregion

    public void Start()
    {
        
    }

    public void Update()
    {
        revs = Mathf.Round(pM.speed);
        #region Revs
        if (revs % 3 == 0)
        {
            StartCoroutine("RevsActivate");       
        }
        #endregion

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
        Speed.text = (" " + (pM.speed * 10).ToString("F0"));
    }

    public void CloseCall()
    {
        multiplier++;
        closeCall.gameObject.SetActive(true);
        Overlord.ScoreCloseCall(multiplier);
        closeCallTimer = closeCallTimer + 0.75f;
    }

    public IEnumerator RevsActivate()
    {
        yield return new WaitForSeconds(2f);
        Revs.sprite = revGauge[revGaugeNum++];
        StopCoroutine("RevsActivate");
    }

}
