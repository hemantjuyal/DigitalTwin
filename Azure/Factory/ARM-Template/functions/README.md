# DLL file Generation using Visual Studio

## Generating the DLL File

1. Open Visual Studio 2022

2. Open the folder containing BladeFunctionsApps.sln
   
![Opening local folder on Visual Studio](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2acf2f31-00a7-4b73-a13e-1beca849b90b)

3. The directory structure shall be similar to this -

![Parent Directory Structure](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/0283ea17-c53d-47fc-a2a3-8488f15123ea)

4. Make the required changes in telemetry.cs file or SignalRFunctions.cs file

5. Open BladeFunctionsApps.csproj
   
6. On the menu bar, select Build > Build Current Document(BladeFunctionsApps.csproj)

![Building BladeFunctionApps.csproj](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/c922fcf0-0127-4acd-80af-e6dea131c7e1)

## Accessing the recently generated the DLL File

1. The output folders bin and obj will generate in the same directory as BladeFunctionsApps.sln -

![bin-obj folders](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/e79b9f55-3e94-44aa-bc4a-05b6a8743496)

2. Within the bin folder, the path to the recently generated BladeFunctionsApps.dll and BladeFunctionsApps.sln files is -
   
   ```powershell
   DigitalTwin\Azure\Factory\ARM-Template\functions\bin\Debug\netcoreapp3.1\bin

## Generation of blade-functions.zip file

1. Navigate to the following directory -
   
   ```powershell
   DigitalTwin\Azure\Factory\ARM-Template\functions\bin\Debug\netcoreapp3.1

2. Select all files and generate a zip file named as blade-functions.zip

![blade-functions.zip](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/92f944c8-2ced-4600-9447-8e04816ee5cb)
