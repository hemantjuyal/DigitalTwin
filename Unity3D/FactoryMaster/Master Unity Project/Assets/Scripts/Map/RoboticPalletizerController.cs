// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Linq;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

/// <summary>
/// Sends events to the UI when this Robotic Palletizer is interacted with.
/// Syncs the rotor speed of the Robotic Palletizer with the ADT data.
/// </summary>
public class RoboticPalletizerController : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityFocusHandler
{
    private static readonly int ColorShaderID = Shader.PropertyToID("_Color");

    [SerializeField]
    private RoboticPalletizerScriptableObject roboticPalletizerData;

    [Header("Alert Status")]
    [SerializeField]
    private GameObject alertIndicator;

    [SerializeField]
    private Material roboticPalletizerMaterial;

    [SerializeField]
    private Color alertOverrideColor;

    private MaterialPropertyBlock colorOverride;
    private MeshRenderer[] roboticPalletizerMeshes = new MeshRenderer[0];

    private RotateRPM rotateRpm;
    private MapRenderer mapRenderer;

    [Header("Events")]
    public RoboticPalletizerGameEvent onRoboticPalletizerSelectedEvent;

    public RoboticPalletizerGameEvent onRoboticPalletizerHoverStartEvent;
    public RoboticPalletizerGameEvent onRoboticPalletizerHoverEndEvent;

    private void Awake()
    {
        rotateRpm = GetComponentInChildren<RotateRPM>();
        mapRenderer = GetComponentInParent<MapRenderer>();
        colorOverride = new MaterialPropertyBlock();
    }

    private void Start()
    {
        //Find all MeshRenderers using the Robotic Palletizer material.
        roboticPalletizerMeshes = GetComponentsInChildren<MeshRenderer>()
            .Where(mr => mr.sharedMaterials[0] == roboticPalletizerMaterial)
            .ToArray();

        if (roboticPalletizerData)
        {
            SetRoboticPalletizerData(roboticPalletizerData);
        }
    }

    public void SetRoboticPalletizerData(RoboticPalletizerScriptableObject data)
    {
        if (roboticPalletizerData != null)
        {
            roboticPalletizerData.onDataUpdated -= OnRoboticPalletizerDataUpdated;
        }

        roboticPalletizerData = data;
        roboticPalletizerData.onDataUpdated += OnRoboticPalletizerDataUpdated;
        roboticPalletizerData.CurrentLocation = new LatLon(
            data.roboticPalletizerMetaData.Latitude,
            data.roboticPalletizerMetaData.Longitude);
        OnRoboticPalletizerDataUpdated();
    }

    public void SetAlertStatus(bool showAlert)
    {
        alertIndicator.SetActive(showAlert);
        var color = showAlert ? alertOverrideColor : roboticPalletizerMaterial.GetColor(ColorShaderID);
        colorOverride.SetColor(ColorShaderID, color);
        foreach (var roboticPalletizerMesh in roboticPalletizerMeshes)

        {
            roboticPalletizerMesh.SetPropertyBlock(colorOverride);
        }
    }

    private void OnDestroy()
    {
        if (roboticPalletizerData != null)
        {
            roboticPalletizerData.onDataUpdated -= OnRoboticPalletizerDataUpdated;
        }
    }

    private void Update()
    {
        if (!roboticPalletizerData)
            return;

        var localPos = mapRenderer.transform.InverseTransformPoint(transform.position);
        var coordinate = mapRenderer.TransformLocalPointToMercator(localPos);
        roboticPalletizerData.CurrentLocation = coordinate.ToLatLon();
    }

    private void OnRoboticPalletizerDataUpdated()
    {
        rotateRpm.rpm = (float)roboticPalletizerData.roboticPalletizerData.RoboticArmOperatingSpeed;
        SetAlertStatus(roboticPalletizerData.roboticPalletizerMetaData.Alert);
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        onRoboticPalletizerHoverStartEvent.Raise(roboticPalletizerData);
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        onRoboticPalletizerHoverEndEvent.Raise(roboticPalletizerData);
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        onRoboticPalletizerSelectedEvent.Raise(roboticPalletizerData);
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    }
}