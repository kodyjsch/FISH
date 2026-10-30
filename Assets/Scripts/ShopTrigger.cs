using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private bool inRange;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject floatingText;
    private PauseMenu pM;

    private void Start()
    {
        inRange = false;
        shopUI.SetActive(false);
        pM = GameObject.FindWithTag("list").GetComponent<PauseMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // player entered! Indicator will be set active!
            Debug.Log("Entered!");
            floatingText.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited!");
            floatingText.SetActive(false);
            inRange = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"STAY: {other.name}", this);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && inRange == true)
        {
            shopUI.SetActive(true);
            pM.Pause(false);
            pM.dialogue = true;
        }
    }
}
