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
            yield return new WaitForSeconds(3.0f);
            txt.SetActive(false);
            yield return new WaitForSeconds(3.0f);
        }

    }

    IEnumerator cast()
    {
        tutText.text = TutorialLines[3];
        txt.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        txt.SetActive(false);
        Destroy(gameObject);
    }

    private void Update()
    {

        if (GameObject.FindWithTag("bobber") == null)
            return;


        fR = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();    

        if(fR.fish == true && final == false)
        {
            final = true;
            StopCoroutine(started());
            StartCoroutine(cast());
        }

    }

}


