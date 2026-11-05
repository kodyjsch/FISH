using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishList : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    public List<bool> firstCatch;

    private static GameObject list;

    public float maxWait;
    public float qteLength;
    public int fishNumber;

    public bool day2 = false;
    public int fishCaught = 0;

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

        maxWait = 16;
        qteLength = 1.5f;
        fishNumber = 14;
    }

}
