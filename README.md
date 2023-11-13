# DigitalTwin

## Project Description

This project is a Digital Twin representation of a Factory. It has the following components -  

1. Building
2. 2 Factory Floors
3. 10 Robotic Palletizers, 5 on each floor

![3D](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/3f20bdb7-277c-4a38-879e-1bc3e610f5e4)

Each Robotic Palletizer has 6 components. Each component has their own individual properties.

Let's refer to these components and their individual properties - 

### 1. Robotic Arm

   ![ra](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a1449f96-1098-44b2-ba77-0f38f565f152)

   It has the following properties - 

   a. Robotic Arm ID : A unique identifier assigned to each robotic arm for identification.

   b. Robotic Arm Status : Indicates the current operational state of the robotic arm, whether it is active or idle.
   
   c. Robotic Arm Power Consumption : The amount of electrical power consumed by the robotic arm during its operation.
   
   d. Robotic Arm Operating Speed : The speed at which the robotic arm performs its tasks, determining the velocity of its movements.
   
   e. Robotic Arm Load Capacity : The current weight or load that the robotic arm is carrying.

### 2. Conveyor Belt
   
   ![cb](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2856a45c-2896-4758-b7fe-897a7cd88ac2)

   It has the following properties - 
   
   a. Conveyor Belt Speed : The rate at which the conveyor belt moves, determining the speed of material or objects being transported.

### 3. Light Curtain Sensor
   
   ![lcr](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/d537fe79-ab74-4e5a-bec7-08c6d38d4de7)

   It has the following properties - 
   
   a. Beam Resolution : The level of detail or granularity in the light curtain sensor's detection, influencing its precision.
   
   b. Detection Range : The maximum distance over which the light curtain sensor can detect objects or interruptions in the beam.

### 4. Pallet Turn Table
   
   ![palletrot](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a81f60da-a74c-4460-b6b9-645e466e2843)

   It has the following properties - 
   
   a. Pallet TurnTable Rotation Speed : The speed at which the pallet turn table rotates.

### 5. Door

   ![door](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/8da5a92b-2a12-4961-b7f1-7e802e740b0f)

   It has the following properties - 
   
   a. Door - Last Accessed Time : The timestamp indicating the most recent time the door was accessed or opened. 
   
   b. Door Status : The current state of the door, such as "Open" or "Closed".

### 6. Pallet Stretch Machine

   ![psss](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/fee58603-016d-4547-ba3b-5256e2c6ca7f)

   It has the following properties - 
   
   a. Plastic Wrapping Speed : The speed at which the pallet stretch machine wraps plastic around the pallet.
   
   b. Pallet Stretch Machine Film Roll Status : Indicates whether the film roll used for wrapping is available or needs replacement.
   
   c. Pallet Stretch Machine Wrapping Film Usage : The amount of wrapping film consumed by the pallet stretch machine during operations.
   
During a live project demonstration, real-time data changes are reflected on Unity 3D. 

## Project Structure

Under the **Azure > Factory folder**, you will find the following sub-projects - 

## 1. ARM-Template

Refer to the [ARM-Template Usage Guide](https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/ARM-Template#arm-template-usage-guide/ "ARM-Template Usage Guide")
   
## 2. Azure Digital Twin API

Refer to the [Azure Digital Twin API Guide](https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/Azure%20Digital%20Twin%20API#azure-digital-twin-api-guide/ "Azure Digital Twin API Guide")

## 3. Device-Simulator

Refer to the [Device-Simulator Usage Guide](https://github.com/hemantjuyal/DigitalTwin/blob/main/Azure/Factory/Device-SImulator/README.md#device-simulator-usage-guide/ "Device-Simulator Usage Guide")

## 4. Ontology

Refer to the [Ontology Guide](https://github.com/hemantjuyal/DigitalTwin/blob/main/Ontology/Factory/README.md#factory-dtdl-ontology-guide/ "Ontology Guide")

## 5. 3D Scenes Studio

Refer to the [3D Scenes Studio Usage Guide](https://github.com/hemantjuyal/DigitalTwin/tree/main/3DModels/CustomFactory#3d-scenes-studio-usage-guide/ "3D Scenes Studio Usage Guide")

## 6. Unity-3D

Refer to the [Unity-3D Usage Guide](https://github.com/hemantjuyal/DigitalTwin/blob/main/Unity3D/FactoryMaster/Master%20Unity%20Project/README.md#unity-3d-usage-guide/ "Unity-3D Usage Guide")

## 7. IoT - Cardboard - js

Refer to the [IoT - Cardboard - js Guide](https://github.com/hemantjuyal/DigitalTwin/tree/main/IoT-Cardboard-js/FactoryFloorMaster/factoryfloor#factory-floor-application/ "IoT - Cardboard - js Guide")

## 8. 3D Models

Refer to the [3D Models Usage Guide](https://github.com/hemantjuyal/DigitalTwin/tree/main/3DModels/Factory#3d-models-usage-guide/ "3D Models Usage Guide")

## Download and Installation

1. Download the Project from GitHub

   Project Link - [Factory Digital Twin Project](https://github.com/hemantjuyal/DigitalTwin/ "Factory Digital Twin Project")

2. Follow the Installation and deployment instructions as mentioned in the following projects -

   * ARM-Template - 

   * Device Simulator

   * DTDL Ontology

   * 3D Scenes Studio

   * Unity-3D

   * IoT - Cardboard - js

   * 3D Models
   
