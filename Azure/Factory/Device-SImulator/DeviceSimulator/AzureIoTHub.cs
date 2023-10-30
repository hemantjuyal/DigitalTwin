using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceSimulator
{
    public static class AzureIoTHub
    {
        /// <summary>
        /// Please replace with correct connection string value
        /// The connection string could be got from Azure IoT Hub -> Shared access policies -> iothubowner -> Connection String:
        /// </summary>
        private const string iotHubConnectionString = "HostName=myprojHubn7hcpbdan2.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=qzEPaTC8IfUlC4OhqeP0/LQaAhKnplgWSAIoTMCgwU8=";
        private const string adtInstanceUrl = "https://myprojadtn7hcpbdan2.api.eus.digitaltwins.azure.net";
        private const string alertRoboticPalletizerID = "DT-RP002";
        private const string alertVariableName = "Alert";
        private const string alertRoboticArmID = "DT-RP002-RA002";
        private const bool alertRoboticArmStatus = false;
        private const double alertRoboticArmPowerConsumption = 1500.65D;
        private const double alertRoboticArmOperatingSpeed = 0.8D;
        private const double alertRoboticArmLoadCapacity = 20.0D;
        private const double alertConveyorBeltSpeed = 0.5D;
        private const double alertLightCurtainResolution = 0.01D;
        private const double alertLightCurtainRange = 10.0D;
        private const double alertPalletTurnTableRotationSpeed = 4.32D;
        private const string alertDoorLastAccessedTime = "2023-08-22 7:14:54";
        private const string alertDoorStatus = "Closed";
        private const double alertPalletStretchMachineWrappingSpeed = 2.67D;
        private const bool alertPalletStretchMachineWrappingFilmRollStatus = false;
        private const double alertPalletStretchMachineWrappingFilmUsage = 125.0D;
        private const double alertRoboticArmPowerConsumptionVariance = 100.45D;
        private const double alertRoboticArmOperatingSpeedVariance = -0.4D;
        private const double alertRoboticArmLoadCapacityVariance = 0.5D;
        private static List<string> deviceConnectionStrings;
        private static bool alertSent = false;
        private static int alertIndex;
        
        public static async Task<List<Device>> CreateDeviceIdentitiesAsyc(List<string> deviceIds)
        {
            var registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);
            List<Device> devices = new List<Device>();
            deviceConnectionStrings = new List<string>();
            for(int i = 0; i < deviceIds.Count; i++)
            {
                var device = new Device(deviceIds[i]);
                device = await CreateOrGetDevice(registryManager, device);
                devices.Add(device);
                if(device.Id == alertRoboticPalletizerID)
                {
                    alertIndex = i;
                }
                deviceConnectionStrings.Add(CreateConnectionString(device));
            }
            return devices;
        }

        private static string CreateConnectionString(Device device)
        {
            string connectionString = string.Format("{0};DeviceId={1};SharedAccessKey={2}", iotHubConnectionString.Split(';')[0], device.Id.ToString(), device.Authentication.SymmetricKey.PrimaryKey.ToString());
            return connectionString;
        }

        private static async Task<Device> CreateOrGetDevice(RegistryManager registryManager, Device device)
        {
            try
            {
                Device createdDevice = await registryManager.AddDeviceAsync(device);
                Console.WriteLine("Adding device " + device.Id);
                return createdDevice;
            }
            catch(DeviceAlreadyExistsException)
            {
                Console.WriteLine("Retrieved device " + device.Id);
                return await registryManager.GetDeviceAsync(device.Id);
            }
        }

        public static async Task SendDeviceToCloudMessageAsync(CancellationToken cancelToken)
        {
            List<DeviceClient> deviceClients = new List<DeviceClient>();
            foreach (string deviceConnectionString in deviceConnectionStrings)
            {
                //use connection string to create a device client
                deviceClients.Add(DeviceClient.CreateFromConnectionString(deviceConnectionString));
            }
            
            List<TelemetryData> data = Telemetry.GetDataLines();
            int dataIterator = 0;
            while (!cancelToken.IsCancellationRequested)
            {
                for (int i = 0; i < deviceClients.Count; i++)
                {
                    Microsoft.Azure.Devices.Client.Message message = new Microsoft.Azure.Devices.Client.Message();
                    if (alertSent && data[i + dataIterator].RoboticPalletizerID == alertRoboticPalletizerID)
                    {
                        // This is sending a specified Alert message
                        message = ConstructTelemetryDataPoint(data[i + dataIterator], isAlert: true);
                        PropUpdater propUpdater = new PropUpdater(adtInstanceUrl);
                        var twinData = await propUpdater.GetTwinData(alertRoboticPalletizerID);
                        if (twinData.Value<bool>(alertVariableName) == false)
                        {
                            alertSent = false;
                        }
                    }
                    else
                    {
                        //Basic telemetry message without alert
                        message = ConstructTelemetryDataPoint(data[i + dataIterator], isAlert: false);
                    }
                    await deviceClients[i].SendEventAsync(message);
                }
                if (dataIterator < data.Count - deviceClients.Count)
                {
                    dataIterator += deviceClients.Count;
                }
                else
                {
                    Console.WriteLine("Press any key to restart the data sequence");
                    Console.ReadKey();
                    dataIterator = 0;
                }
                await Task.Delay(5000);
                //Keep this value above 1000 to keep a safe buffer above the ADT service limits
                //See https://aka.ms/adt-limits for more info
            }
        }

        private static Microsoft.Azure.Devices.Client.Message ConstructTelemetryDataPoint(TelemetryData data, bool isAlert)
        {
            Random rand = new Random();
            TelemetryData telData = new TelemetryData(data);
            if(isAlert)
            {
                
                /*telData.RoboticPalletizerID = RoboticPalletizerID;
                telData.RoboticArmID = RoboticArmID;
                telData.RoboticArmStatus = RoboticArmStatus;*/
                telData.RoboticArmPowerConsumption = alertRoboticArmPowerConsumption+(alertRoboticArmPowerConsumptionVariance +rand.NextDouble());
                telData.RoboticArmOperatingSpeed = alertRoboticArmOperatingSpeed+(alertRoboticArmOperatingSpeedVariance +rand.NextDouble());
                telData.RoboticArmLoadCapacity = alertRoboticArmLoadCapacity+(alertRoboticArmLoadCapacityVariance+rand.NextDouble());
                /*telData.ConveyorBeltSpeed = ConveyorBeltSpeed;
                telData.LightCurtainResolution = LightCurtainResolution;
                telData.LightCurtainRange = LightCurtainRange;
                telData.PalletTurnTableRotationSpeed = PalletTurnTableRotationSpeed;
                telData.DoorLastAccessedTime = DoorLastAccessedTime;
                telData.DoorStatus = DoorStatus;
                telData.PalletStretchMachineWrappingSpeed = PalletStretchMachineWrappingSpeed;
                telData.PalletStretchMachineWrappingFilmRollStatus = PalletStretchMachineWrappingFilmRollStatus;
                telData.PalletStretchMachineWrappingFilmUsage = PalletStretchMachineWrappingFilmUsage;*/

            }

            var payload = new
            {
                RoboticPalletizerID = telData.RoboticPalletizerID,
		        RoboticArmID = telData.RoboticArmID,
		        RoboticArmStatus = telData.RoboticArmStatus,
		        RoboticArmPowerConsumption = telData.RoboticArmPowerConsumption,
		        RoboticArmOperatingSpeed = telData.RoboticArmOperatingSpeed,
		        RoboticArmLoadCapacity = telData.RoboticArmLoadCapacity,
		        ConveyorBeltSpeed = telData.ConveyorBeltSpeed,
		        LightCurtainResolution = telData.LightCurtainResolution,
		        LightCurtainRange = telData.LightCurtainRange,
		        PalletTurnTableRotationSpeed = telData.PalletTurnTableRotationSpeed,
		        DoorLastAccessedTime = telData.DoorLastAccessedTime,
		        DoorStatus = telData.DoorStatus,
		        PalletStretchMachineWrappingSpeed = telData.PalletStretchMachineWrappingSpeed,
		        PalletStretchMachineWrappingFilmRollStatus = telData.PalletStretchMachineWrappingFilmRollStatus,
		        PalletStretchMachineWrappingFilmUsage = telData.PalletStretchMachineWrappingFilmUsage
            };
            var messageString = JsonSerializer.Serialize(payload);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DateTime.Now} > Sending message: {messageString}");
            return new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(messageString))
            {
                ContentType = "application/json",
                ContentEncoding = "utf-8"
            };
        }

        public static async Task SendAlert()
        {
            try
            {
                var payload = new
                {
                    RoboticPalletizerID = alertRoboticPalletizerID,
                    Alert = !alertSent
                };
                var messageString = JsonSerializer.Serialize(payload);
                var client = DeviceClient.CreateFromConnectionString(deviceConnectionStrings[alertIndex]);
                var message = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(messageString))
                {
                    ContentType = "application/json",
                    ContentEncoding = "utf-8"
                };
                
                await client.SendEventAsync(message);
                alertSent = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task ReceiveMessagesFromDeviceAsync(CancellationToken cancelToken)
        {
            try
            {
                string eventHubConnectionString = await IotHubConnection.GetEventHubsConnectionStringAsync(iotHubConnectionString);
                await using var consumerClient = new EventHubConsumerClient(
                    EventHubConsumerClient.DefaultConsumerGroupName,
                    eventHubConnectionString);

                await foreach (PartitionEvent partitionEvent in consumerClient.ReadEventsAsync(cancelToken))
                {
                    if (partitionEvent.Data == null) continue;

                    string data = Encoding.UTF8.GetString(partitionEvent.Data.Body.ToArray());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Message received. Partition: {partitionEvent.Partition.PartitionId} Data: '{data}'");
                }
            }
            catch (TaskCanceledException) { 
                Console.WriteLine($"..");
            } // do nothing
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading event: {ex}");
            }
        }
    }
}
