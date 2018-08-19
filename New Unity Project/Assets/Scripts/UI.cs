using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    #region Variables
    public Abilities aB;
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
    public Text crimeBonus;
    public Image Weapon;
    #endregion

    public void Start()
    {
        StartCoroutine("color");
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
        Weapon.sprite = aB.selectedWeaponImage;
    }

    public void CloseCall()
    {
        multiplier++;
        closeCall.gameObject.SetActive(true);
        Overlord.ScoreCloseCall(multiplier);
        closeCallTimer = closeCallTimer + 0.8f;
    }

    public IEnumerator color()
    {
        crimeBonus.canvasRenderer.SetColor(Color.red);
        yield return new WaitForSeconds(0.8f);
        crimeBonus.canvasRenderer.SetColor(Color.blue);
    }
    public IEnumerator text()
    {
        crimeBonus.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        crimeBonus.gameObject.SetActive(false);
    }
}
