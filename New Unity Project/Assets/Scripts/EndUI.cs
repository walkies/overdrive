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

    public AudioEffectSO shot;

    void Start()
    {
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
        yield return new WaitForSeconds(1);
        score.gameObject.SetActive(true);
        //badges
        yield return new WaitForSeconds(1);
        time.gameObject.SetActive(true);
        //badges
        yield return new WaitForSeconds(1);
        weapUsed.gameObject.SetActive(true);
        //badges
        yield return new WaitForSeconds(1);
        crimeSolved.gameObject.SetActive(true);
        //badges
        yield return new WaitForSeconds(1);
        Casual.gameObject.SetActive(true);
        //badges
        yield return new WaitForSeconds(1);
        evasive.gameObject.SetActive(true);
        //badges
        yield return new WaitForSeconds(1);
        //Stamp
    }


}
