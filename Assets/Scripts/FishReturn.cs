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

    public GameObject bubble;
    private GameObject instance;

    public GameObject QTESys;

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

        instance = Instantiate(bubble, transform.position, Quaternion.identity);
    }
    public void LineReturn()
    {
        ret = true;

        GameObject childObj = Instantiate(list.fishPrefabs[chosenFish], transform);
        

    }

    public void QTESpawn()
    {
        Instantiate(QTESys, transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        if(ret == true)
        {
            if(instance != null)
            {
                Destroy(instance);
            }            

            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, pole.transform.position, step);

           
        }

        
    }

    
}
