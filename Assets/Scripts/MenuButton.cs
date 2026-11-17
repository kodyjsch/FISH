using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, ISelectHandler
{
    public int buttonIndex;
    public Image FishIcon;
    private FishList fL;

    private bool found = false;

    [SerializeField] private GameObject scroll;
    [SerializeField] private GameObject carousel;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    private void Update()
    {
        if (fL.firstCatch[buttonIndex] == true && found == false)
        {
            FishIcon.color = Color.white;
            found = true;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        fL.selectedButton = buttonIndex;
    }

    public void OpenCarousel()
    {
        carousel.SetActive(true);
        scroll.SetActive(false);
    }
}
