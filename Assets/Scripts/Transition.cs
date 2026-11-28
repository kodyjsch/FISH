using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private FishList fL;

    void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();

        if(fL.day2 == false)
        {
            fL.day2 = true;
            StartCoroutine(transIsland());
        } else if (fL.day2 == true)
        {
            StartCoroutine(transBoss());
        }        
    }

    private IEnumerator transIsland()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Island");
    }

    private IEnumerator transBoss()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("BOSS");
    }
   
}
