using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 4;
    public bool QTE = false;
    public bool casted = false;
    public bool failed = false;
    private GameObject bobber;
    private FishReturn fishReturn;

    public Animator arms;
    public AudioSource swoosh;
    public AudioSource reel;

    public FishDetails fD;


    private void OnEnable()
    {
        StartCoroutine(pause());
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(castDelay());
        }

    }


    IEnumerator castDelay()
    {

        if (casted == false)
        {
            casted = true;
            arms.ResetTrigger("Idle");
            arms.SetTrigger("Cast");
            yield return new WaitForSeconds(0.8f);
            swoosh.Play();
            Rigidbody cast = Instantiate(rb, transform.position, transform.rotation);
            cast.velocity = transform.forward * speed;
            bobber = GameObject.FindWithTag("bobber");
            fishReturn = bobber.GetComponent<FishReturn>(); 

        }
        else if (casted == true)
        {

            if (fishReturn != null)
            {

                arms.ResetTrigger("Cast");
                arms.SetTrigger("Reel");

                if (!reel.isPlaying)
                {
                    reel.Play();
                }

                if (fishReturn.fish == true && QTE == false)
                {
                    QTE = true;
                    fD = fishReturn.fD;
                    fishReturn.QTESpawn();

                }
                else if (fishReturn.fish == false)
                {
                    fishReturn.ret = true;
                    fishReturn.sad = true;
                }

            }
        }
    }

    private IEnumerator pause()
    {
        yield return null;
    }



}
