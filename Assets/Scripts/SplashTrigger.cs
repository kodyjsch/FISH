using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SplashTrigger : MonoBehaviour
{
    private FishReturn fRet;
    private FishList fList;

    public Image SplashSprite;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Zinger;

    public GameObject screen;

    private void Start()
    {
        fList = GameObject.Find("FISH LIST (FLIST)").GetComponent<FishList>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bobber"))
        {
            fRet = other.GetComponent<FishReturn>();

            if (fList.firstCatch[fRet.chosenFish] == false)
            {
                fList.firstCatch[fRet.chosenFish] = true;
                SplashSprite.sprite = fList.splashSprites[fRet.chosenFish];
                Name.text = fList.Names[fRet.chosenFish];
                Zinger.text = fList.OneLiners[fRet.chosenFish];
                screen.SetActive(true);
            }            
        }
    }
}
