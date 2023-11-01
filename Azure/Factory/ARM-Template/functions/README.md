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

![Building BladeFunctionApps.csproj](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/4caa3c2b-98c1-41b8-8a5f-81d3302ad255)

## Accessing the recently generated the DLL File

1. The output folders bin and obj will generate in the same directory as BladeFunctionsApps.sln -

![bin&obj folder](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2c91339e-f29f-41bb-aa15-f3c4ec3bc73b)

2. Within the bin folder, the path to the recently generated BladeFunctionsApps.dll and BladeFunctionsApps.sln files is -
   
   ```powershell
   DigitalTwin\Azure\Factory\ARM-Template\functions\bin\Debug\netcoreapp3.1\bin

## Generation of blade-functions.zip file

1. Navigate to the following directory -
   
   ```powershell
   DigitalTwin\Azure\Factory\ARM-Template\functions\bin\Debug\netcoreapp3.1

2. Select all files and generate a zip file named as blade-functions.zip

![blade-functions.zip](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/92f944c8-2ced-4600-9447-8e04816ee5cb)

3. Replace the blade-functions.zip file with the recently generated blade-functions.zip file.
   
   Path for the file to be replaced -
   
   ```powershell
   DigitalTwin\Azure\Factory\ARM-Template\functions\zipfiles
