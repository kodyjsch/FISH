using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) 
        {

            StartCoroutine(castDelay());
        }

        if(failed == true)
        {
            StartCoroutine(DestroyBob());
        }

    }

    IEnumerator DestroyBob()
    {

        yield return new WaitForSeconds(3f);
        
        Destroy(bobber);
        QTE = false;
        casted = false;
        failed = false;

        arms.ResetTrigger("Reel");
        arms.SetTrigger("Idle");

    }

    IEnumerator castDelay()
    {

        if (casted == false)
        {
            arms.ResetTrigger("Idle");
            arms.SetTrigger("Cast");
            yield return new WaitForSeconds(0.8f);
            casted = true;
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

                if (fishReturn.fish == true && QTE == false)
                {
                    QTE = true;
                    fishReturn.QTESpawn();

                }
                else if (fishReturn.fish == false)
                {
                    fishReturn.ret = true;
                    StartCoroutine(DestroyBob());
                }

            }
        }
    }



}
