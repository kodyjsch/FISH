using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishReturn : MonoBehaviour
{
    private GameObject pole;
    private Rigidbody rb;
    public float speed = 10;

    private bool ret = false;

    private void Awake()
    {
        pole = GameObject.FindWithTag("pole");
        rb = GetComponent<Rigidbody>();
    }
    public void LineReturn()
    {
        Debug.Log("returned!");
        ret = true;

    }

    private void FixedUpdate()
    {
        if(ret == true)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, pole.transform.position, step);
        }
    }
}
