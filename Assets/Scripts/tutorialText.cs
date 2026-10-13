using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class tutorialText : MonoBehaviour
{
    public List<string> TutorialLines;

    public TMP_Text tutText;
    public GameObject txt;

    private FishReturn fR;
    private bool ready = false;
    private bool final = false;

    private void Start()
    {
        StartCoroutine(started());
    }

    IEnumerator started()
    {
        yield return new WaitForSeconds(3.0f);

        for (int i = 0; i < ((TutorialLines.Count) - 1); i++)
        {
            tutText.text = TutorialLines[i];
            txt.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            txt.SetActive(false);
            yield return new WaitForSeconds(3.0f);
        }

        ready = true;
    }

    IEnumerator cast()
    {
        ready = false;
        yield return new WaitForSeconds(3.0f);

        if(fR.ret == false)
        {
            fR.fishSpawn();
            final = true;
        } else
        {
            ready = true;
        }
    }

    IEnumerator finalText()
    {
        tutText.text = TutorialLines[3];
        txt.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        txt.SetActive(false);
        Destroy(gameObject);
    }

    private void Update()
    {

        if (GameObject.FindWithTag("bobber") == null)
            return;
        fR = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();

        if (fR.ret == true || fR.inWater == false)
            return;
            
        if(ready == true)
        {
            StartCoroutine(cast());
        }

        if (final == true && Input.GetMouseButtonDown(0)) 
        { 
            StartCoroutine(finalText());
        }

    }

}


