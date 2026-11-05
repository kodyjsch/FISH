using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private GameObject caster;

    public bool isPaused = false;
    public bool dialogue = false;

    void Update()
    {
        if(caster == null)
        {
            caster = GameObject.FindWithTag("caster");
        }


        if(dialogue == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause(true);
            }
        }
    }

    public void Resume()
    {
        if(pauseMenuUI.activeInHierarchy)
        {
            pauseMenuUI.SetActive(false);
        }
        caster.SetActive(true);
        Time.timeScale = 1f;          
        isPaused = false;
    }

    public void Pause(bool menu)
    {

        if(menu == true)
        {
            pauseMenuUI.SetActive(true);
        }
        caster.SetActive(false);
        Time.timeScale = 0f;          
        isPaused = true;
    }
}
