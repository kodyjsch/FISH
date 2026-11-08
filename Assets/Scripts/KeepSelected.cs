using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeepSelected : MonoBehaviour
{
    private GameObject _lastSelected;

    void Start()
    {
        // Cache whatever element is selected when the scene starts
        _lastSelected = EventSystem.current.firstSelectedGameObject;
    }

    void Update()
    {
        // If the active selection drops to null, force it back to the last valid selection
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(_lastSelected);
        }
        else
        {
            // Otherwise, keep track of the new valid item the user selected
            _lastSelected = EventSystem.current.currentSelectedGameObject;
        }
    }
}
