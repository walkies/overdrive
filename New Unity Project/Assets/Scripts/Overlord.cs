using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Overlord
{
    public static int LeftWallIndex = 0;
    public static int RightWallIndex = 5;
    public static int RoadIndex = 9;
    public static int RoofIndex = 13;
    
    public static int roadCheck = 0;
    public static int roofCheck = 0;
    public static int leftWallCheck = 0;
    public static int rightWallCheck = 0;


    public static void updateRoadIndex()
    {
        roadCheck++;
        if (roadCheck % 3 == 0)
        {
            RoadIndex++;
        }
    }
    public static void updateRoofIndex()
    {
        roofCheck++;
        if (roofCheck % 3 == 0)
        {
            RoofIndex++;
        }
    }
    public static void updateLeftWallIndex()
    {
        leftWallCheck++;
        if (leftWallCheck % 3 == 0)
        {
            LeftWallIndex++;
        }
    }
    public static void updateRightWallIndex()
    {
        rightWallCheck++;
        if (rightWallCheck % 3 == 0)
        {
            RightWallIndex++;
        }
    }
    ///<summary>
    ///Called by each spawning lane
    ///Once all have been called 
    ///Indexs by one for new variables 
    /// </summary>
  

}
