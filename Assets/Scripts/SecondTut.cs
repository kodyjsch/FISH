using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondTut : MonoBehaviour
{
    public List<string> secondLines;
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private GameObject txtObj;
    private bool started = false;
    private FishList fL;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && started == false)
        {
            started = true;
            StartCoroutine(secondTut());
        }
    }

    private IEnumerator secondTut()
    {
        for (int i = 0; i < (secondLines.Count); i++)
        {
            txt.text = secondLines[i];
            txtObj.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            txtObj.SetActive(false);
            yield return new WaitForSeconds(3.0f);
        }

        Destroy(gameObject);
    }
}
