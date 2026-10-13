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

    public GameObject tut;

    public AudioSource splash;
    public bool inWater = false;

    private void Awake()
    {
        pole = GameObject.FindWithTag("pole");
        rb = GetComponent<Rigidbody>();

        list = GameObject.FindWithTag("list").GetComponent<FishList>();

        chosenFish = Random.Range(0, list.fishPrefabs.Count);

        tut = GameObject.FindWithTag("tutorial"); 

    }

    public void fishSpawn()
    {
        fish = true;
        instance = Instantiate(bubble, transform.position, Quaternion.identity);
    }

    IEnumerator fishDelayer()
    {
        yield return new WaitForSeconds(Random.Range(5, 16));
        fishSpawn();
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water") && inWater == false)
        {
            splash.Play();
            inWater = true;

            if (tut == null)
            {
                StartCoroutine(fishDelayer());
            }

        }
    }


}
