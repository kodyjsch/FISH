using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject caster;


    public bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        caster.SetActive(true);
        Time.timeScale = 1f;          
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        caster.SetActive(false);
        Time.timeScale = 0f;          
        isPaused = true;
    }
}
