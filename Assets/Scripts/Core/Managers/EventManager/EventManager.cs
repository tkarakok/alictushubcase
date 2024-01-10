using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventController))]
public class EventManager : Singleton<EventManager>
{
    public EventController EventController;

    private void Awake()
    {
        // EventController = GetComponent<EventController>();
    }
}
