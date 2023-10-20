// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A Scriptable Object used to pass Robotic Palletizer events between the scene and UI
/// </summary>
[CreateAssetMenu(fileName = "RoboticPalletizerGameEvent", menuName = "Scriptable Objects/Events/Robotic Palletizer Game Event")]
public class RoboticPalletizerGameEvent : ScriptableObject
{
    private List<RoboticPalletizerEventListener> listeners =
        new List<RoboticPalletizerEventListener>();

    public void Raise(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            if (listeners[i] != null)
            {
                listeners[i].OnEventRaised(roboticPalletizerData);
            }
        }
    }

    public void AddListener(RoboticPalletizerEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(RoboticPalletizerEventListener listener)
    {
        listeners.Remove(listener);
    }
}

/// <summary>
/// A UnityEvent which passes RoboticPalletizerEventData and can be setup in the Inspector
/// </summary>
[Serializable]
public class RoboticPalletizerUnityEvent : UnityEvent<RoboticPalletizerScriptableObject> { }