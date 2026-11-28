using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay : MonoBehaviour
{
    private static GameObject gameObj;

    void Start()
    {
        if(gameObj == null)
        {
            gameObj = this.gameObject;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObj);
        }
        
    }

}
