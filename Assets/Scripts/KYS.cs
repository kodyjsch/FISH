using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{
    [SerializeField] private TextAsset dia;
    private GameObject tutorial;

    private void Start()
    {
        tutorial = GameObject.FindWithTag("tutorial");
        Destroy(tutorial);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
            DialogueManager.GetInstance().EnterDialogue(dia);
        }
    }
}
