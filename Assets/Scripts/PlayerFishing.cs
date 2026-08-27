using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{
    public Rigidbody bobber;
    public float speed = 4;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Rigidbody cast = Instantiate(bobber, transform.position, transform.rotation);
            cast.velocity = transform.forward * speed;
        }

    }

    

}
