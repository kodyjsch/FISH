using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(trans());
    }

    private IEnumerator trans()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Island");
    }
   
}
