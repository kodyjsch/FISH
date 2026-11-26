using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorChanger : MonoBehaviour
{
    private FishList fL;
    [SerializeField] private Animator arms;

    void Start()
    {
        fL = GameObject.FindWithTag("list").GetComponent<FishList>();

        if(fL.rod2 == true)
        {
            arms.runtimeAnimatorController = fL.V2;

        } else if (fL.rod1 == true)
        {
            arms.runtimeAnimatorController = fL.V1;
        }
    }

}
