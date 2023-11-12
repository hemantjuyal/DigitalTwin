# DigitalTwin

## Project Description

This project is a Digital Twin representation of a Factory. It has the following components -  

1. Building
2. 2 Factory Floors
3. 10 Robotic Palletizers, 5 on each floor

Each Robotic Palletizer has the following properties - 
1. RoboticPalletizerID : It uniquely identifies each Robotic Palletizer.
   
2. Alert : Raises a warning when alert is sent from the local machine. The alert can be observed by a change in color of the Robotic Palletizer when certain components of the Palletizer display values in an abormal range. 

Each Robotic Palletizer has 6 components having individual properties - 

### 1. Robotic Arm
   
   a. Robotic Arm ID : A unique identifier assigned to each robotic arm for identification.

   b. Robotic Arm Status : Indicates the current operational state of the robotic arm, whether it is active or idle.
   
   c. Robotic Arm Power Consumption : The amount of electrical power consumed by the robotic arm during its operation, measured in watts.
   
   d. Robotic Arm Operating Speed : The speed at which the robotic arm performs its tasks, determining the velocity of its movements.
   
   e. Robotic Arm Load Capacity : The maximum weight or load that the robotic arm is designed to carry or manipulate without exceeding its specified limits.

### 2. Conveyor Belt
   
   a. Conveyor Belt Speed : The rate at which the conveyor belt moves, determining the speed of material or objects being transported.

### 3. Light Curtain Sensor
   
   a. Beam Resolution : The level of detail or granularity in the light curtain sensor's detection, influencing its precision.
   
   b. Detection Range : The maximum distance over which the light curtain sensor can detect objects or interruptions in the beam.

### 4. Pallet Turn Table
   
   a. Pallet TurnTable Rotation Speed : The speed at which the pallet turn table rotates, influencing the efficiency of pallet handling.

### 5. Door
    
   a. Door - Last Accessed Time : The timestamp indicating the most recent time the door was accessed or opened. 
   
   b. Door Status : The current state of the door, such as "Open" or "Closed".

### 6. Pallet Stretch Machine
    
   a. Plastic Wrapping Speed : The speed at which the pallet stretch machine wraps plastic around the pallet.
   
   b. Pallet Stretch Machine Film Roll Status : Indicates whether the film roll used for wrapping is available or needs replacement.
   
   c. Pallet Stretch Machine Wrapping Film Usage : The amount of wrapping film consumed by the pallet stretch machine during operations.
   
During a live project demonstration, real-time data changes are reflected on Unity 3D. 

## Project Structure

### 1. Azure

Azure directory further has three sub-directories - 

**1. ARM-Template**
   
**2. Azure Digital Twin API**
   
**3. Device-Simulator**

### 2. DTDL Ontology

### 3. Unity 3D

### 4. IoT - Cardboard - js

### 5. 3D Models

## Pre-requisites
1. Visual Studio Code
2. Unity 3D
3. Active Azure Subscription

## Download and Installation

1. Download the Master Project from GitHub

   Master Project Link - https://github.com/hemantjuyal/DigitalTwin.git
   
2. The extraction of the zip file shall take about 10 minutes.
3. Obtain the path to DeviceSimulator.sln
4. Navigate to the path above within the terminal.
5. Open Unity 3D
6. Run the scene in Unity 3D
7. Now, use the following command in the terminal to start the simulation -

   ```powershell
   dotnet run

9. You can see real-time data changes in Unity 3D.
10. An alert can be sent using the space bar. 
