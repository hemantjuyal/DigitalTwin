/// <summary>
/// Holds data for telemetry
/// </summary>
public class TelemetryData
{
	public string RoboticPalletizerID;
	public string RoboticArmID;
	public bool RoboticArmStatus;
	public double RoboticArmPowerComsumption;
	public double RoboticArmOperatingSpeed;
	public double RoboticArmLoadCapacity;
	public double ConveyerBeltSpeed;
	public double LightCurtainResolution;
	public double LightCurtainRange;
	public double PalletTurnTableRotationSpeed;
	public string DoorLastAccessedTime;
	public bool DoorStatus;
	public double PalletStretchMachineWrappingSpeed;
	public bool PalletStretchMachineWrappingFilmRollStatus;
	public double PalletStretchMachineWrappingFilmRollUsage;

	public TelemetryData() { }
    
	public TelemetryData(TelemetryData data)
    {
		RoboticPalletizerID = data.RoboticPalletizerID;
		RoboticArmID = data.RoboticArmID;
		RoboticArmStatus = data.RoboticArmStatus;
		RoboticArmPowerComsumption = data.RoboticArmPowerComsumption;
		RoboticArmOperatingSpeed = data.RoboticArmOperatingSpeed;
		RoboticArmLoadCapacity = data.RoboticArmLoadCapacity;
		ConveyerBeltSpeed = data.ConveyerBeltSpeed;
		LightCurtainResolution = data.LightCurtainResolution;
		LightCurtainRange = data.LightCurtainRange;
		PalletTurnTableRotationSpeed = data.PalletTurnTableRotationSpeed;
		DoorLastAccessedTime = ata.DoorLastAccessedTime;
		DoorStatus = data.DoorStatus;
		PalletStretchMachineWrappingSpeed = data.PalletStretchMachineWrappingSpeed;
		PalletStretchMachineWrappingFilmRollStatus = data.PalletStretchMachineWrappingFilmRollStatus;
		PalletStretchMachineWrappingFilmRollUsage = data.PalletStretchMachineWrappingFilmRollUsage;
    }
}
