using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishList : MonoBehaviour
{

    [Header("Rigidbodies")]
    public Rigidbody rb;

    public Rigidbody puffer;
    public Rigidbody disco;

    [Header("Lists")]
    public List<GameObject> fishPrefabs;
    public List<bool> firstCatch;

    private static GameObject list;

    [Header("Fishing Variables")]
    public float maxWait;
    public float qteLength;
    public int fishNumber;

    public bool day2 = false;
    public int fishCaught = 0;

    [Header("Dialogue Variables")]
    public GameObject dialogueSprite;
    public GameObject dialogueSplash;

    public GameObject manmer;
    public GameObject merman;

    public GameObject manmerSplash;
    public GameObject mermanSplash;

    [Header("Boss Variables")]
    public bool trigger = false;
    public bool bossDialogue;

    private GameObject bossTrigger;
    private GameObject bossMechanics;

    private MechFinder mF;

    [Header("Shop Variables")]

    [SerializeField] private GameObject trig;
    public bool shopTrigActive = false;
    public int selectedButton;

    public bool hat1;
    public bool hat2;
    public bool rod1;
    public bool rod2;

    [Header("Animator Variables")]
    public int AnimationSpeed;

    public Animator armsAnim;
    public AnimatorOverrideController V1;
    public AnimatorOverrideController V2;

    private int setNum = 0;

    private void Start()
    {
        if(list != null)
        {
            Destroy(gameObject);
        } else
        {
            list = gameObject;
        }

        DontDestroyOnLoad(gameObject);

        dialogueSprite = manmer;
        dialogueSplash = manmerSplash;

        bossDialogue = true;

        maxWait = 16;
        qteLength = 2f;
        fishNumber = 14;

        AnimationSpeed = 3;

        ShopTrig(false);
    }

    private void Update()
    {

        if(armsAnim == null)
        {
            armsAnim = GameObject.Find("Arms").GetComponent<Animator>();

            if(setNum == 1)
            {
                armsAnim.runtimeAnimatorController = V1;

            } else if (setNum == 2)
            {
                armsAnim.runtimeAnimatorController = V2;
            }
        }

        if(trigger == true)
        {
            if (day2 == true)
            {
                bossDialogue = false;
            }

            trigger = false;
        }

        if(bossDialogue == false)
        {
            SetObjects();
        }

    }

    private void SetObjects()
    {
        if (bossTrigger == null)
        {
            bossTrigger = GameObject.FindWithTag("boss");
            mF = GameObject.Find("BossManager").GetComponent<MechFinder>();
            bossMechanics = mF.BossMech;

            bossTrigger.SetActive(false);
            bossMechanics.SetActive(true);
        }
    }

    public void AnimatorOverride(AnimatorOverrideController vers, int num)
    {
        if(armsAnim == null)
        {
            armsAnim = GameObject.Find("Arms").GetComponent<Animator>();
        }

        armsAnim.runtimeAnimatorController = vers;
        setNum = num;
    }

    public void ShopTrig(bool state)
    {
        shopTrigActive = state;
        trig.SetActive(shopTrigActive);
    }

}
