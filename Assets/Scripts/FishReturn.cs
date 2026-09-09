using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishReturn : MonoBehaviour
{
    private GameObject pole;
    private Rigidbody rb;
    public float speed = 10;

    private bool ret = false;

    private FishList list;

    public int chosenFish;

    private void Awake()
    {
        pole = GameObject.FindWithTag("pole");
        rb = GetComponent<Rigidbody>();

        list = GameObject.FindWithTag("list").GetComponent<FishList>();

        chosenFish = Random.Range(0, list.fishPrefabs.Count);
    }
    public void LineReturn()
    {
        Debug.Log("returned!");
        ret = true;

        GameObject childObj = Instantiate(list.fishPrefabs[chosenFish], transform);

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
