using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private FishList fL;
    private GameObject FList;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }
    public void TryAgain()
    {
        fL.fishCaught = 0;
        SceneManager.LoadScene("Boss");
    }

    public void Quit()
    {
        FList = GameObject.FindWithTag("list");
        Destroy(FList);
        SceneManager.LoadScene("MainMenu");
    }
}
