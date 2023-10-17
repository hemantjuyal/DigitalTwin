using Azure;
using Azure.Core.Pipeline;
using Azure.DigitalTwins.Core;
using Azure.Identity;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;

namespace My.Function
{
    // This class processes telemetry events from IoT Hub, reads temperature of a device
    // and sets the "Temperature" property of the device with the value of the telemetry.
    public class telemetryfunction
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static string adtServiceUrl = Environment.GetEnvironmentVariable("ADT_SERVICE_URL");

        [FunctionName("telemetryfunction")]
        public async void Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            try
            {
                // After this is deployed, you need to turn the Managed Identity Status to "On",
                // Grab Object Id of the function and assigned "Azure Digital Twins Owner (Preview)" role
                // to this function identity in order for this function to be authorized on ADT APIs.
                //Authenticate with Digital Twins
                var credentials = new DefaultAzureCredential();
                log.LogInformation(credentials.ToString());
                DigitalTwinsClient client = new DigitalTwinsClient(
                    new Uri(adtServiceUrl), credentials, new DigitalTwinsClientOptions
                    { Transport = new HttpClientTransport(httpClient) });
                log.LogInformation($"ADT service client connection created.");
                if (eventGridEvent.Data.ToString().Contains("Alert"))
                {
                    JObject alertMessage = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());
                    string deviceId = (string)alertMessage["systemProperties"]["iothub-connection-device-id"];
                    var RoboticPalletizerID = alertMessage["body"]["RoboticPalletizerID"];
                    var alert = alertMessage["body"]["Alert"];
                    log.LogInformation($"Device:{deviceId} Device Id is:{RoboticPalletizerID}");
                    log.LogInformation($"Device:{deviceId} Alert Status is:{alert}");

                    var updateProperty = new JsonPatchDocument();
                    updateProperty.AppendReplace("/Alert", alert.Value<bool>());
                    updateProperty.AppendReplace("/RoboticPalletizerID", RoboticPalletizerID.Value<string>());
                    log.LogInformation(updateProperty.ToString());
                    try
                    {
                        await client.UpdateDigitalTwinAsync(deviceId, updateProperty);
                    }
                    catch (Exception e)
                    {
                        log.LogInformation(e.Message);
                    }
                }
                else if (eventGridEvent != null && eventGridEvent.Data != null)
                {

                    JObject deviceMessage = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());
                    string deviceId = (string)deviceMessage["systemProperties"]["iothub-connection-device-id"];
                    var RoboticPalletizerID = (string)deviceMessage["body"]["RoboticPalletizerID"];
                    var RoboticArmID = (string)deviceMessage["body"]["RoboticArmID"];
                    var RoboticArmStatus = (bool)deviceMessage["body"]["RoboticArmStatus"];
                    var RoboticArmPowerConsumption = (double)deviceMessage["body"]["RoboticArmPowerConsumption"];
                    var RoboticArmOperatingSpeed = (double)deviceMessage["body"]["RoboticArmOperatingSpeed"];
                    var RoboticArmLoadCapacity = (double)deviceMessage["body"]["RoboticArmLoadCapacity"];
                    var ConveyorBeltSpeed = (double)deviceMessage["body"]["ConveyorBeltSpeed"];
                    var LightCurtainResolution = (double)deviceMessage["body"]["LightCurtainResolution"];
                    var LightCurtainRange = (double)deviceMessage["body"]["LightCurtainRange"];
                    var PalletTurnTableRotationSpeed = (double)deviceMessage["body"]["PalletTurnTableRotationSpeed"];
                    var DoorLastAccessedTime = (string)deviceMessage["body"]["DoorLastAccessedTime"];
                    var DoorStatus = (bool)deviceMessage["body"]["DoorStatus"];
                    var PalletStretchMachineWrappingSpeed = (double)deviceMessage["body"]["PalletStretchMachineWrappingSpeed"];
                    var PalletStretchMachineWrappingFilmRollStatus = (bool)deviceMessage["body"]["PalletStretchMachineWrappingFilmRollStatus"];
                    var PalletStretchMachineWrappingFilmUsage = (double)deviceMessage["body"]["PalletStretchMachineWrappingFilmUsage"];
                    

                    log.LogInformation($"Device:{deviceId} Device Id is:{RoboticPalletizerID}");
                    log.LogInformation($"Device:{deviceId} RoboticArmID is:{RoboticArmID}");
                    log.LogInformation($"Device:{deviceId} RoboticArmStatus is:{RoboticArmStatus}");
                    log.LogInformation($"Device:{deviceId} RoboticArmPowerConsumption is:{RoboticArmPowerConsumption}");
                    log.LogInformation($"Device:{deviceId} RoboticArmOperatingSpeed is:{RoboticArmOperatingSpeed}");
                    log.LogInformation($"Device:{deviceId} RoboticArmLoadCapacity is:{RoboticArmLoadCapacity}");
                    log.LogInformation($"Device:{deviceId} ConveyorBeltSpeed is:{ConveyorBeltSpeed}");
                    log.LogInformation($"Device:{deviceId} LightCurtainResolution is:{LightCurtainResolution}");
                    log.LogInformation($"Device:{deviceId} LightCurtainRange is:{LightCurtainRange}");
                    log.LogInformation($"Device:{deviceId} PalletTurnTableRotationSpeed is:{PalletTurnTableRotationSpeed}");
                    log.LogInformation($"Device:{deviceId} DoorLastAccessedTime is:{DoorLastAccessedTime}");
                    log.LogInformation($"Device:{deviceId} DoorStatus is:{DoorStatus}");
                    log.LogInformation($"Device:{deviceId} PalletStretchMachineWrappingSpeed is:{PalletStretchMachineWrappingSpeed}");
                    log.LogInformation($"Device:{deviceId} PalletStretchMachineWrappingFilmRollStatus is:{PalletStretchMachineWrappingFilmRollStatus}");
                    log.LogInformation($"Device:{deviceId} PalletStretchMachineWrappingFilmUsage is:{PalletStretchMachineWrappingFilmUsage}");
                    
                    var updateProperty = new JsonPatchDocument();
                    var RoboticPalletizerTelemetry = new Dictionary<string, Object>()
                    {
                        ["RoboticPalletizerID"] = RoboticPalletizerID,
                        ["RoboticArmID"] = RoboticArmID,
                        ["RoboticArmStatus"] = RoboticArmStatus,
                        ["RoboticArmPowerConsumption"] = RoboticArmPowerConsumption,
                        ["RoboticArmOperatingSpeed"] = RoboticArmOperatingSpeed,
                        ["RoboticArmLoadCapacity"] = RoboticArmLoadCapacity,
                        ["ConveyorBeltSpeed"] = ConveyorBeltSpeed,
                        ["LightCurtainResolution"] = LightCurtainResolution,
                        ["LightCurtainRange"] = LightCurtainRange,
                        ["PalletTurnTableRotationSpeed"] = PalletTurnTableRotationSpeed,
                        ["DoorLastAccessedTime"] = DoorLastAccessedTime,
                        ["DoorStatus"] = DoorStatus,
                        ["PalletStretchMachineWrappingSpeed"] = PalletStretchMachineWrappingSpeed,
                        ["PalletStretchMachineWrappingFilmRollStatus"] = PalletStretchMachineWrappingFilmRollStatus,
                        ["PalletStretchMachineWrappingFilmUsage"] = PalletStretchMachineWrappingFilmUsage
                    };
                    updateProperty.AppendAdd("/RoboticPalletizerID", RoboticPalletizerID.Value<string>());
                    updateProperty.AppendAdd("/RoboticArmID", RoboticPalletizerID.Value<string>());
                    updateProperty.AppendAdd("/RoboticArmStatus", RoboticArmStatus.Value<bool>());
                    updateProperty.AppendAdd("/RoboticArmPowerConsumption", RoboticArmPowerConsumption.Value<double>());
                    updateProperty.AppendAdd("/RoboticArmOperatingSpeed", RoboticArmOperatingSpeed.Value<double>());
                    updateProperty.AppendAdd("/RoboticArmLoadCapacity", RoboticArmLoadCapacity.Value<double>());
                    updateProperty.AppendAdd("/ConveyorBeltSpeed", ConveyorBeltSpeed.Value<double>());
                    updateProperty.AppendAdd("/LightCurtainResolution", LightCurtainResolution.Value<double>());
                    updateProperty.AppendAdd("/LightCurtainRange", LightCurtainRange.Value<double>());
                    updateProperty.AppendAdd("/PalletTurnTableRotationSpeed", PalletTurnTableRotationSpeed.Value<double>());
                    updateProperty.AppendAdd("/DoorLastAccessedTime", DoorLastAccessedTime.Value<string>());
                    updateProperty.AppendAdd("/DoorStatus", DoorStatus.Value<bool>());
                    updateProperty.AppendAdd("/PalletStretchMachineWrappingSpeed", PalletStretchMachineWrappingSpeed.Value<double>());
                    pdateProperty.AppendAdd("/PalletStretchMachineWrappingFilmRollStatus", PalletStretchMachineWrappingFilmRollStatus.Value<bool>());
                    pdateProperty.AppendAdd("/PalletStretchMachineWrappingFilmUsage", PalletStretchMachineWrappingFilmUsage.Value<double>());
                    

                    log.LogInformation(updateProperty.ToString());
                    try
                    {
                        await client.PublishTelemetryAsync(deviceId, Guid.NewGuid().ToString(), JsonConvert.SerializeObject(RoboticPalletizerTelemetry));
                    }
                    catch (Exception e)
                    {
                        log.LogInformation(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                log.LogInformation(e.Message);
            }
        }
    }
}