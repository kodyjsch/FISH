using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{
    [SerializeField] private TextAsset dia;
    private GameObject tutorial;
    private DialogueManager dM;

    private void Start()
    {
        tutorial = GameObject.FindWithTag("tutorial");
        Destroy(tutorial);

        dM = GameObject.FindWithTag("list").GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            dM.EnterDialogue(dia);
            Destroy(gameObject);
        }
    }
}
