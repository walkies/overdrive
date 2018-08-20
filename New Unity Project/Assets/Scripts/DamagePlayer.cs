using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public UI uI;
    public PlayerMovement pM;
    public Camera mainCam;
    public GameObject endScreen;
    public AudioEffectSO aSO;
    public AudioEffectSO crash;
    public Health hp;
    private float currentTime;
    private bool timer = false;

    void Start ()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Health>();
        uI = FindObjectOfType<UI>();
        pM = FindObjectOfType<PlayerMovement>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        endScreen = GameObject.FindGameObjectWithTag("EndPanel");
    }
    public void Update()
    {
        if (timer == true && uI.timer >= currentTime)
        {
            Time.timeScale = 0;
            endScreen.transform.GetChild(0).gameObject.SetActive(true);
        }
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
                LeanTween.move(mainCam.gameObject, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 15), (15/pM.speed));
                timer = true;
                currentTime = uI.timer + 3;
            }
        }

        else if (col.gameObject.CompareTag("Sound"))
        {
            aSO.Play();
            uI.StartCoroutine("CloseCall");
        }
    }
}
