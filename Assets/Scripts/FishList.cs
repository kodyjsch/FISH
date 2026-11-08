using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishList : MonoBehaviour
{
    public Rigidbody rb;

    public Rigidbody puffer;
    public Rigidbody disco;

    public List<GameObject> fishPrefabs;
    public List<bool> firstCatch;

    private static GameObject list;

    public float maxWait;
    public float qteLength;
    public int fishNumber;

    public bool day2 = false;
    public int fishCaught = 0;

    public GameObject dialogueSprite;
    public GameObject dialogueSplash;

    public GameObject manmer;
    public GameObject merman;

    public GameObject manmerSplash;
    public GameObject mermanSplash;

    private void Start()
    {
        if(list != null)
        {
            Destroy(gameObject);
        } else
        {
            list = gameObject;
        }

        DontDestroyOnLoad(gameObject);

        dialogueSprite = manmer;
        dialogueSplash = manmerSplash;

        maxWait = 16;
        qteLength = 2f;
        fishNumber = 14;
    }

}
