﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Overlord
{ 
    public static int roadAggression = 0;
    public static int roofAggression = 0;
    public static int leftWallAggression = 0;
    public static int rightWallAggression = 0;

    public static int powerUpMax = 200;
    public static int scaleBonus = 27;
    public static int activateReset = 3;
    public static int currentScore = 0;
    public static int HighScore;

    //End UI
    public static float timer;
    public static int weapUse;
    public static int Evasive;
    public static int casual;
    public static int crimesSolved;

    public static void updateRoadIndex()
    {
        if (roadAggression < 184)
        {
            roadAggression++;
            roadAggression++;
            roadAggression++;
        }
    }

    public static void updateRoofIndex()
    {
        if (roofAggression < 184)
        {
            roofAggression++;
            roofAggression++;
        }
    }

    public static void updateLeftWallIndex()
    {
        if (leftWallAggression < 184)
        {
            leftWallAggression++;
            leftWallAggression++;
        }
    }

    public static void updateRightWallIndex()
    {
        if (rightWallAggression < 184)
        {
            rightWallAggression++;
            rightWallAggression++;
        }
    }

    public static void MultiUpdate(int multiplier)
    {
       if(multiplier > Evasive)
        {
            Evasive = multiplier;
        }
    }

    public static void ActivateReset()
    {
        powerUpMax = powerUpMax + 5;
        activateReset++;
        scaleBonus++;
    }

    public static void ScoreOverTime()
    {
        currentScore++;
    }
    public static void ScoreCloseCall(int multiplier)
    {
        currentScore = currentScore + (multiplier * (100 * (scaleBonus/27)));
    }
    public static void ScoreOneLane()
    {
        currentScore++;
    }
    public static void ScoreDestroyTarget(int bonus)
    {
        currentScore = currentScore + (bonus * (scaleBonus/27));
    }
    public static void HighScoreUpdate()
    {
        HighScore = PlayerPrefs.GetInt("HS");
        if (HighScore < currentScore)
        {
            HighScore = currentScore;
            PlayerPrefs.SetInt("HS", HighScore);
        }
     
    }
}
