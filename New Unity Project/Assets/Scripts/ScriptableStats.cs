using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Stats")]
public class ScriptableStats : ScriptableObject
{
    public float Acceleration;
    public float topSpeed;
    public Specials thisSpecial;
    public int cooldownTime;
    public int activeTime;

    public enum Specials
    {
        Sturdy,
        Turbo,
        Reflex,
        Nimble,
        Sirens
    }
}
