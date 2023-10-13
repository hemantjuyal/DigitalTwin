using System.IO;
using System.Collections.Generic;

/// <summary>
/// Handles loading data from data file
/// </summary>
public class Telemetry
{
	private const string dataFile = "./data.csv";

	public static List<TelemetryData> GetDataLines()
    {
		using (StreamReader sr = new StreamReader(dataFile))
		{
			List<TelemetryData> allTelemetryData = new List<TelemetryData>();
			sr.ReadLine();
			while (!sr.EndOfStream)
			{
				allTelemetryData.Add(CreateTelemetryData(sr.ReadLine()));
			}
			return allTelemetryData;
		}
    }

	private static TelemetryData CreateTelemetryData(string line)
    {
		TelemetryData data = new TelemetryData();
		string[] split = line.Split(',');
		data.RoboticPalletizerID = split[0];
		data.RoboticArmID = split[1];
		bool.TryParse(split[2], out data.RoboticArmStatus);
		double.TryParse(split[3], out data.RoboticArmPowerComsumption);
		double.TryParse(split[4], out data.RoboticArmOperatingSpeed);
		double.TryParse(split[5], out data.RoboticArmLoadCapacity);
		double.TryParse(split[6], out data.ConveyerBeltSpeed);
		double.TryParse(split[7], out data.LightCurtainResolution);
		double.TryParse(split[8], out data.LightCurtainRange);
		double.TryParse(split[9], out data.PalletTurnTableRotationSpeed);
		data.DoorLastAccessedTime = split[10];
		bool.TryParse(split[11], out data.DoorStatus);
		double.TryParse(split[12], out data.PalletStretchMachineWrappingSpeed);
		bool.TryParse(split[13], out data.PalletStretchMachineWrappingFilmRollStatus);
		double.TryParse(split[14], out data.PalletStretchMachineWrappingFilmRollUsage);
		return data;
	}
}
