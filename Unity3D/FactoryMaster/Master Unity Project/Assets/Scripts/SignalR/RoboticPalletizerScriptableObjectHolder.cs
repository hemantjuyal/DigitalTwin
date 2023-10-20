// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections.Generic;
using UnityEngine;

public class RoboticPalletizerScriptableObjectHolder : MonoBehaviour
{
    public List<RoboticPalletizerScriptableObject> roboticPalletizerDigitalTwins;

    private void Start()
    {
        if (roboticPalletizerDigitalTwins.Capacity < 1)
        {
            roboticPalletizerDigitalTwins = new List<RoboticPalletizerScriptableObject>();
        }
    }
}