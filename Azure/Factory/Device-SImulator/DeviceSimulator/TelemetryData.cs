/// <summary>
/// Holds data for telemetry
/// </summary>
public class TelemetryData
{
	public string RoboticPalletizerID;
	public string RoboticArmID;
	public bool RoboticArmStatus;
	public double RoboticArmPowerConsumption;
	public double RoboticArmOperatingSpeed;
	public double RoboticArmLoadCapacity;
	public double ConveyorBeltSpeed;
	public double LightCurtainResolution;
	public double LightCurtainRange;
	public double PalletTurnTableRotationSpeed;
	public string DoorLastAccessedTime;
	public bool DoorStatus;
	public double PalletStretchMachineWrappingSpeed;
	public bool PalletStretchMachineWrappingFilmRollStatus;
	public double PalletStretchMachineWrappingFilmUsage;

	public TelemetryData() { }
    
	public TelemetryData(TelemetryData data)
    {
		RoboticPalletizerID = data.RoboticPalletizerID;
		RoboticArmID = data.RoboticArmID;
		RoboticArmStatus = data.RoboticArmStatus;
		RoboticArmPowerConsumption = data.RoboticArmPowerConsumption;
		RoboticArmOperatingSpeed = data.RoboticArmOperatingSpeed;
		RoboticArmLoadCapacity = data.RoboticArmLoadCapacity;
		ConveyorBeltSpeed = data.ConveyorBeltSpeed;
		LightCurtainResolution = data.LightCurtainResolution;
		LightCurtainRange = data.LightCurtainRange;
		PalletTurnTableRotationSpeed = data.PalletTurnTableRotationSpeed;
		DoorLastAccessedTime = data.DoorLastAccessedTime;
		DoorStatus = data.DoorStatus;
		PalletStretchMachineWrappingSpeed = data.PalletStretchMachineWrappingSpeed;
		PalletStretchMachineWrappingFilmRollStatus = data.PalletStretchMachineWrappingFilmRollStatus;
		PalletStretchMachineWrappingFilmUsage = data.PalletStretchMachineWrappingFilmUsage;
    }
}
