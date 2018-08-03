using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ScriptableStats sS;

    public float reachDistance = 1f;
    private float rotationspeed = 2f;
    public int currentLane = 1;
    public float speed;
    private float timeCount = 1.0f;
    public float lockOut;


    void Start()
    {

    }

    void Update()
    {
        #region Input
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time > lockOut)
        {
  
            if (currentLane == 2)
            {
                // if (speed >= 5.5)
                //  {     

                //LeanTween.move(gameObject, new Vector3(transform.position.x +1.5f, transform.position.y+1.5f, transform.position.z), 4);
                lockOut = Time.time + timeCount;
                //LeanTween.rotate(gameObject.transform.GetChild(0).gameObject, new Vector3(0, 0, 90), 4);
                currentLane++;
                //}
            }
            else if (currentLane == 5)
            {

                //  if (speed >= 8)
                // {
                transform.position -= transform.right * Time.deltaTime * speed;
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 180), rotationspeed / speed);
                lockOut = Time.time + timeCount;

                // }
            }
            else if (currentLane == 8)
            {
                //if (speed >= 8)
                // {
                transform.position -= transform.right * Time.deltaTime * speed;
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 90f), rotationspeed / speed);
                lockOut = Time.time + timeCount;

                //}
            }
            else if (currentLane == 11)
            {
                //if (speed >= 5.5)
                //{
                transform.position = Vector3.MoveTowards(transform.position, transform.right, speed);
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 0f), (rotationspeed / speed));
                lockOut = Time.time + timeCount;
                currentLane = 0;
                // }
            }
            else if (currentLane >= 0 && currentLane <= 1)
            {
                transform.position = Vector3.Lerp(transform.position, (transform.position + -transform.right), (2));
                currentLane++;         
            }
            else if (currentLane >= 3 && currentLane <= 4)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.right, (Time.deltaTime * speed));
            }
            else if (currentLane >= 6 && currentLane <= 7)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.right, (Time.deltaTime * speed));
            }
            else if (currentLane >= 9 && currentLane <= 11)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.right, (Time.deltaTime * speed));
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
            currentLane--;
            if (currentLane == 0)
            {
                // if (speed >= 5.5)
                // {
                transform.position += transform.right * Time.deltaTime * speed;
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 90f), rotationspeed / speed);
                lockOut = Time.time + timeCount;

                currentLane = 11;
                //  }
            }
            else if (currentLane == 9)
            {
                lockOut = Time.time + timeCount;
                // if (speed >= 8)
                // {
                transform.position += transform.right * Time.deltaTime * speed;
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 180f), rotationspeed / speed);
                lockOut = Time.time + timeCount;

                //}
            }
            else if (currentLane == 6)
            {
                // if (speed >= 8)
                // {
                transform.position += transform.right * Time.deltaTime * speed;
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 270f), rotationspeed / speed);
                lockOut = Time.time + timeCount;

                // }
            }
            else if (currentLane == 3)
            {
                //if (speed >= 5.5)
                // {
                transform.position += transform.right * Time.deltaTime * speed;
                LeanTween.rotate(gameObject, new Vector3(0, 180f, 0f), (rotationspeed / speed));
                lockOut = Time.time + timeCount;

                //}
            }
            else if (currentLane >= 1 && currentLane <= 2)
            {

            }
            else if (currentLane >= 4 && currentLane <= 5)
            {

            }
            else if (currentLane >= 7 && currentLane <= 8)
            {

            }
            else if (currentLane >= 10 && currentLane <= 11)
            {

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
}


