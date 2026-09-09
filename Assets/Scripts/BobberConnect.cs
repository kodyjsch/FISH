using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobberConnect : MonoBehaviour
{
    SpringJoint joint;
    private GameObject bobber;


    void Awake()
    {
        joint = GetComponent<SpringJoint>();
        bobber = GameObject.FindWithTag("bobber");

        joint.connectedBody = bobber.GetComponent<Rigidbody>();
    }

}
