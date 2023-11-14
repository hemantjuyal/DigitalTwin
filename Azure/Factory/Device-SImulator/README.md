# Device Simulator Usage Guide

Please ensure that you have set up the ARM-Template as per the instructions in the [ARM-Template Usage Guide](https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/ARM-Template#arm-template-usage-guide/ "ARM-Template Usage Guide")

Refer to the following steps once you are done setting up the ARM-Template - 

1. Verify that **adtInstanceUrl** and **iotHubConnectionString** in `AzureIoTHub.cs` file under DeviceSimulator directory is configured properly as described in the [Configuring Device-Simulator with Primary Connection String](https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/ARM-Template#configure-the-device-simulator-with-primary-connection-string/ "Configuring Device-Simulator Primary Connection String") Guide.

   Snapshot of `AzureIoTHub.cs` file in Visual Studio Code -

   ![az](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/9f588f04-ce5f-404b-8354-951745a2f11b)

3. Verify that **clientId, clientSecret, and, tenantId** in `PropUpdater.cs` file under DeviceSimulator directory is configured properly as described in the [Configuring Device-Simulator with Authentication keys](https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/ARM-Template#configure-the-device-simulator-with-authentication-keys/ "Configuring Device-Simulator with Authentication keys") Guide.

   Snapshot of `PropUpdater.cs` file in Visual Studio Code -
   
   ![pr](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/23107504-1cb0-41fb-9aaa-c20a5b5015cf)


##  Begin the Digital Twin Project Simulation

1. Copy the path to the DeviceSimulator.sln file
   
   ```powershell
   $cd <path for DeviceSimulator.sln>

2. Open the terminal in Visual Studio Code Editor and paste the path to the DeviceSimulator.

   ![terminal](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a714d59e-c733-48e4-86a6-1b74d8dbf240)

3. Use the following command to start the simulation - 

   ```powershell
   dotnet run

4. One key is to be pressed to begin the simulation when prompted to -

   ![key](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/c04e6b5d-791c-4b96-85db-0ad46e874dbe)

5. Logs are printed to verify that the simulation has started -

   ![logs](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/89d5e4c6-aee2-4b9c-b459-54e957fd88cf)

6. Press Spacebar to send an Alert.
   
7. Press Ctrl + C to stop the simulation -

   ![exit](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/c4383191-e376-4301-aae3-f8173cf6340d)

