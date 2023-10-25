// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using UnityEngine;

/// <summary>
/// Robotic Palletizer Data information
/// </summary>
/// 
[Serializable]
public class RoboticPalletizerData

{
   
    [field: SerializeField]
    public string RoboticPalletizerID { get; set; }


    [field: SerializeField]
    public string RoboticArmID { get; set; }


    [field: SerializeField]
    public bool RoboticArmStatus { get; set; }

   
    [field: SerializeField]
    public double RoboticArmPowerConsumption { get; set; }

 
    [field: SerializeField]
    public double RoboticArmOperatingSpeed { get; set; }

 
    [field: SerializeField]
    public double RoboticArmLoadCapacity { get; set; }

 
    [field: SerializeField]
    public double ConveyorBeltSpeed { get; set; }


    [field: SerializeField]
    public double LightCurtainResolution { get; set; }


    [field: SerializeField]
    public double LightCurtainRange { get; set; }


    [field: SerializeField]
    public double PalletTurnTableRotationSpeed { get; set; }


    [field: SerializeField]
    public string DoorLastAccessedTime { get; set; }


    [field: SerializeField]
    public bool DoorStatus { get; set; }


    [field: SerializeField]
    public double PalletStretchMachineWrappingSpeed { get; set; }


    [field: SerializeField]
    public bool PalletStretchMachineWrappingFilmRollStatus { get; set; }


    [field: SerializeField]
    public double PalletStretchMachineWrappingFilmUsage { get; set; }


}