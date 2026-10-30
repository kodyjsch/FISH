using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{

    public GameObject QTEText;
    public float num;

    public PlayerFishing pF;
    public FishReturn fR;

    public List<bool> nums = new List<bool>();

    public int correct;
    public bool fail = false;

    public int QTENum;
    public int QTETurn;

    string[] tagList = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };


    private void Awake()
    {
        pF = GameObject.Find("Caster").GetComponent<PlayerFishing>();
        fR = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();

        num = Random.Range(pF.fD.minQTE, pF.fD.maxQTE);

        for (int i = 0; i < num; i++)
        {
            GameObject newObj = Instantiate(QTEText, transform);
            newObj.tag = tagList[i];
            nums.Add(true);
        }

        QTENum = nums.Count;

    }

    private void Update()
    {


        if (fail == true)
        {
            StartCoroutine(failed());
        }
        else if (correct == QTENum)
        {
            StartCoroutine(succeeded());
        }


    }

    IEnumerator failed()
    {
        yield return new WaitForSeconds(1.5f);
        fR.sad = true;
        fR.ret = true;
        Destroy(gameObject);
    }

    IEnumerator succeeded()
    {
        yield return new WaitForSeconds(1.5f);
        fR.LineReturn();
        Destroy(gameObject);
    }

}