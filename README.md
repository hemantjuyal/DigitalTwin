# DigitalTwin

## Project Description

This project is a Digital Twin representation of a Factory. It has the following components -  

1. Building
2. 2 Factory Floors
3. 10 Robotic Palletizers, 5 on each floor

![3D](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/8d88740e-35be-448c-8845-5fd560860e7c)

Each Robotic Palletizer has the following properties - 

1. RoboticPalletizerID : It uniquely identifies each Robotic Palletizer.
   
2. Alert : Raises a warning when alert is sent from the local machine. The alert can be observed by a change in color of the Robotic Palletizer when certain components of the Palletizer display values in an abormal range. 

Each Robotic Palletizer has 6 components having individual properties - 

### 1. Robotic Arm

   ![ra](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/e83b6f26-41c0-46b3-979d-07a60ec322a2)

   a. Robotic Arm ID : A unique identifier assigned to each robotic arm for identification.

   b. Robotic Arm Status : Indicates the current operational state of the robotic arm, whether it is active or idle.
   
   c. Robotic Arm Power Consumption : The amount of electrical power consumed by the robotic arm during its operation, measured in watts.
   
   d. Robotic Arm Operating Speed : The speed at which the robotic arm performs its tasks, determining the velocity of its movements.
   
   e. Robotic Arm Load Capacity : The maximum weight or load that the robotic arm is designed to carry or manipulate without exceeding its specified limits.

### 2. Conveyor Belt
   
   ![cb](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/84e7f8c4-73cf-4cbf-a9a4-4ce70d82a111)

   a. Conveyor Belt Speed : The rate at which the conveyor belt moves, determining the speed of material or objects being transported.

### 3. Light Curtain Sensor
   
   ![lcr](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/00768d2a-eeea-4edc-b160-09a1e1a8c2af)

   a. Beam Resolution : The level of detail or granularity in the light curtain sensor's detection, influencing its precision.
   
   b. Detection Range : The maximum distance over which the light curtain sensor can detect objects or interruptions in the beam.

### 4. Pallet Turn Table
   
   ![palletrot](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/a9b932e1-2b26-4677-a60b-299e7e5066f2)

   a. Pallet TurnTable Rotation Speed : The speed at which the pallet turn table rotates, influencing the efficiency of pallet handling.

### 5. Door

   ![door](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/7626185c-db9c-4c9e-88fb-4b3c8c74c4e6)

   a. Door - Last Accessed Time : The timestamp indicating the most recent time the door was accessed or opened. 
   
   b. Door Status : The current state of the door, such as "Open" or "Closed".

### 6. Pallet Stretch Machine

   ![pss](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/62760723-a376-40e5-8a12-7e8c14f9abe6)
   
   a. Plastic Wrapping Speed : The speed at which the pallet stretch machine wraps plastic around the pallet.
   
   b. Pallet Stretch Machine Film Roll Status : Indicates whether the film roll used for wrapping is available or needs replacement.
   
   c. Pallet Stretch Machine Wrapping Film Usage : The amount of wrapping film consumed by the pallet stretch machine during operations.
   
During a live project demonstration, real-time data changes are reflected on Unity 3D. 

## Project Structure

### 1. Azure

Within the Factory directory under Azure directory, there are further three sub-directories - 

**1. ARM-Template**

ARM-Template Usage Guide - 

https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/ARM-Template#arm-template-usage-guide
   
**2. Azure Digital Twin API**

1. Download and install Postman App to use the Postman API Platform - https://www.postman.com/downloads/

2. Click on import

   ![image](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/57b48010-84c5-4851-b4ba-e9fb55d5c24f)

   ![image](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/43be9c91-43e8-42e5-b2f2-98f219debb7f)

4. Import Azure Digital Twin Data Update API.postman_collection.json file from the following path -

   ```powershell

   DigitalTwin\Azure\Factory\Azure Digital Twin API
   
**3. Device-Simulator**

Device-Simulator Usage Guide - 

https://github.com/hemantjuyal/DigitalTwin/blob/main/Azure/Factory/Device-SImulator/README.md#device-simulator-usage-guide

### 2. DTDL Ontology

![DTDL](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/a80c941e-d465-4db4-af97-e6a80e460ecb)

1. This directory contains 9 .JSON files that are written in Digital Twins Definition Language (DTDL). These files are used to create Digital Twins of the Building, Factory Floor, Robotic Palletizers and its components in the Azure Digital Twins Explorer. 

2. Data.xlsx is a file that is compatible with Azure Digital Twins Explorer upload format.

   ![data](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/373c1bdf-6088-4b0d-8f13-691a7a47b5ad)

   By uploading this data, we will be able to see a graph of relationships between all the components.

   ![rel](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/26cc7698-caa4-4821-b6a5-c88bb23793eb)

   Each component will also receive fixed values from the data sheet.

   ![data](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/fa07c9c6-d6af-48cb-ba56-3aea3965150c)

3. Properties.xlsx is a reference file that defines the "Need Attention", "Normal", and "Abnormal" ranges for properties of the Factory components. 

   ![prop](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/9c7b8708-db69-4b3c-aec4-db8774147fde)

### 3. Unity 3D

### 4. IoT - Cardboard - js

IoT - Cardboard - js Guide - https://github.com/hemantjuyal/DigitalTwin/tree/main/IoT-Cardboard-js/FactoryFloorMaster/factoryfloor#factory-floor-application

### 5. 3D Models

## Download and Installation

1. Download the Master Project from GitHub

   Master Project Link - https://github.com/hemantjuyal/DigitalTwin.git

2. Obtain the path to DeviceSimulator.sln
3. Navigate to the path above within the terminal.
4. Open Unity 3D
5. Run the scene in Unity 3D
6. Now, use the following command in the terminal to start the simulation -

   ```powershell
   dotnet run

7. You can see real-time data changes in Unity 3D.
8. An alert can be sent using the space bar. 
