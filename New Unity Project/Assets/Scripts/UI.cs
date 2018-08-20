using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    #region Variables
    public Abilities aB;
    public PlayerMovement pM;
    public float closeCallTimer;
    public int multiplier = 0;
    public Text inGameTime;
    public Text inGameScore;
    public Text ScoreLaneBonus;
    public Text closeCall;
    public Text HighScore;
    public Text ScaleBonus;
    public Text crimeBonus;
    public Image Weapon;
    #endregion

    public void Start()
    {
        InvokeRepeating("Color", 0, 0.2f);
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
        Overlord.timer = Time.fixedUnscaledTime;
        inGameTime.text = (" " + Overlord.timer.ToString("F4"));
        inGameScore.text = (" " + Overlord.currentScore.ToString());
        closeCall.text = ("Pass Bonus x" + multiplier.ToString());
        HighScore.text = (" " + PlayerPrefs.GetInt("HS"));
        ScaleBonus.text = ("Bonus Multiplier: x" + Overlord.scaleBonus/27);
        Weapon.sprite = aB.selectedWeaponImage;
    }

    public void CloseCall()
    {
        multiplier++;
        closeCall.gameObject.SetActive(true);
        Overlord.MultiUpdate(multiplier);
        Overlord.ScoreCloseCall(multiplier);
        closeCallTimer = closeCallTimer + 0.78f;
    }

    public void Color()
    {
        Color newColor = new Color(Random.Range(0, 10), 0, Random.Range(0, 10), 1.8f);
        crimeBonus.canvasRenderer.SetColor(newColor);
    }

    public IEnumerator text()
    {
        crimeBonus.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        crimeBonus.gameObject.SetActive(false);
    }
}
