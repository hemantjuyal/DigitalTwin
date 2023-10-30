# Using Device Simulator Files

## Verification of Previous Steps from the ARM Template README

1. Verify that adtInstanceUrl and iotHubConnectionString in AzureIoTHub.cs file under DeviceSimulator directory is configured properly as described in the ARM-Template README file.

2. Verify that clientId, clientSecret, and, tenantId in PropUpdater.cs file under DeviceSimulator directory is configured properly as described in the ARM-Template README file.

##  Begin the Digital Twin Project Simulation

1. Copy the path to the DeviceSimulator.sln file
   
   ```powershell
   $cd <path for DeviceSimulator.sln>

2. Open the terminal in Visual Studio Code Editor and paste the path to the DeviceSimulator.

3. Use the following command to start the simulation - 

   ```powershell
   dotnet run
