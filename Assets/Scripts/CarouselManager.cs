using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class CarouselMenuInfo
{
    public string FishName;
    public string FishZinger;
    public string credit;

    public Sprite fishL;
    public Sprite fishR;
    public Sprite fishC;
}

public class CarouselManager : MonoBehaviour
{
    [SerializeField] private GameObject scroll;
    [SerializeField] private GameObject carousel;

    [SerializeField] private TextMeshProUGUI fishName;
    [SerializeField] private TextMeshProUGUI fishZinger;
    [SerializeField] private TextMeshProUGUI fishCredit;

    [SerializeField] private Image LeftImage;
    [SerializeField] private Image RightImage;
    [SerializeField] private Image CenterImage;

    private FishList fL;

    public List<CarouselMenuInfo> FishMenu = new List<CarouselMenuInfo>();

    private void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();
    }

    private void Update()
    {
        LeftImage.sprite = FishMenu[fL.selectedButton].fishL;
        RightImage.sprite = FishMenu[fL.selectedButton].fishR;
        CenterImage.sprite = FishMenu[fL.selectedButton].fishC;

        if (fL.firstCatch[fL.selectedButton] == true)
        {
            fishName.text = FishMenu[fL.selectedButton].FishName;
            fishZinger.text = FishMenu[fL.selectedButton].FishZinger;
            fishCredit.text = FishMenu[fL.selectedButton].credit;

            LeftImage.color = Color.white;
            RightImage.color = Color.white;
            CenterImage.color = Color.white;

        } else
        {
            fishName.text = "???";
            fishZinger.text = "???";
            fishCredit.text = "???";

            LeftImage.color = Color.black;
            RightImage.color = Color.black;
            CenterImage.color = Color.black;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (fL.selectedButton == 0)
            {
                fL.selectedButton = fL.fishNumber;
            }
            else
            {
                fL.selectedButton = fL.selectedButton - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (fL.selectedButton == fL.fishNumber)
            {
                fL.selectedButton = 0;
            }
            else
            {
                fL.selectedButton = fL.selectedButton + 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            scroll.SetActive(true);
            carousel.SetActive(false);
        }

    }
}


