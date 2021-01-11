using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedEvent : MonoBehaviour
{
    [SerializeField]private GameObject canvas;
    [SerializeField] private GameObject planeFinder;
    public void placedEvent()
    {
        Instantiate(canvas);
        planeFinder.SetActive(false);
    }
}
