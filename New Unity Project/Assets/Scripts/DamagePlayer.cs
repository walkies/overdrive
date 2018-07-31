using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public PlayerMovement pM;
    public Camera mainCam;
    public Canvas endScreen;

	void Start ()
    {
        pM = FindObjectOfType<PlayerMovement>();
        mainCam = FindObjectOfType<Camera>();
        endScreen = FindObjectOfType<Canvas>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pM.sS.Health--;
            if (pM.sS.Health <= 0)
            {
                Destroy(col.gameObject.GetComponentInChildren<Player>());
                Destroy(col.gameObject.GetComponentInChildren<PlayerMovement>());
                mainCam.transform.parent = null;
                StartCoroutine("TimeTillEnd");
                LeanTween.move(mainCam.gameObject, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 15), 3);
            }
        }
    }
    
    public IEnumerator TimeTillEnd()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        endScreen.transform.GetChild(0).gameObject.SetActive(true);
        StopCoroutine("TimeTillEnd");
    }
}
