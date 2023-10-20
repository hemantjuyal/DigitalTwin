// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using UnityEngine;


[Serializable]

public class RoboticPalletizerMetaData
{

    [field: SerializeField]
    public string BuildingName { get; set; }


    [field: SerializeField]
    public double Latitude { get; set; }


    [field: SerializeField]
    public double Longitude { get; set; }
    

    [field: SerializeField]
    public double Altitude { get; set; }


    [field: SerializeField]
    public string RobticPalletizerModel { get; set; }


    [field: SerializeField]
    public double FactoryFloor { get; set; }


    [field: SerializeField]
    public bool Alert { get; set; }
}