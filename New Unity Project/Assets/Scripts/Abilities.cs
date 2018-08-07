using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Abilities : MonoBehaviour
{
    public States currentState;
    public PlayerMovement pM;

    void Start()
    {
        pM = GetComponent<PlayerMovement>();
    }

    public enum States
    {
        Charging,
        Ready
    }

    void Update()
    {
        Debug.Log(currentState);
        switch (currentState)   //Switch between states 
        {
            case (States.Charging):
                break;
            case (States.Ready):
                break;
        }
    }
    public void ActivateAbility(string abilityName)
    {
        if (currentState == States.Ready)
        {
            if (abilityName == "Sturdy")
            {
                StartCoroutine("Sturdy");
            }
            currentState = States.Charging;
        }

        if (currentState == States.Charging)
        {
            StartCoroutine("Cooldown");
        }
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(pM.sS.cooldownTime);
        currentState = States.Ready;
        StopCoroutine("Cooldown");
    }

    public IEnumerator Sturdy()
    {
        pM.GetComponentInChildren<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(pM.sS.activeTime);
        pM.GetComponentInChildren<BoxCollider>().enabled = true;
        StopCoroutine("Sturdy");
    }
}
