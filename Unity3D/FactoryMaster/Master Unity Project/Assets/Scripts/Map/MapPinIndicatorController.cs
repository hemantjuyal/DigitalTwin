// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;
using Microsoft.Maps.Unity;
using UnityEngine;

/// <summary>
/// Adds position indicators to the edge of the MapRenderer. 
/// </summary>
public class MapPinIndicatorController : MonoBehaviour
{
    public RoboticPalletizerSiteData siteData;
    public MapPinIndicator indicatorPrefab;
    
    public float indicatorRadius = 1f;
    public float indicatorHeight = 0.2f;

    private Dictionary<MapPin, MapPinIndicator> indicators = new Dictionary<MapPin, MapPinIndicator>();

    /// <summary>
    /// Creates a map indicator when a wind turbine is instantiated in the scene.
    /// </summary>
    public void OnRoboticPalletizerDataUpdatedAdded(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        if (siteData.TryGetRoboticPalletizerGameObject(roboticPalletizerData, out var roboticPalletizer))
        {
            MapPin mapPin = roboticPalletizer.GetComponent<MapPin>();
            var indicator = Instantiate(indicatorPrefab, transform);
            indicator.Setup(roboticPalletizerData);
            indicators.Add(mapPin, indicator);
            Debug.Log("UI Related in MapPinIndicatorController");
        }
    }

}