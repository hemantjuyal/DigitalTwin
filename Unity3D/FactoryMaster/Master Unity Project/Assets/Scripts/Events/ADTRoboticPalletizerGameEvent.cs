// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ADTRoboticPalletizerEvent", menuName = "Scriptable Objects/Events/ADT Robotic Palletizer Event")]
public class ADTRoboticPalletizerGameEvent : ScriptableObject
{
    private List<ADTRoboticPalletizerEventListener> listeners =
    new List<ADTRoboticPalletizerEventListener>();

    public void Raise(ADTRoboticPalletizerEventData eventData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(eventData);
        }
    }

    public void RegisterListener(ADTRoboticPalletizerEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(ADTRoboticPalletizerEventListener listener)
    {
        listeners.Remove(listener);
    }
}

/// <summary>
/// Wrapper for data sent through Robotic Palletizer Events
/// </summary>
[Serializable]
public class ADTRoboticPalletizerEventData
{
    public ADTRoboticPalletizerEventData(RoboticPalletizerData roboticPalletizerData)
    {
        this.roboticPalletizerData = roboticPalletizerData;
    }

    public RoboticPalletizerData roboticPalletizerData;
}

/// <summary>
/// A UnityEvent which passes RoboticPalletizerEventData and can be setup in the Inspector
/// </summary>
[Serializable]
public class ADTRoboticPalletizerUnityEvent : UnityEvent<ADTRoboticPalletizerEventData> { }