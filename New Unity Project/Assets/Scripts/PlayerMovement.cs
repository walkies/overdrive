﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LaneBonus lB;
    public UI uI;
    public ScriptableStats sS;
    public Abilities ability;
    public int currentLane = 1;
    public float speed;
    private float timeCount;
    public float lockOut;
    public float oneLaneBonus;
    public GameObject leftB;
    public GameObject rightB;

    void Awake()
    {
        Overlord.currentScore = 0;
        Overlord.timer = 0;
        Overlord.weapUse = 0;
        Overlord.crimesSolved = 0;
        Overlord.Evasive = 0;
        Overlord.casual = 0;
    }

    void Start()
    {

        uI = FindObjectOfType<UI>();
    }

    void Update()
    {
        Overlord.ScoreOverTime();
        timeCount = (3 / speed);
        #region LaneBonus
        if (Input.anyKeyDown != true)
        {
            oneLaneBonus += Time.deltaTime;
            if (oneLaneBonus >= 5)
            {
                uI.ScoreLaneBonus.gameObject.SetActive(true);
                Overlord.ScoreOneLane();
            }
        }
        else
        {
            lB.Switch = false;
            uI.ScoreLaneBonus.gameObject.SetActive(false);
            oneLaneBonus = 0;
        }
        #endregion

        #region blinkers
        if (currentLane == 2 && speed > 8 && speed < 16)
        {
            StartCoroutine("LeftIndi");
        }
        if (currentLane == 0 && speed > 8 && speed < 20)
        {
            StartCoroutine("RightIndi");
        }
        #endregion

        #region Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ability.ActivateWeapon();
        }  

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time > lockOut)
        {
            if (currentLane == 2)
            {
                if (speed >= 8)
                {     
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x +1.5f, transform.position.y+1.5f, transform.position.z), (12 / speed));
                lockOut = Time.time + (12 / speed);
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 270), (12 / speed));
                currentLane++;
                }
            }
            else if (currentLane == 5)
            {
                if (speed >= 12)
                {
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x - 1.5f, transform.position.y + 1.5f, transform.position.z), (12 / speed));
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 180), (12 / speed));
                lockOut = Time.time + (12 / speed);
                currentLane++;
                }
            }
            else if (currentLane == 8)
            {
                if (speed >= 12)
                {
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x - 1.5f, transform.position.y - 1.5f, transform.position.z), (12 / speed));
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 90), (12 / speed));
                lockOut = Time.time + (12 / speed);
                currentLane++;
                }
            }
            else if (currentLane == 11)
            {
                if (speed >= 8)
                {
                lockOut = Time.time + (12 / speed);
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x + 1.5f, transform.position.y - 1.5f, transform.position.z), (12 / speed));
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 0), (12 / speed));
                currentLane = 0;
                }
            }
            else if (currentLane >= 0 && currentLane <= 1)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane++;         
            }
            else if (currentLane >= 3 && currentLane <= 4)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane++;
            }
            else if (currentLane >= 6 && currentLane <= 7)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane++;
            }
            else if (currentLane >= 9 && currentLane <= 11)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y -1, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane++;
            }
        }

        ///<summary>
        /// When left is pressed, if it hasnt been pressed recently for toggle rotation then do it
        /// If a sidelane and vehicle is past a certain speed, leantween to rotation, set lockout time
        /// If the lane is the end of the array, revert to 0 (ie cycle through)
        /// if the lane is a base lane, just get the current lane ++
        ///</summary>

        else if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time > lockOut)
        {
            if (currentLane == 0)
            {
                if (speed >= 8)
                {            
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x - 1.5f, transform.position.y + 1.5f, transform.position.z), (12 / speed));
                lockOut = Time.time + (12 / speed);
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 90), (12 / speed));
                currentLane = 11;
                }
            }
            else if (currentLane == 9)
            {
                lockOut = Time.time + timeCount;
                if (speed >= 12)
                {
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x + 1.5f, transform.position.y + 1.5f, transform.position.z), (12 / speed));
                lockOut = Time.time + (12 / speed);
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 180), (12 / speed));
                currentLane--;
                }
            }
            else if (currentLane == 6)
            {
                if (speed >= 12)
                {
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x + 1.5f, transform.position.y - 1.5f, transform.position.z), (12 / speed));
                lockOut = Time.time + (12 / speed);
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 270), (12 / speed));
                currentLane--;
                }
            }
            else if (currentLane == 3)
            {
                if (speed >= 8)
                {
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x - 1.5f, transform.position.y - 1.5f, transform.position.z), (12 / speed));
                lockOut = Time.time + (12 / speed);
                LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 180, 0), (12 / speed));
                currentLane--;
                }
            }
            else if (currentLane >= 1 && currentLane <= 2)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane--;
            }
            else if (currentLane >= 4 && currentLane <= 5)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane--;
            }
            else if (currentLane >= 7 && currentLane <= 8)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane--;
            }
            else if (currentLane >= 10 && currentLane <= 11)
            {
                lockOut = Time.time + timeCount;
                LeanTween.moveLocal(gameObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), (3 / speed)).setEase(LeanTweenType.easeOutBack);
                currentLane--;
            }
        }
        #endregion

        ///<summary>
        /// When right is pressed, if it hasnt been pressed recently for toggle rotation then do it
        /// If a sidelane and vehicle is past a certain speed, leantween to rotation, set lockout time
        /// If the lane is the start of the array, change to 11 (ie cycle through)
        /// if the lane is a base lane, just get the current lane --
        ///</summary>

        if (speed <= sS.topSpeed)
        {
            speed += Time.deltaTime * sS.Acceleration;
        }
        ///<summary>
        /// speed is equal to accleration over time
        ///</summary>
    }
    public IEnumerator LeftIndi()
    {
        leftB.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        leftB.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        leftB.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        leftB.SetActive(false);
    }

    public IEnumerator RightIndi()
    {
        rightB.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        rightB.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        rightB.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        rightB.SetActive(false);
    }
}


