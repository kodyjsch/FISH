using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEText : MonoBehaviour
{
    [Header("Alphabet Keys")]
    public List<string> letters = new List<string>() { "B", "C", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "T", "U", "V", "X", "Y", "Z" };
    public List<KeyCode> keys = new List<KeyCode>() { KeyCode.B, KeyCode.C, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.X, KeyCode.Y, KeyCode.Z };

    private int target;
    private TMP_Text TMP;
    public int turnOrder;

    private QTESys qS;
    private FishList fL;
    private FishReturn fR;

    public float duration;

    private Coroutine timer = null;

    public Color start;
    public Color mid;
    public Color end;

    public Color win;
    public Color lose;

    private bool tried = false;

    public AudioSource good;
    public AudioSource bad;

    private void Start()
    {
        target = Random.Range(0, letters.Count);

        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
        fR = GameObject.FindWithTag("bobber").GetComponent<FishReturn>();
        TMP = GetComponent<TMP_Text>();
        TMP.SetText(letters[target]);
        TMP.color = start;

        qS = GameObject.FindWithTag("QTE").GetComponent<QTESys>();

        if (gameObject.CompareTag("one"))
        {
            turnOrder = 0;
        }
        else if (gameObject.CompareTag("two"))
        {
            turnOrder = 1;
        } 
        else if (gameObject.CompareTag("three"))
        {
            turnOrder = 2;
        }
        else if (gameObject.CompareTag("four"))
        {
            turnOrder = 3;
        }
        else if (gameObject.CompareTag("five"))
        {
            turnOrder = 4;
        }
        else if (gameObject.CompareTag("six"))
        {
            turnOrder = 5;
        }
        else if (gameObject.CompareTag("seven"))
        {
            turnOrder = 6;
        }
        else if (gameObject.CompareTag("eight"))
        {
            turnOrder = 7;
        }
        else if (gameObject.CompareTag("nine"))
        {
            turnOrder = 8;
        }
        else if (gameObject.CompareTag("ten"))
        {
            turnOrder = 9;
        }


        timer = StartCoroutine(TransitionColorRoutine());

    }

    private void Update()
    {

        duration = fL.qteLength;

        if (turnOrder == qS.QTETurn && tried == false && qS.fail == false)
        {
            if (Input.GetKeyDown(keys[target]))
            {
                tried = true;
                good.Play();
                StopCoroutine(timer);
                TMP.color = win;
                qS.correct++;
                StartCoroutine(updateOrder());
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(keys[target]) && !Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
            {
                bad.Play();
                tried = true;
                StopCoroutine(timer);
                TMP.color = lose;
                qS.fail = true;

            }

        }

    }

    IEnumerator updateOrder()
    {
        yield return new WaitForEndOfFrame();
        qS.QTETurn++;
    }

    private IEnumerator TransitionColorRoutine()
    {

        yield return new WaitForSeconds(duration / 3);
        TMP.color = mid;
        yield return new WaitForSeconds(duration / 3);
        TMP.color = end;
        yield return new WaitForSeconds(duration / 3);
        TMP.color = lose;
        fR.KillBubbles();
        qS.oOT.Play();
        qS.TimeOut = true;
        qS.fail = true;

    }
}



