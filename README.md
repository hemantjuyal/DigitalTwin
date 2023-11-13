# DigitalTwin

## Project Description

This project is a Digital Twin representation of a Factory. It has the following components -  

1. Building
2. 2 Factory Floors
3. 10 Robotic Palletizers, 5 on each floor

![3D](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/3f20bdb7-277c-4a38-879e-1bc3e610f5e4)

Each Robotic Palletizer has the following properties - 

1. RoboticPalletizerID : It uniquely identifies each Robotic Palletizer.
   
2. Alert : Raises a warning when alert is sent from the local machine. The alert can be observed by a change in color of the Robotic Palletizer when certain components of the Palletizer display values in an abormal range. 

Each Robotic Palletizer has 6 components having individual properties - 

### 1. Robotic Arm

   ![ra](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a1449f96-1098-44b2-ba77-0f38f565f152)

   a. Robotic Arm ID : A unique identifier assigned to each robotic arm for identification.

   b. Robotic Arm Status : Indicates the current operational state of the robotic arm, whether it is active or idle.
   
   c. Robotic Arm Power Consumption : The amount of electrical power consumed by the robotic arm during its operation.
   
   d. Robotic Arm Operating Speed : The speed at which the robotic arm performs its tasks, determining the velocity of its movements.
   
   e. Robotic Arm Load Capacity : The current weight or load that the robotic arm is carrying.

### 2. Conveyor Belt
   
   ![cb](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2856a45c-2896-4758-b7fe-897a7cd88ac2)

   a. Conveyor Belt Speed : The rate at which the conveyor belt moves, determining the speed of material or objects being transported.

### 3. Light Curtain Sensor
   
   ![lcr](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/d537fe79-ab74-4e5a-bec7-08c6d38d4de7)

   a. Beam Resolution : The level of detail or granularity in the light curtain sensor's detection, influencing its precision.
   
   b. Detection Range : The maximum distance over which the light curtain sensor can detect objects or interruptions in the beam.

### 4. Pallet Turn Table
   
   ![palletrot](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a81f60da-a74c-4460-b6b9-645e466e2843)

   a. Pallet TurnTable Rotation Speed : The speed at which the pallet turn table rotates.

### 5. Door

   ![door](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/8da5a92b-2a12-4961-b7f1-7e802e740b0f)

   a. Door - Last Accessed Time : The timestamp indicating the most recent time the door was accessed or opened. 
   
   b. Door Status : The current state of the door, such as "Open" or "Closed".

### 6. Pallet Stretch Machine

   ![psss](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/fee58603-016d-4547-ba3b-5256e2c6ca7f)
   
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

   ![image](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/441d5f69-7cb6-451d-a4bf-20c72b80c297)

   ![image](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/1545016f-b07b-4a1f-8c91-10974aa51e46)


4. Import Azure Digital Twin Data Update API.postman_collection.json file from the following path -

   ```powershell

   DigitalTwin\Azure\Factory\Azure Digital Twin API
   
**3. Device-Simulator**

Device-Simulator Usage Guide - 

https://github.com/hemantjuyal/DigitalTwin/blob/main/Azure/Factory/Device-SImulator/README.md#device-simulator-usage-guide

### 2. DTDL Ontology

![DTDL](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/31850e74-bc1d-4b00-85c3-5333e460b2c5)

1. This directory contains 9 .JSON files that are written in Digital Twins Definition Language (DTDL). These files are used to create Digital Twins of the Building, Factory Floor, Robotic Palletizers and its components in the Azure Digital Twins Explorer. 

2. Data.xlsx is a file that is compatible with Azure Digital Twins Explorer upload format.

   ![comp](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/754005e2-9c5c-44ab-bb75-fa7e3f7cf5b5)

   By uploading this data, we will be able to see a graph of relationships between all the components.

   ![graph](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/24773f38-768a-47fc-aae3-5f315082ed1d)

   Each component will also receive fixed values from the data sheet.

   ![imgdata](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/c718f703-58e7-4c2b-8cd1-ea602c9593c9)

3. Properties.xlsx is a reference file that defines the "Need Attention", "Normal", and "Abnormal" ranges for properties of the Factory components. 

   ![PROP](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/1cfac555-463a-479d-8bd8-bbf63092ed46)

### 3. Unity 3D

### 4. IoT - Cardboard - js

IoT - Cardboard - js Guide - 

https://github.com/hemantjuyal/DigitalTwin/tree/main/IoT-Cardboard-js/FactoryFloorMaster/factoryfloor#factory-floor-application

### 5. 3D Models

## Download and Installation

1. Download the Master Project from GitHub

   Master Project Link - https://github.com/hemantjuyal/DigitalTwin.git

2. Follow **all mentioned steps** of this README file from the Sign in to Azure using CLI step - 
   
   Link - https://github.com/hemantjuyal/DigitalTwin/blob/main/Azure/Factory/ARM-Template/README.md#sign-in-to-azure-using-azure-cli

3. Obtain the path to DeviceSimulator.sln

   ```powershell
   DigitalTwin\Azure\Factory\Device-SImulator\DeviceSimulator
   
4. Navigate to the path above within the terminal.

5. Open Unity 3D

   ![unity](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/0c4577fa-bbc9-4e73-9371-97611ae2f25f)

6. Run the scene in Unity 3D

   ![run](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/a204ed11-2fe0-48d5-be35-f8ea499bb2b1)

7. Now, use the following command in the terminal to start the simulation -

   ```powershell
   dotnet run

8. You can see real-time data changes in Unity 3D.

Before - 

![bef](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/6d023f27-6231-4d38-82bc-ceafeba00932)

After-

![aft](https://github.com/garimasrivastavaa/read-me-trials/assets/94553271/4be353f5-1953-430a-bb34-d7f0493717da)

8. An alert can be sent using the space bar. 
