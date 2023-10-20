// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;

/// <summary>
/// This class is used to hold data that comes from ADT
/// </summary>
[Serializable]
public class TelemetryMessage
{
    public string RoboticPalletizerID { get; set; }
    public string RoboticArmID { get; set; }
    public bool RoboticArmStatus { get; set; }
    public double RoboticArmPowerComsumption { get; set; }
    public double RoboticArmOperatingSpeed { get; set; }
    public double RoboticArmLoadCapacity { get; set; }
    public double ConveyerBeltSpeed { get; set; }
    public double LightCurtainResolution { get; set; }
    public double LightCurtainRange { get; set; }
    public double PalletTurnTableRotationSpeed { get; set; }
    public string DoorLastAccessedTime { get; set; }
    public bool DoorStatus { get; set; }
    public double PalletStretchMachineWrappingSpeed { get; set; }
    public bool PalletStretchMachineWrappingFilmRollStatus { get; set; }
    public double PalletStretchMachineWrappingFilmRollUsage { get; set; }
}