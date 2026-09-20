using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTEText : MonoBehaviour
{
    public List<string> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public List<KeyCode> keys = new List<KeyCode>() { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };

    private int target;
    private TMP_Text TMP;
    public int turnOrder;

    private QTESys qS;

    public float duration = 5.0f;
    public Color targetColor = Color.red;

    private IEnumerator timer;

    private void Start()
    {
        target = Random.Range(0, letters.Count);

        TMP = GetComponent<TMP_Text>();
        TMP.SetText(letters[target]);

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
                TMP.color = Color.green;
                qS.correct++;
                StartCoroutine(updateOrder());
            }
            else if (Input.anyKeyDown && !Input.GetKeyDown(keys[target]))
            {
                StopCoroutine(timer);
                TMP.color = Color.red;
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
        Color startColor = TMP.color;
        float elapsedTime = 0f;


        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate normalized time (0.0 to 1.0)
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Linearly interpolate between the start and target color
            TMP.color = Color.Lerp(startColor, targetColor, t);

            yield return null; // Wait for the next frame
        }

        // Ensure the exact target color is set at the end
        TMP.color = targetColor;
        qS.fail = true;
    }
}



