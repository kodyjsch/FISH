using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{

    public GameObject QTEText;
    public int num;

    public PlayerFishing pF;
    public FishReturn fR;
    public GameObject tutorial;

    public List<bool> nums = new List<bool>();

    public int correct;
    public bool fail = false;

    public int QTENum;
    public int QTETurn;

    public bool TimeOut = false;
    public AudioSource oOT;

    string[] tagList = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };

    private BossMechanics bM;


    private void Start()
    {
        pF = GameObject.Find("Caster").GetComponent<PlayerFishing>();
        fR = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();
        tutorial = GameObject.FindWithTag("tutorial");

        if(tutorial != null)
        {
            num = 3;
        } else
        {
            num = Random.Range(pF.fD.minQTE, pF.fD.maxQTE);
        }
            

        for (int i = 0; i < num; i++)
        {
            GameObject newObj = Instantiate(QTEText, transform);
            newObj.tag = tagList[i];
            nums.Add(true);
        }

        QTENum = nums.Count;

        bM = GameObject.FindWithTag("mech").GetComponent<BossMechanics>();

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
        if(bM != null)
        {
           bM.LoseALife();
        }
        Destroy(gameObject);
    }

    IEnumerator succeeded()
    {
        yield return new WaitForSeconds(1.5f);
        fR.LineReturn();
        Destroy(gameObject);
    }

}