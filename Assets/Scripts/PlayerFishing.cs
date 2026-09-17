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

    private void Update()
    {
        Debug.Log(casted);

        if (Input.GetMouseButtonDown(0)) 
        {
            if(casted == false)
            {
                casted = true;
                Rigidbody cast = Instantiate(rb, transform.position, transform.rotation);
                cast.velocity = transform.forward * speed;
                bobber = GameObject.FindWithTag("bobber");
                fishReturn = bobber.GetComponent<FishReturn>();
                
            } else if (casted == true)
            {
                if(fishReturn != null)
                {
                    if(fishReturn.fish == true && QTE == false)
                    {
                       QTE = true;
                       fishReturn.QTESpawn();

                    } else if (fishReturn.fish == false)
                    {
                        fishReturn.ret = true;
                        StartCoroutine(DestroyBob());
                    }
                                        
                }
            }    
        }

        if(failed == true)
        {
            StartCoroutine(DestroyBob());
        }

    }

    IEnumerator DestroyBob()
    {

        yield return new WaitForSeconds(1.5f);
        
        Destroy(bobber);
        casted = false;
        failed = false;

    }



}
