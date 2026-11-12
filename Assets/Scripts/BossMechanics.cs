using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class BossMechanics : MonoBehaviour
{
    [SerializeField] private float timeLeft = 91f;
    [SerializeField] private TextMeshProUGUI UItimer;
    [SerializeField] private TextMeshProUGUI fishCount;
    public GameObject[] fullHearts;
    public GameObject[] brokenHearts;
    private int lifeLeft = 0;
    private bool won;

    private FishList fL;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    private void Update()
    {
        if (won == true)
            return;

        fishCount.text = (fL.fishCaught + "/5");

        if (fL.fishCaught == 5)
        {
            StartCoroutine(WinGame());
            won = true;
            return;
        }

        if (timeLeft > 1)
        {
            timeLeft -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeLeft / 60);
            float seconds = Mathf.FloorToInt(timeLeft % 60);

            UItimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
        SceneManager.LoadScene("Game Over");
    }

    IEnumerator WinGame()
    {
        GameObject caster = GameObject.FindWithTag("caster");
        caster.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        Debug.Log("WIN TRANSITION!!");
    }



}
