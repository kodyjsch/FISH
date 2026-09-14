using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishReturn : MonoBehaviour
{
    private GameObject pole;
    private Rigidbody rb;
    public float speed = 10;

    public bool ret = false;
    public bool fish = false;

    private FishList list;

    public int chosenFish;

    public ParticleSystem bubble;

    private void Awake()
    {
        pole = GameObject.FindWithTag("pole");
        rb = GetComponent<Rigidbody>();

        list = GameObject.FindWithTag("list").GetComponent<FishList>();

        chosenFish = Random.Range(0, list.fishPrefabs.Count);

        StartCoroutine(catchFish());
    }

    IEnumerator catchFish()
    {
        yield return new WaitForSeconds((Random.Range(3, 16)));
        fish = true;

        ParticleSystem instance = Instantiate(bubble, transform.position, Quaternion.identity);
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

        Debug.Log(fish);
    }

    
}
