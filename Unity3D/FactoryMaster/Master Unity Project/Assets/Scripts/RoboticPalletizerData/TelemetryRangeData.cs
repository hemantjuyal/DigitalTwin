// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using UnityEngine;

/// <summary>
/// Scriptable object for Telemetry range data
/// </summary>
[CreateAssetMenu(fileName = "TelemetryRangeData", menuName = "Scriptable Objects/Robotic Palletizer Data/Telemetry Range Data")]
public class TelemetryRangeData : ScriptableObject
{
  
    public double minValue;

    public double maxValue;

    public double optimalValue;
    
    public Gradient healthIndicatorGradient;

    public string units;
    
    public int displayRoundingPrecision;
}