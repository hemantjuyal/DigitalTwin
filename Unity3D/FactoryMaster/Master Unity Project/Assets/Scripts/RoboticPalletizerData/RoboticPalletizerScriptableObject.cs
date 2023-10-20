// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using Microsoft.Geospatial;
using UnityEngine;

/// <summary>
/// Scriptable Object for Robotic Palletizer data received from ADT
/// </summary>
/// 
[CreateAssetMenu(fileName = "RoboticPalletizerData", menuName = "Scriptable Objects/Robotic Palletizer Data/Robotic Palletizer Data")]
public class RoboticPalletizerScriptableObject : ScriptableObject
{
    
    public Action onDataUpdated;


    public RoboticPalletizerData roboticPalletizerData;


    public RoboticPalletizerMetaData roboticPalletizerMetaData;

    /// <summary>
    /// Update scriptable object data and invoke defined action.
    /// </summary>
    /// <param name="newRoboticPalletizerData"></param>
    public void UpdateData(RoboticPalletizerData newRoboticPalletizerData)
    {
        roboticPalletizerData = newRoboticPalletizerData;
        onDataUpdated?.Invoke();
    }

    /// <summary>
    /// Stores the Robotic Palletizer user placed location in the scene
    /// </summary>
    public LatLon CurrentLocation { get; set; }
}