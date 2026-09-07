using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public Rigidbody bobber;
    public float speed = 4;

    private bool casted = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if(casted == false)
            {
                casted = true;
                Rigidbody cast = Instantiate(bobber, transform.position, transform.rotation);
                cast.velocity = transform.forward * speed;
                
            }      
        }

    }

    

}
