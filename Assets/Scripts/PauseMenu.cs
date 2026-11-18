using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gridMenu;
    [SerializeField] private GameObject carouselView;
    private GameObject shop;

    private GameObject caster;
    private FishList fL;

    public bool isPaused = false;
    public bool dialogue = false;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    void Update()
    {
        if(caster == null)
        {
            caster = GameObject.FindWithTag("caster");
        }

        if(shop == null)
        {
            shop = GameObject.FindWithTag("ShopTrigger");
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
        shop.SetActive(true);
        caster.SetActive(true);
        fL.selectedButton = 0;
        Time.timeScale = 1f;          
        isPaused = false;
    }

    public void Pause(bool menu)
    {

        if(menu == true)
        {
            pauseMenuUI.SetActive(true);
            gridMenu.SetActive(true);
            carouselView.SetActive(false);
        }
        shop.SetActive(false);
        caster.SetActive(false);
        Time.timeScale = 0f;          
        isPaused = true;
    }
}
