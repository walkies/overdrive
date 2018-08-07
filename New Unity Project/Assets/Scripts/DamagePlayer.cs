using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Health hp;
    public PlayerMovement pM;
    public Camera mainCam;
    public Canvas endScreen;
    public AudioEffectSO aSO;
    public AudioEffectSO crash;

    void Start ()
    {
        hp = FindObjectOfType<Health>();
        pM = FindObjectOfType<PlayerMovement>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        endScreen = FindObjectOfType<Canvas>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hp.health--;
            if (hp.health <= 0)
            {
                Destroy(col.gameObject.GetComponentInParent<Player>());
                Destroy(col.gameObject.GetComponentInParent<PlayerMovement>());
                crash.Play();
                mainCam.transform.parent = null;
                StartCoroutine("TimeTillEnd");
                LeanTween.move(mainCam.gameObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 15), (15/pM.speed));
            }
        }
        else if (col.gameObject.CompareTag("Sound"))
        {
            aSO.Play();
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
