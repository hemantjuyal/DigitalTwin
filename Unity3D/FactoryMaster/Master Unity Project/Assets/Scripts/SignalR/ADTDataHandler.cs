// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using Microsoft.Unity;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ADTDataHandler : MonoBehaviour
{
    private SignalRService rService;

    public string url = "";

    public RoboticPalletizerSiteData roboticPalletizerSiteData;
    public RoboticPalletizerGameEvent RoboticPalletizerPropertyMessageReceived;

    private void Start()
    {
        this.RunSafeVoid(CreateServiceAsync);
    }

    private void OnDestroy()
    {
        if (rService != null)
        {
            rService.OnConnected -= HandleConnected;
            rService.OnTelemetryMessage -= HandleTelemetryMessage;
            rService.OnDisconnected -= HandleDisconnected;
            rService.OnPropertyMessage -= HandlePropertyMessage;
        }
    }

    /// <summary>
    /// Received a message from SignalR. Note, this message is received on a background thread.
    /// </summary>
    /// <param name="message">
    /// The message.
    /// </param>
    private void HandleTelemetryMessage(TelemetryMessage message)
    {
        // Finally update Unity GameObjects, but this must be done on the Unity Main thread.
        UnityDispatcher.InvokeOnAppThread(() =>
        {
            foreach (RoboticPalletizerScriptableObject RoboticPalletizer in roboticPalletizerSiteData.roboticPalletizerData)
            {
                if (RoboticPalletizer.roboticPalletizerData.RoboticPalletizerID == message.RoboticPalletizerID)
                {
                    RoboticPalletizer.UpdateData(CreateNewRoboticPalletizerData(message));
                    return;
                }
            }
        });
    }

    /// <summary>
    /// Construct the Robotic Palletizer Data received from SignalR
    /// </summary>
    /// <param name="message">Telemetry data</param>
    /// <returns>Data values of Robotic Palletizer</returns>
    private RoboticPalletizerData CreateNewRoboticPalletizerData(TelemetryMessage message)
    {
        RoboticPalletizerData data = new RoboticPalletizerData
        {
            RoboticPalletizerID = message.RoboticPalletizerID,
            RoboticArmID = message.RoboticArmID,
            RoboticArmStatus = message.RoboticArmStatus,
            RoboticArmPowerConsumption = message.RoboticArmPowerConsumption,
            RoboticArmOperatingSpeed = message.RoboticArmOperatingSpeed,
            RoboticArmLoadCapacity = message.RoboticArmLoadCapacity,
            ConveyorBeltSpeed = message.ConveyorBeltSpeed,
            LightCurtainResolution = message.LightCurtainResolution,
            LightCurtainRange = message.LightCurtainRange,
            PalletTurnTableRotationSpeed = message.PalletTurnTableRotationSpeed,
            DoorLastAccessedTime = message.DoorLastAccessedTime,
            DoorStatus = message.DoorStatus,
            PalletStretchMachineWrappingSpeed = message.PalletStretchMachineWrappingSpeed,
            PalletStretchMachineWrappingFilmRollStatus = message.PalletStretchMachineWrappingFilmRollStatus,
            PalletStretchMachineWrappingFilmUsage = message.PalletStretchMachineWrappingFilmUsage
        };
        return data;
    }

    /// <summary>
    /// Received a Property message from SignalR. Note, this message is received on a background thread.
    /// </summary>
    /// <param name="message">
    /// The message
    /// </param>
    private void HandlePropertyMessage(PropertyMessage message)
    {
        UnityDispatcher.InvokeOnAppThread(() =>
        {
            Debug.Log(message);
            var matchingRoboticPalletizers = roboticPalletizerSiteData.roboticPalletizers.Where(t => t.Key.roboticPalletizerData.RoboticPalletizerID == message.RoboticPalletizerID);
            if (!matchingRoboticPalletizers.Any())
            {
                Debug.LogWarning($"Robotic Palletizer ID {message.RoboticPalletizerID} was not found in the Site Data.");
                return;
            }
            var roboticPalletizerScriptableObject = matchingRoboticPalletizers.First().Key;
            roboticPalletizerScriptableObject.roboticPalletizerMetaData.Alert = message.Alert;
            RoboticPalletizerPropertyMessageReceived.Raise(roboticPalletizerScriptableObject);
        });
    }

    private Task CreateServiceAsync()
    {
        rService = new SignalRService();
        rService.OnConnected += HandleConnected;
        rService.OnDisconnected += HandleDisconnected;
        rService.OnTelemetryMessage += HandleTelemetryMessage;
        rService.OnPropertyMessage += HandlePropertyMessage;

        return rService.StartAsync(url);
    }

    private void HandleConnected(string obj)
    {
        Debug.Log("Connected, Connected to Azure Digital Twin");

    }

    private void HandleDisconnected()
    {
        Debug.Log("Disconnected");
    }
}