using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Overlord
{ 
    public static int roadAggression = 0;
    public static int roofAggression = 0;
    public static int leftWallAggression = 0;
    public static int rightWallAggression = 0;

    public static int activateReset = 3;

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

    public static void ActivateReset()
    {
        activateReset++;
    }
}
