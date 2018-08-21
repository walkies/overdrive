using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    public Text score;
    public Text time;
    public Text weapUsed;
    public Text crimeSolved;
    public Text evasive;
    public Text Casual;

    [Header ("Time")]
    public Image timeBadge;
    public Sprite[] TimeB;
    private int timeTotal;
    [Header("Weapon")]
    public Image weapBadge;
    public Sprite[] WeapB;
    private int weapTotal;
    [Header("Crime")]
    public Image crimeBadge;
    public Sprite[] CrimeB;
    private int crimeTotal;
    [Header("Evasive")]
    public Image evasBadge;
    public Sprite[] EvasB;
    private int evasTotal;
    [Header("Civil")]
    public Image civBadge;
    public Sprite[] CivilB;
    private int civilTotal;

    public AudioSource shot;
    public GameObject stamp;
    public Text endresult;
    public GameObject endresultbox;
    public AudioSource stamped;

    void Awake()
    {
        Time.timeScale = 1;    
    }

    void Start()
    {
        TimeToBadge();
        WeapToBadge();
        CrimeToBadge();
        EvasToBadge();
        CivilToBadge();
        StartCoroutine("EndRoutine");    
    }

    void Update ()
    {
        score.text = (" " + Overlord.currentScore.ToString());
        time.text = (" " + Overlord.timer.ToString("F4"));
        weapUsed.text = (" " + Overlord.weapUse);
        crimeSolved.text = (" " + Overlord.crimesSolved);
        evasive.text = (" " + Overlord.Evasive);
        Casual.text = (" " + Overlord.casual);
    }

    public IEnumerator EndRoutine()
    {
        #region DisplayScore
        yield return new WaitForSeconds(2);
        score.gameObject.SetActive(true);
        shot.Play();
        shot.pitch += 0.02f;
        yield return new WaitForSeconds(1);
        time.gameObject.SetActive(true);
        shot.Play();
        shot.pitch += 0.02f;
        for (int i = 0; i < (timeTotal +1); i++)
        {
            timeBadge.sprite = TimeB[i];
            shot.Play();
            shot.pitch += 0.02f;
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1);
        weapUsed.gameObject.SetActive(true);
        shot.Play();
        shot.pitch += 0.02f;
        for (int i = 0; i < (weapTotal + 1); i++)
        {
            weapBadge.sprite = WeapB[i];
            shot.Play();
            shot.pitch += 0.02f;
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1);
        crimeSolved.gameObject.SetActive(true);
        shot.Play();
        shot.pitch += 0.02f;
        for (int i = 0; i < (crimeTotal + 1); i++)
        {
            crimeBadge.sprite = CrimeB[i];
            shot.Play();
            shot.pitch += 0.02f;
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1);
        evasive.gameObject.SetActive(true);
        shot.Play();
        shot.pitch += 0.02f;
        for (int i = 0; i < (evasTotal + 1); i++)
        {
            evasBadge.sprite = EvasB[i];
            shot.Play();
            shot.pitch += 0.02f;
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1);
        Casual.gameObject.SetActive(true);
        shot.Play();
        shot.pitch += 0.02f;
        for (int i = 0; i < (civilTotal + 1); i++)
        {
            civBadge.sprite = CivilB[i];
            shot.Play();
            shot.pitch += 0.02f;
            yield return new WaitForSeconds(0.5f);
        }
        #endregion

        #region DrainScore
        yield return new WaitForSeconds(1);
        int time2 = Mathf.RoundToInt(Overlord.timer);
        Overlord.timer = Mathf.RoundToInt(Overlord.timer);
        for (int i = 0; i < time2; i++)
        {
            shot.Play();
            shot.pitch += 0.02f;
            Overlord.timer--;
            Overlord.currentScore += 200;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1);
        float weap = Overlord.weapUse;
        for (int i = 0; i < weap; i++)
        {
            shot.Play();
            shot.pitch += 0.02f;
            Overlord.weapUse--;
            Overlord.currentScore += 5000;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1);
        float crimes = Overlord.crimesSolved;
        for (int i = 0; i < crimes; i++)
        {
            shot.Play();
            shot.pitch += 0.02f;
            Overlord.crimesSolved--;
            Overlord.currentScore += 10000;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1);
        float evas = Overlord.Evasive;
        for (int i = 0; i < evas; i++)
        {
            shot.Play();
            shot.pitch += 0.02f;
            Overlord.Evasive--;
            Overlord.currentScore += 2000;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1);
        float civil = Overlord.casual;
        for (int i = 0; i < civil; i++)
        {
            shot.Play();
            shot.pitch += 0.02f;
            Overlord.casual--;
            Overlord.currentScore -= 1000;
            yield return new WaitForSeconds(0.05f);
        }
        #endregion
        yield return new WaitForSeconds(1);
        LeanTween.move(stamp, new Vector3(stamp.transform.position.x, stamp.transform.position.y, stamp.transform.position.z + 0.7f), 1.2f);
        yield return new WaitForSeconds(1.1f);
        stamped.Play();
        ScoreToStamp();    
        endresultbox.SetActive(true);
        yield return new WaitForSeconds(1);
        LeanTween.move(stamp, new Vector3(stamp.transform.position.x, stamp.transform.position.y, stamp.transform.position.z - 0.7f), 1.2f);
        yield return new WaitForSeconds(2);
    }

    public void TimeToBadge()
    {
        if (Overlord.timer < 60)
        {
            timeTotal = 0;
        }
        else if (Overlord.timer < 120)
        {
            timeTotal = 1;
        }
        else if (Overlord.timer < 180)
        {
            timeTotal = 2;
        }
        else if (Overlord.timer < 240)
        {
            timeTotal = 3;
        }
        else if (Overlord.timer < 300)
        {
            timeTotal = 4;
        }
        else if (Overlord.timer >= 360)
        {
            timeTotal = 5;
        }
    }

    public void WeapToBadge()
    {
        if (Overlord.weapUse < 1)
        {
            weapTotal = 0;
        }
        else if (Overlord.weapUse < 2)
        {
            weapTotal = 1;
        }
        else if (Overlord.weapUse < 3)
        {
            weapTotal = 2;
        }
        else if (Overlord.weapUse < 4)
        {
            weapTotal = 3;
        }
        else if (Overlord.weapUse < 5)
        {
            weapTotal = 4;
        }
        else if (Overlord.weapUse >= 6)
        {
            weapTotal = 5;
        }
    }

    public void CrimeToBadge()
    {
        if (Overlord.crimesSolved < 1)
        {
            crimeTotal = 0;
        }
        else if (Overlord.crimesSolved < 2)
        {
            crimeTotal = 1;
        }
        else if (Overlord.crimesSolved < 3)
        {
            crimeTotal = 2;
        }
        else if (Overlord.crimesSolved < 4)
        {
            crimeTotal = 3;
        }
        else if (Overlord.crimesSolved < 5)
        {
            crimeTotal = 4;
        }
        else if (Overlord.crimesSolved >= 6)
        {
            crimeTotal = 5;
        }
    }

    public void EvasToBadge()
    {
        if (Overlord.Evasive < 3)
        {
            evasTotal = 0;
        }
        else if (Overlord.Evasive < 8)
        {
            evasTotal = 1;
        }
        else if (Overlord.Evasive < 13)
        {
            evasTotal = 2;
        }
        else if (Overlord.Evasive < 18)
        {
            evasTotal = 3;
        }
        else if (Overlord.Evasive < 23)
        {
            evasTotal = 4;
        }
        else if (Overlord.Evasive >= 28)
        {
            evasTotal = 5;
        }
    }

    public void CivilToBadge()
    {
        if (Overlord.casual < 1)
        {
            civilTotal = 0;
        }
        else if (Overlord.casual < 2)
        {
            civilTotal = 1;
        }
        else if (Overlord.casual < 3)
        {
            civilTotal = 2;
        }
        else if (Overlord.casual < 4)
        {
            civilTotal = 3;
        }
        else if (Overlord.casual < 8)
        {
            civilTotal = 4;
        }
        else if (Overlord.casual >= 10)
        {
            civilTotal = 5;
        }
    }

    public void ScoreToStamp()
    {
        if (Overlord.currentScore <= 10000)
        {
            endresult.text = "CADET";
        }
        else if (Overlord.currentScore <= 40000)
        {
            endresult.text = "ROOKIE";
        }
        else if (Overlord.currentScore <= 80000)
        {
            endresult.text = "REGULAR COP";
        }
        else if (Overlord.currentScore <= 100000)
        {
            endresult.text = "FUTURE COP";
        }
        else if (Overlord.currentScore <= 200000)
        {
            endresult.text = "ROBOCOP";
        }
        else if (Overlord.currentScore <= 400000)
        {
            endresult.text = "BADASS";
        }
        else if (Overlord.currentScore <= 800000)
        {
            endresult.text = "INSANE";
        }
        else if (Overlord.currentScore <= 1200000)
        {
            endresult.text = "LEGENDARY";
        }
        else if (Overlord.currentScore <= 1600000)
        {
            endresult.text = "RENEGADE";
        }
        else if (Overlord.currentScore <= 2000000)
        {
            endresult.text = "MAX 0'VERDRIVE";
        }
        else if (Overlord.currentScore >= 3000000)
        {
            endresult.text = "MAXXX 0'VERDRIVE";
        }
    }
}
