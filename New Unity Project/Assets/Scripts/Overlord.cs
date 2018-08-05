using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Overlord
{ 
    public static int roadAggression = 0;
    public static int roofAggression = 0;
    public static int leftWallAggression = 0;
    public static int rightWallAggression = 0;

    public static void updateRoadIndex()
    {
        roadAggression++;
        roadAggression++;
        roadAggression++;
    }

    public static void updateRoofIndex()
    {
        roofAggression++;
        roofAggression++;
    }

    public static void updateLeftWallIndex()
    {
        leftWallAggression++;
        leftWallAggression++;
    }

    public static void updateRightWallIndex()
    {
        rightWallAggression++;
        rightWallAggression++;
    }
}
