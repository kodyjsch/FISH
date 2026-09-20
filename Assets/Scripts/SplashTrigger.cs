using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SplashTrigger : MonoBehaviour
{
    private FishReturn fRet;
    private FishList fList;
    private PlayerFishing plFish;

    public Image SplashSprite;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Zinger;

    public GameObject screen;
    private bool destroy = false;

    private void Start()
    {
        fList = GameObject.Find("FISH LIST (FLIST)").GetComponent<FishList>();
        plFish = GameObject.Find("Caster").GetComponent<PlayerFishing>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && screen.activeInHierarchy)
        {
            screen.SetActive(false);
            destroy = false;
            StartCoroutine(Cast());

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish") && destroy == false)
        {
            destroy = true;
            fRet = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();

            if (fList.firstCatch[fRet.chosenFish] == false)
            {
                fList.firstCatch[fRet.chosenFish] = true;
                SplashSprite.sprite = fList.splashSprites[fRet.chosenFish];
                Name.text = fList.Names[fRet.chosenFish];
                Zinger.text = fList.OneLiners[fRet.chosenFish];
                screen.SetActive(true);
                GameObject bob = GameObject.FindWithTag("bobber");
                Destroy(bob);

            } else if (fList.firstCatch[fRet.chosenFish] == true)
            {
                StartCoroutine(killFish());
            }           
        }
    }

    IEnumerator killFish()
    {
        yield return new WaitForSeconds(2.5f);
        GameObject bob = GameObject.FindWithTag("bobber");
        Destroy(bob);
        plFish.casted = false;
        plFish.QTE = false;
        destroy = false;
    }

    IEnumerator Cast()
    {
        yield return null;
        plFish.casted = false;
        plFish.QTE = false;
    }
}
