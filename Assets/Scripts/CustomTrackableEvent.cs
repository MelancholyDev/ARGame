using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrackableEvent : DefaultTrackableEventHandler
{
    [SerializeField]private GameObject canvas;
    [SerializeField] private GameObject planeFinder;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Instantiate(canvas);
        planeFinder.SetActive(false);
    }
}
