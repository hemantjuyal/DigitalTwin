// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// Spawns RoboticPalletizers as children of the MapRenderer.
/// Allows focusing the MapRenderer on a roboticPalletizer location.
/// </summary>
public class MapSceneController : MonoBehaviour
{
    public RoboticPalletizerSiteData roboticPalletizerSiteData;

    [Header("Map Settings")]
    public MapRenderer mapRenderer;

    public float mapAnimationSpeed = 25f;
    public MapSceneAnimationKind mapAnimationType = MapSceneAnimationKind.Bow;
    private float defaultZoom;

    [Header("Addressables")]
    public AssetReference roboticPalletizerAssetReference;

    [Header("Events")]
    public RoboticPalletizerGameEvent onRoboticPalletizerLoaded;

    public RoboticPalletizerGameEvent onRoboticPalletizerSelected;
    public RoboticPalletizerGameEvent onRoboticPalletizerHoverStart;
    public RoboticPalletizerGameEvent onRoboticPalletizerHoverEnd;

    private void Awake()
    {
       /* mapRenderer.Center = roboticPalletizerSiteData.SiteLocation;
        defaultZoom = mapRenderer.ZoomLevel;*/

        //Set the initial position of each robotic palletizer
        foreach (var roboticPalletizerData in roboticPalletizerSiteData.roboticPalletizerData)
        {
            roboticPalletizerData.CurrentLocation = new LatLon(
                roboticPalletizerData.roboticPalletizerMetaData.Latitude,
                roboticPalletizerData.roboticPalletizerMetaData.Longitude);
        }
    }

    public void SpawnRoboticPalletizers()
    {
        foreach (var roboticPalletizerData in roboticPalletizerSiteData.roboticPalletizerData)
        {
            InstantiateRoboticPalletizerAsync(roboticPalletizerData);
        }
    }

    private void InstantiateRoboticPalletizerAsync(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        roboticPalletizerAssetReference.InstantiateAsync(mapRenderer.transform).Completed += asyncHandle =>
        {
            GameObject loadedAsset = asyncHandle.Result;
            loadedAsset.name = $"Robotic Palletizer - {roboticPalletizerData.roboticPalletizerData.RoboticPalletizerID}";

           /* var roboticPalletizerController = loadedAsset.GetComponent<RoboticPalletizerController>();
            roboticPalletizerController.SetRoboticPalletizerData(roboticPalletizerData);
            roboticPalletizerController.onRoboticPalletizerSelected = onRoboticPalletizerSelected;
            roboticPalletizerController.onRoboticPalletizerHoverStart = onRoboticPalletizerHoverStart;
            roboticPalletizerController.onRoboticPalletizerHoverEnd = onRoboticPalletizerHoverEnd;*/

            //Set the location of the MapPin
            var mapPin = loadedAsset.GetComponent<MapPin>();
            mapPin.Location = new LatLon(
                roboticPalletizerData.roboticPalletizerMetaData.Latitude,
                roboticPalletizerData.roboticPalletizerMetaData.Longitude);

            //Set the heading of the Robotic Palletizer
         /*   var localRotation = new Vector3(0, (float)roboticPalletizerData.roboticPalletizerMetaData.Heading, 0);
            loadedAsset.transform.localEulerAngles = localRotation;*/

            roboticPalletizerSiteData.AddRoboticPalletizer(roboticPalletizerData, loadedAsset);
            onRoboticPalletizerLoaded.Raise(roboticPalletizerData);
        };
    }

    /// <summary>
    /// Animate the MapRenderer to center on the location of a Robotic Palletizer
    /// </summary>
    public void CenterMapOnRoboticPalletizer(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        StartCoroutine(SetMapLocation(roboticPalletizerData.CurrentLocation));
    }

    /// <summary>
    /// Resets the map to center on the site location
    /// </summary>
    public void RecenterMap()
    {
        StartCoroutine(SetMapLocation(roboticPalletizerSiteData.SiteLocation));
    }

    /// <summary>
    /// Called when a Robotic Palletizer is focused on in the UI
    /// </summary>
    public void OnFocusOnRoboticPalletizerRaised(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        CenterMapOnRoboticPalletizer(roboticPalletizerData);
    }

    /// <summary>
    /// Returns the map and all Robotic Palletizers to their original positon/zoom
    /// </summary>
 /*   public void ResetScene()
    {
        StartCoroutine(SetMapLocationAndZoom(roboticPalletizerSiteData.SiteLocation, defaultZoom));
        foreach (RoboticPalletizerScriptableObject roboticPalletizerData in roboticPalletizerSiteData.roboticPalletizers.Keys)
        {
            roboticPalletizerSiteData.TryGetRoboticPalletizerGameObject(roboticPalletizerData, out var roboticPalletizerGameObject);
            var draggableMapPin = roboticPalletizerGameObject.GetComponent<DraggableMapPin>();
            var latLon = new LatLon(
                roboticPalletizerData.roboticPalletizerMetaData.Latitude,
                roboticPalletizerData.roboticPalletizerMetaData.Longitude);
            draggableMapPin.SetLocation(latLon);
        }
    }*/

    private IEnumerator SetMapLocation(LatLon latLon)
    {
        var mapScene = new MapSceneOfLocationAndZoomLevel(latLon, mapRenderer.ZoomLevel);
        yield return mapRenderer.SetMapScene(mapScene, mapAnimationType, mapAnimationSpeed);
    }

    private IEnumerator SetMapLocationAndZoom(LatLon latLon, float zoomLevel)
    {
        var mapScene = new MapSceneOfLocationAndZoomLevel(latLon, zoomLevel);
        yield return mapRenderer.SetMapScene(mapScene, mapAnimationType, mapAnimationSpeed);
    }

    private void OnValidate()
    {
        if (roboticPalletizerSiteData && mapRenderer)
        {
            mapRenderer.Center = roboticPalletizerSiteData.SiteLocation;
        }
    }

#if  UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (roboticPalletizerSiteData == null || mapRenderer == null)
        {
            return;
        }

        foreach (var roboticPalletizerData in roboticPalletizerSiteData.roboticPalletizerData)
        {
            if (roboticPalletizerData == null) return;

            var latLon = new LatLonAlt(
                roboticPalletizerData.roboticPalletizerMetaData.Latitude,
                roboticPalletizerData.roboticPalletizerMetaData.Longitude, 800f);
            var worldPos = mapRenderer.TransformLatLonAltToWorldPoint(latLon);
            worldPos.y = transform.position.y + mapRenderer.MapBaseHeight + 0.1f;
            Gizmos.DrawIcon(worldPos, "windturbine.png");
        }
    }

#endif
}