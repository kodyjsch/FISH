using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishReturn : MonoBehaviour
{
    private GameObject pole;
    private Rigidbody rb;
    public float speed = 10;

    public bool ret;
    public bool fish;

    private FishList list;

    public int chosenFish;

    public GameObject bubble;
    private GameObject instance;

    public GameObject QTESys;

    public GameObject tut;
    public tutorialText tT;

    public AudioSource splash;
    public bool inWater = false;

    public bool sad;
    public Sprite wormSad;
    public SpriteRenderer sR;

    public static GameObject bobber;

    public FishDetails fD;
    public GameObject boss;

    private void Start()
    {
        ret = false;
        fish = false;
        sad = false;

        if(bobber != null)
        {
            Destroy(gameObject);
        } else
        {
            bobber = gameObject;
        }

        pole = GameObject.FindWithTag("pole");
        rb = GetComponent<Rigidbody>();
        list = GameObject.FindWithTag("list").GetComponent<FishList>();
        chosenFish = Random.Range(0, list.fishNumber);
        fD = list.fishPrefabs[chosenFish].GetComponent<FishDetails>();
        tut = GameObject.FindWithTag("tutorial");
        if(tut != null)
        {
           tT = tut.GetComponent<tutorialText>();
        }
        boss = GameObject.FindWithTag("boss");
        sR = GetComponentInChildren<SpriteRenderer>();
    }

    public void fishSpawn()
    {
        fish = true;
        instance = Instantiate(bubble, transform.position, Quaternion.identity);
    }

    IEnumerator fishDelayer()
    {
        yield return new WaitForSeconds(Random.Range(3, list.maxWait));
        fishSpawn();
    }

    public void LineReturn()
    {
        ret = true;

        if(tut == null && boss == null)
        {
            GameObject childObj = Instantiate(list.fishPrefabs[chosenFish], transform);
        } else
        { 
            GameObject childObj = Instantiate(list.dialogueSprite, transform);
        }
        
    }

    public void QTESpawn()
    {
        Instantiate(QTESys, transform.position, Quaternion.identity);
    }

    void Update()
    {

        if (ret == true)
        {
            if (sad == true)
            {
                if(tT != null)
                {
                  tT.ready = true;
                }

                sR.sprite = wormSad;
            }

            KillBubbles();

            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, pole.transform.position, step);

        }
    }

    public void KillBubbles()
    {
        if (instance != null)
        {
            Destroy(instance);
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
