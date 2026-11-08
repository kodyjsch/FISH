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
    private FishDetails fD;

    public Image SplashSprite;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Zinger;

    public GameObject screen;
    private bool destroy = false;

    public Canvas counter;
    public spawnFish sF;

    public AudioSource aS;

    public Animator arms;

    private GameObject bob;
    private FishReturn fR;

    private bool mA = false;

    private void Start()
    {
        fList = GameObject.Find("FISH LIST (FLIST)").GetComponent<FishList>();
        plFish = GameObject.Find("Caster").GetComponent<PlayerFishing>();
        sF = counter.GetComponent<spawnFish>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (screen.activeInHierarchy)
            {
                StopCoroutine(killFish());
                arms.ResetTrigger("Reel");
                arms.SetTrigger("Idle");
                screen.SetActive(false);
                destroy = false;
                StartCoroutine(Cast());
            }

            if(mA == true)
            {
                arms.ResetTrigger("Reel");
                arms.SetTrigger("Idle");
                mA = false;
                StartCoroutine(Cast());
            }            
        }

        bob = GameObject.FindWithTag("bobber");

        if(bob != null)
        {
            fR = bob.GetComponent<FishReturn>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (plFish.reel.isPlaying)
        {
            plFish.reel.Stop();
        }

        if (other.CompareTag("Manmer"))
        {
            Instantiate(fList.dialogueSplash);
            mA = true;
            Destroy(bob);
        }
        else if (other.CompareTag("fish") && destroy == false)
        {
            fList.fishCaught = fList.fishCaught + 1;
            fD = other.GetComponent<FishDetails>();
            destroy = true;
            fRet = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();
            sF.spawn(fD.counter);

            if (fList.firstCatch[fRet.chosenFish] == false)
            {
                aS.Play();
                fList.firstCatch[fRet.chosenFish] = true;
                SplashSprite.sprite = fD.splash;
                Name.text = fD.fishName;
                Zinger.text = fD.zinger;
                screen.SetActive(true);
                Destroy(bob);

            } else
            {
                StartCoroutine(killFish());
            }
                        
        } else if (destroy == false && fR.sad == true && fR.ret == true)
        {
            destroy = true;
            StartCoroutine(killFish());
        }

    }

    IEnumerator killFish()
    {
        Debug.Log("KILLED!");
        yield return new WaitForSeconds(2.5f);
        Destroy(bob);
        if (plFish.reel.isPlaying)
        {
            plFish.reel.Stop();
        }
        arms.ResetTrigger("Reel");
        arms.SetTrigger("Idle");
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
