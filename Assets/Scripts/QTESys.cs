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

    string[] tagList = { "one", "two", "three" };


    private void Awake()
    {
        pF = GameObject.Find("Caster").GetComponent<PlayerFishing>();
        fR = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();

        num = Random.Range(1, 4);

        for(int i = 0; i < num; i++)
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
        fR.ret = true;
        pF.failed = true;
        Destroy(gameObject);
    }

    IEnumerator succeeded()
    {
        yield return new WaitForSeconds(1.5f);
        fR.LineReturn();
        pF.QTE = false;
        Destroy(gameObject);
    }

}
