using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class spawnFish : MonoBehaviour
{
    private FishList list;
    private RectTransform rT;
    private float randomX;
    private float randomY;
    float canvasWidth;
    float canvasHeight;

    private void Start()
    {
        list = GameObject.FindWithTag("list").GetComponent<FishList>();
        rT = GetComponent<RectTransform>();

        canvasWidth = rT.rect.width;
        canvasHeight = rT.rect.height;

    }

    public void spawn(int counter)
    {
        randomX = Random.Range(-canvasWidth / 2f, canvasWidth / 2f);
        randomY = Random.Range(-canvasHeight / 2f, canvasHeight / 2f);

        GameObject newImage = Instantiate(list.counterSprites[counter], rT);

        RectTransform imgRect = newImage.GetComponent<RectTransform>();

        imgRect.anchoredPosition = new Vector2(randomX, randomY);
    }
}
