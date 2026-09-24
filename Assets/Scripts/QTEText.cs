using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEText : MonoBehaviour
{
    [Header("Alphabet Keys")]
    public List<string> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public List<KeyCode> keys = new List<KeyCode>() { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };

    private int target;
    private TMP_Text TMP;
    public int turnOrder;

    private QTESys qS;

    public float duration = 5.0f;

    private IEnumerator timer;

    public Color start;
    public Color mid;
    public Color end;

    public Color win;
    public Color lose;

    private void Start()
    {
        target = Random.Range(0, letters.Count);

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


        timer = TransitionColorRoutine();
        StartCoroutine(timer);

    }

    private void Update()
    {

        if (turnOrder == qS.QTETurn)
        {
            if (Input.GetKeyDown(keys[target]))
            {
                StopCoroutine(timer);
                TMP.color = win;
                qS.correct++;
                StartCoroutine(updateOrder());
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(keys[target]))
            {
                StopCoroutine(timer);
                TMP.color = lose;
                qS.fail = true;

            }

        }

    }

    IEnumerator updateOrder()
    {
        yield return null;
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
        qS.fail = true;

    }
}



