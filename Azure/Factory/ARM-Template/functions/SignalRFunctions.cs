using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SignalRFunctions
{
    public static class SignalRFunctions
    {
        public static string RoboticPalletizerID;
        public static string RoboticArmID;
        public static bool RoboticArmStatus;
        public static double RoboticArmPowerConsumption;
        public static double RoboticArmOperatingSpeed;
        public static double RoboticArmLoadCapacity;
        public static double ConveyorBeltSpeed;
        public static double LightCurtainResolution;
        public static double LightCurtainRange;
        public static double PalletTurnTableRotationSpeed;
        public static string DoorLastAccessedTime;
        public static bool DoorStatus;
        public static double PalletStretchMachineWrappingSpeed;
        public static bool PalletStretchMachineWrappingFilmRollStatus;
        public static double PalletStretchMachineWrappingFilmUsage;
        public static bool alert;

        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "dttelemetry")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("broadcast")]
        public static Task SendMessage(
            [EventGridTrigger] EventGridEvent eventGridEvent,
            [SignalR(HubName = "dttelemetry")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            JObject eventGridData = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());
            if (eventGridEvent.EventType.Contains("telemetry"))
            {
                var data = eventGridData.SelectToken("data");

                var telemetryMessage = new Dictionary<object, object>();
                foreach (JProperty property in data.Children())
                {
                    log.LogInformation(property.Name + " - " + property.Value);
                    telemetryMessage.Add(property.Name, property.Value);
                }
                return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "TelemetryMessage",
                    Arguments = new[] { telemetryMessage }
                });
            }
            else
            {
                try
                {
                    RoboticPalletizerID = eventGridEvent.Subject;
                    
                    var data = eventGridData.SelectToken("data");
                    var patch = data.SelectToken("patch");
                    foreach(JToken token in patch)
                    {
                        if(token["path"].ToString() == "/Alert")
                        {
                            alert = token["value"].ToObject<bool>();
                        }
                    }

                    log.LogInformation($"setting alert to: {alert}");
                    var property = new Dictionary<object, object>
                    {
                        {"RoboticPalletizerID", RoboticPalletizerID },
                        {"Alert", alert }
                    };
                    return signalRMessages.AddAsync(
                        new SignalRMessage
                        {
                            Target = "PropertyMessage",
                            Arguments = new[] { property }
                        });
                }
                catch (Exception e)
                {
                    log.LogInformation(e.Message);
                    return null;
                }
            }

        }
    }
}