// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using UnityEngine;


[CreateAssetMenu(fileName = "RoboticPalletizerSiteData", menuName = "Scriptable Objects/Robotic Palletizer Data/Robotic Palletizer Site Data", order = 1)]
public class RoboticPalletizerSiteData : ScriptableObject
{
    [Header("Site Info")]
    public string facilityName;

    [SerializeField]
    private LatLonWrapper siteLatLon;


    public LatLon SiteLocation => siteLatLon.ToLatLon();

    public RoboticPalletizerScriptableObject[] roboticPalletizerData;

    public Dictionary<RoboticPalletizerScriptableObject, GameObject> roboticPalletizers =
        new Dictionary<RoboticPalletizerScriptableObject, GameObject>();

    public void AddRoboticPalletizer(RoboticPalletizerScriptableObject data, GameObject gameObject)
    {
        Debug.Log("Palletizer Added to Dictionary with ID "+data.roboticPalletizerData.RoboticPalletizerID);
        roboticPalletizers.Add(data, gameObject);
    }

    /// <summary>
    /// Find the Robotic Palletizer GameObject related to a Robotic Palletizer data.
    /// </summary>
    public bool TryGetRoboticPalletizerGameObject(RoboticPalletizerScriptableObject data, out GameObject roboticPalletizerObject)
    {
        return roboticPalletizers.TryGetValue(data, out roboticPalletizerObject);
    }
}