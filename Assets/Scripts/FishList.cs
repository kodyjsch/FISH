using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishList : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    public List<bool> firstCatch;


    public float maxWait;
    public float qteLength;
    public int fishNumber;

    public bool day2 = true;
    public int fishCaught = 0;

    private void Start()
    {
        maxWait = 16;
        qteLength = 1.0f;
        fishNumber = 14;
    }

}
