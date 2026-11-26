using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public int buttonIndex;
    public Image FishIcon;
    private FishList fL;

    private bool found = false;

    [SerializeField] private GameObject scroll;
    [SerializeField] private GameObject carousel;

    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject star;

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    private void Update()
    {
        if (fL.firstCatch[buttonIndex] == true && found == false)
        {
            FishIcon.color = Color.white;
            star.SetActive(true);
            found = true;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        fL.selectedButton = buttonIndex;
        arrow.SetActive(true);
        if (star.activeInHierarchy)
        {
            star.SetActive(false);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        arrow.SetActive(false);
    }

    public void OpenCarousel()
    {
        arrow.SetActive(false);
        carousel.SetActive(true);
        scroll.SetActive(false);
    }
}
