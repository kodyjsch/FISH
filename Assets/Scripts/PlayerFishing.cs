using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 4;

    public bool casted = false;
    private GameObject bobber;
    private FishReturn fishReturn;

    private void Update()
    {
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
                    fishReturn.LineReturn();
                }
            }    
        }

    }

    

}
