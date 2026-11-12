using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject textCanvas;
    [SerializeField] private TextMeshProUGUI fishText;
    private FishList fL;
    private GameObject shop;

    private bool inside = false;
    private bool enough = false;

    void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
        shop = GameObject.FindWithTag("cube");
    }

    // Update is called once per frame
    void Update()
    {
        if(fL.fishCaught >= 5)
        {
            enough = true;
            fishText.text = (fL.fishCaught + "/5 Fish needed.\nPress ENTER to end the day.");
        } else
        {
            enough = false;
            fishText.text = (fL.fishCaught + "/5 Fish needed.");
        }

        if(Input.GetKeyDown(KeyCode.Return) && inside == true && enough == true)
        {
            if(fL.day2 == false)
            {
                fL.day2 = true;
                fL.fishCaught = fL.fishCaught - 5;
                SceneManager.LoadScene("Transition");
            } else
            {
                Destroy(shop);
                fL.dialogueSprite = fL.merman;
                fL.dialogueSplash = fL.mermanSplash;
                fL.fishCaught = 0;
                Debug.Log("Transition to Boss Fight");
            }            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanvas.SetActive(true);
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textCanvas.SetActive(false);
            inside = false;
        }
    }
}
