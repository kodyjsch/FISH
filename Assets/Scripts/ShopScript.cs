using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Button[] butts;
    [SerializeField] private GameObject[] exes;
    private PauseMenu pM;
    private FishList fL;

    [SerializeField] private TextMeshProUGUI currency;

    private bool butt0 = false;
    private bool butt2 = false;
    private bool butt4 = false;

    private void Start()
    {

        pM = GameObject.FindWithTag("list").GetComponent<PauseMenu>();
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    private void OnEnable()
    {
        StartCoroutine(SetSelection());
    }

    private void Update()
    {
        currency.text = ("Current Fish: " + fL.fishCaught);


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            pM.Resume();
            pM.dialogue = false;
            gameObject.SetActive(false);
        }

        if(fL.day2 == true)
        {
            if(butt0 == true)
            {
                buttons[1].SetActive(true);
            }

            if (butt2 == true)
            {
                buttons[3].SetActive(true);
            }

            if (butt4 == true)
            {
                buttons[5].SetActive(true);
            }

        }

    }

    private IEnumerator SetSelection()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }

   

    public void ButtonEffect(int butt)
    {
        if(butt == 0)
        {
            exes[butt].SetActive(true);
            butt0 = true;
            fL.maxWait = 12;
        }

        if(butt == 1)
        {
            exes[butt].SetActive(true);
            fL.maxWait = 8;
        }

        if (butt == 2)
        {
            exes[butt].SetActive(true);
            butt2 = true;
            fL.qteLength = 1.5f;
        }

        if (butt == 3)
        {
            exes[butt].SetActive(true);
            fL.qteLength = 2f;            
        }

        if (butt == 4)
        {
            fL.fishNumber = fL.fishNumber + 12;
            butt4 = true;
            exes[butt].SetActive(true);
        }

        if (butt == 5)
        {
            fL.fishNumber = fL.fishPrefabs.Count;
            exes[butt].SetActive(true);            
        }
    }
}
