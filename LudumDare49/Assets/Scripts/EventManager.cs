using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    public event Action onEngineMalfunction;
    private float randomTime;
    private float engineTime;

    private void Awake()
    {
        current = this;
    }

    public void engineMalfunctionEvent()
    {
        if (onEngineMalfunction != null)
        {
            onEngineMalfunction();
        }
    }

}
