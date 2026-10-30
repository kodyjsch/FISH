using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDetails : MonoBehaviour
{
    public Sprite splash;
    public GameObject counter;
    public string fishName;
    [TextArea(3, 10)]
    public string zinger;

    public int minQTE;
    public int maxQTE;
}
