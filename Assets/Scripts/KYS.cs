using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{
    [SerializeField] private TextAsset Manmer;
    [SerializeField] private GameObject tutorial;


    private void OnAwake()
    {
        tutorial.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
            DialogueManager.GetInstance().EnterDialogue(Manmer);
        }
    }
}
