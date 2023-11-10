# DigitalTwin

## Project Description

The project is a Digital Twin representation of a Factory. It has the following components -  

1. Building
2. 2 Factory Floors
3. 10 Robotic Palletizers, 5 on each floor

Each Robotic Palletizer has the following properties - 
1. RoboticPalletizerID : It uniquely identifies each Robotic Palletizer.
2. Alert : 

Each Robotic Palletizer has 6 components having individual properties - 

1. Robotic Arm
   a. Robotic Arm ID : It uniquely identifies each Robotic Arm.
   b. Robotic Arm Status : 
   c. Robotic Arm Power Consumption
   d. Robotic Arm Operating Speed
   e. Robotic Arm Load Capacity

2. Conveyor Belt
   a. Conveyor Belt Speed

3. Light Curtain Sensor
   a. Beam Resolution
   b. Detection Range

4. Pallet Turn Table
   a. Pallet TurnTable Rotation Speed

5. Door
   a. Door - Last Accessed Time
   b. Door Status

6. Pallet Stretch Machine
   a. Plastic Wrapping Speed
   b. Pallet Stretch Machine Film Roll Status
   c. Pallet Stretch Machine Wrapping Film Usage
   
During a live project demonstration, real-time data changes are reflected on Unity 3D. 

## Pre-requisites
1. Visual Studio Code
2. Unity 3D
3. Active Azure Subscription

## Using Project 

1. Download Project from GitHub
2. The extraction of the zip file shall take about 10 minutes.
3. Obtain the path to DeviceSimulator.sln
4. Navigate to the path above within the terminal.
5. Open Unity 3D
6. Run the scene in Unity 3D
7. Now, use the following command in the terminal to start the simulation -

   ```powershell
   dotnet run

8. You can see real-time data changes in Unity 3D.
9. An alert can be sent using the space bar. 
