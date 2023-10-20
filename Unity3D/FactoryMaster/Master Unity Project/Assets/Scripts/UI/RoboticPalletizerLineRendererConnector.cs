// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using UnityEngine;

/// <summary>
/// Connects a LineRenderer to a target Robotic Palletizer in the scene
/// </summary>
[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class RoboticPalletizerLineRendererConnector : MonoBehaviour
{
    public RoboticPalletizerSiteData siteData;
    public Transform[] anchorPoints = new Transform[0];
    private Vector3[] anchorPositions;
    private Transform target;
    private LineRenderer lineRenderer;
    private Transform TargetAnchor => anchorPoints[anchorPoints.Length - 1];

    /// <summary>
    /// Set the target Robotic Palletizer in the scene from its data object
    /// </summary>
    public void SetTarget(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        if (siteData.TryGetRoboticPalletizerGameObject(roboticPalletizerData, out var go))
        {
            //Target the rotor of the Robotic Palletizer
            target = go.GetComponentInChildren<RotateRPM>().transform;
        }
    }

    private void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = anchorPoints.Length;
        anchorPositions = new Vector3[anchorPoints.Length];
    }

    private void Update()
    {
        if (!target || !lineRenderer)
            return;

        TargetAnchor.transform.position = target.position;
        SetLinePositions();
    }

    private void SetLinePositions()
    {
        lineRenderer.positionCount = target.gameObject.activeInHierarchy
            ? lineRenderer.positionCount = anchorPoints.Length
            : anchorPoints.Length - 1;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            if (anchorPoints[i] != null)
            {
                anchorPositions[i] = anchorPoints[i].transform.position;
            }
        }

        lineRenderer.SetPositions(anchorPositions);
    }
}