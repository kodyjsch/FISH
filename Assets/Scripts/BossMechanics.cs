using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

public class BossMechanics : MonoBehaviour
{
    [SerializeField] private float timeLeft = 60f;
    [SerializeField] private TextMeshProUGUI UItimer;
    public GameObject[] fullHearts;
    public GameObject[] brokenHearts;
    private int lifeLeft = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UItimer.text = Mathf.Floor(timeLeft).ToString();
        } else
        {
            StartCoroutine(LoseGame());
        }

        if(lifeLeft == 4)
        {
            StartCoroutine(LoseGame());
        }
    }

    public void LoseALife()
    {
        fullHearts[lifeLeft].SetActive(false);
        brokenHearts[lifeLeft].SetActive(true);
        lifeLeft++;
    }

    IEnumerator LoseGame()
    {
        GameObject caster = GameObject.FindWithTag("caster");
        caster.SetActive(false);
        yield return new WaitForSeconds(3.0f);        
        Debug.Log("END SCREEN TRANSITION!!");
    }

}
