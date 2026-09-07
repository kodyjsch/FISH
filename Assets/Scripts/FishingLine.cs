using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class FishingLine : MonoBehaviour
{
    public GameObject bobber;
    public GameObject pole;
    private LineRenderer lineRenderer;

    void Start()
    {
        bobber = GameObject.FindWithTag("bobber");
        pole = GameObject.FindWithTag("pole");

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Set the line to have two points

        lineRenderer.startWidth = 0.0075f;
        lineRenderer.endWidth = 0.01f;
    }

    void Update()
    {
        if (bobber != null && pole != null)
        {
            lineRenderer.SetPosition(0, pole.transform.position);
            lineRenderer.SetPosition(1, bobber.transform.position);
        } else
        {
            Destroy(lineRenderer);
        }
    }
}
