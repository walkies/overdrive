using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Stats")]
public class ScriptableStats : ScriptableObject
{
    public int Health;
    public float Acceleration;
    public float topSpeed;
    public float laneSwitch;
    public Specials thisSpecial;

    public enum Specials
    {
        Sturdy,
        Turbo,
        Reflex,
        Nimble,
        Sirens
    }
}
