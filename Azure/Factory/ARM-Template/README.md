# ARM-Template Usage Guide

The ARM-Template consists of - 

![ARM](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/4ed1d0ee-e656-41ff-8763-1d00008ac2d5)

1. Assets directory - It contains a HASH, a JSON, and, a BUNDLE file that need not be modified.

2. Functions directory contains -

   `SignalRFunction.cs` file - It is used to send data from Azure Digital Twins to Unity 3D.

   `TelemetryFunction.cs` file - It sends data from the local machine (Device Simulator) to the Azure portal (IoT Hub).

   If there is a need to modify the above 2 files to create a custom project, then the following method is to be followed -

   https://github.com/hemantjuyal/DigitalTwin/tree/main/Azure/Factory/ARM-Template/functions#dll-file-generation-using-visual-studio

4. Models directory - It contains the code files written in Digital Twin Definition Language (DTDL) for Azure Digital Twin creation on Azure Digital Twin Explorer. 

5. `azuredeploy.bicep` file creates the following in the Resource Group created on Azure portal -
   
   a. IoT Hub
   
   b. Storage Account
   
   c. Storage Container
   
   d. Azure Digital Twins (ADT) instance
   
   e. SignalR Instance
   
   f. App Plan
   
   g. Function App

   Further `azuredeploy.bicep` file - 
   
   a. Deploys the function code from a zip file - https://github.com/hemantjuyal/DigitalTwinReference/raw/main/blade-functions.zip

   b. Adds RBAC role to Resource Group

   c. Adds "Digital Twins Data Owner" role to ADT instance

   d. Adds "Storage Blob Data Contributor" role to Resource Group

   e. Adds "Digital Twins Data Owner" permissions to the system identity of the Azure Functions

   f. Assigns ADT data role owner permissions to Application

   g. Assigns ADT data role owner permissions to App Registration

   h. Executes the Post Deployment Script - https://raw.githubusercontent.com/hemantjuyal/DigitalTwinReference/main/postdeploy.sh

7. `postdeploy.sh` file uploads DTDL models to blob storage created in step 4.
   
   This file retrieves required files from - https://github.com/hemantjuyal/DigitalTwinReference.git

8. `AppCredentials.txt` file, `ARM_deployment_out.txt` file, and, `Azure_config_settings.txt` file are generated after the deployment process. 

## Sign in to Azure using Azure CLI

1. Locate the `azuredeploy.bicep` script that has been created for you. Typically, this file is in the root of the repository folder.
2. From the Start menu, open **PowerShell**.
3. Change the current path to the location of the `azuredeploy.bicep` script you found in step 1.
   
   ```powershell
   cd <path for azuredeploy.bicep>
   
5. Sign in to Azure by using the az login command. This command opens a browser window and prompts for authentication.

   ```powershell
   az login


![login successful](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/c7663dcd-4883-493c-8e87-31a790e3c740)


![1](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a1081668-7166-4367-9700-4abd0843dc45)


## Set variables in PowerShell

1. Set the $projectname variable. Make sure that your values are enclosed in double quotes.
   
   ```powershell
   $projectname="myproj"
   
2. Set the App Registration name, which can be a maximum of 14 characters. This value is the name of the application registration for your mixed reality app.
   
   ```powershell
   $appreg="myappreg"

## Create the App Registration

Run the following command to create a service principal and configure its access to Azure resources.

```powershell
   az ad sp create-for-rbac --name ${appreg} --role Contributor --scopes/subscriptions/<SUBSCRIPTION-ID> > AppCredentials.txt
```


![2](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/39042935-e328-4795-a75e-392245735c16)


The output from this command is redirected from standard output to `AppCredentials.txt` text file. The command creates the file in the same directory where your run the command.

## Obtain the object ID of the App Registration and the user ID

1. Create and set a variable for the ObjectID in **PowerShell** by using the following command.
   
```
$objectid=$(az ad sp list --display-name ${appreg} --query [0].id --output tsv)
```

2. Validate that the variable contains a GUID by using the echo command. If not, examine your previous steps.
   
```
echo $objectid
```
3. Create and set a variable for the user ID.
   
```
$userid=$(az ad signed-in-user show --query id -o tsv)
```

4. Validate that the variable contains a GUID by using the echo command. If not, examine your previous steps.
   
```
echo $userid
```

![3](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/fa70a1cf-a418-4a4d-bc30-618d717e2853)

## Create the Azure resource group

Create the resource group by using the az group create command in **PowerShell**:

```
az group create --name ${projectname}-rg --location eastus
```

Pay particular attention to the location. It must be **eastus**. This region is one of the valid regions for Microsoft.SignalRService/SignalR and Microsoft.DigitalTwins/digitalTwinsInstances.

## Deploy the ARM template to the newly created resource group

Deploy the supplied bicep file to your resource group and redirect the output to a text file called `ARM_deployment_out.txt`. This process can take 10-15 minutes to complete.

```
az deployment group create --template-file azuredeploy.bicep --resource-group ${projectname}-rg --parameters projectName=${projectname} userId=${userid} appRegObjectId=${objectid} > ARM_deployment_out.txt
```

## Install the Azure CLI extension

Install the azure-iot extension for the Azure CLI in **PowerShell** by using the az extension command in **PowerShell** 

```
az extension add --name azure-iot
```

This command downloads and installs the extension. If it's already installed, the command alerts you.

## Query Azure deployment for key configuration parameters

Query the Azure deployment by using the az deployment group show command in **PowerShell**. This command redirects the output to a file named `Azure_config_settings.txt` in the same directory in which you run the command.

```
az deployment group show --name azuredeploy --resource-group ${projectname}-rg --query properties.outputs.importantInfo.value > Azure_config_settings.txt
```

## Query Azure deployment for resource group connection parameter

1. Use the az iot hub connection-string show command to query the IoT hub for the resource group connection string parameter.
   
```
az iot hub connection-string show --resource-group ${projectname}-rg >> Azure_config_settings.txt
```

2. Confirm the contents of the output text file in **PowerShell**. This command displays several key configuration parameters for later use in this module.
   
```
get-content Azure_config_settings.txt
```

![4](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a1c059f6-2abc-45dd-83a9-0bbada6fdc98)


## Get app credentials

1. Open `DeviceSimulator.sln` in Visual Studio and configure the DeviceSimulator with the host name for the Azure Digital Twins resource type created by the ARM template.
   
2. Open the `Azure_config_settings.txt` text file that you created in the last exercise that contains the key Azure Digital Twins configuration parameters using a text editor. Alternatively, if your PowerShell session remains active, look for the output from your get-content command.
   
3. From the `Azure_config_settings.txt` file or from the output of your get-content command in **PowerShell**, locate the key/value pair for the adtHostName key and copy the value. It should look similar to:
   
```
https://myprojadtxxxxxxxxxx.api.eus.digitaltwins.azure.net
```

![5](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a092a26d-d5fe-4b54-a7b5-4459215e1d23)


4. In your Visual Studio DeviceSimulator solution, open the `AzureIoTHub.cs` file in the editor by double-clicking the file from Solution Explorer. Paste the value for your adtHostName key/pair copied from Step 2 above into the adtInstanceUrl string variable.

## Configure the device simulator with primary connection string

Configure the DeviceSimulator with the primary connection string for the IoT Hub created by the ARM template.

1. From the `Azure_config_settings.txt` file or from the output of your get-content command in **PowerShell**, locate the key/value pair for the connectionString key and copy the value. It should look similar to:
   
```
HostName=myprojHubxxxxxxxxxx.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey= xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx”
```

2. In your Visual Studio DeviceSimulator solution, open the `AzureIoTHub.cs` file in the editor and paste your connectionString value copied in the previous step into the iotHubConnectionString string variable.
   
Snapshot of `AzureIoTHub.cs` file in Visual Studio Code 

![6](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2c7f1d2b-da50-4f5e-b535-7f10fd2868ba)


## Configure the device simulator with authentication keys

1. Configure the DeviceSimulator with the authentication keys created by the ARM template.

2. Open the `AppCredentials.txt` text file that you created in the previous exercise.
   
3. In your Visual Studio DeviceSimulator solution, open the `PropUpdater.cs` file in the editor. Copy and paste the globally unique identifiers (GUIDs) from your text file to the .cs file. Use the following mappings from the .cs variables to the JSON data output in your text file: 

| AppCredentials.txt | PropUpdater.cs |
| ------------- | ------------- |
| `appId`  | `clientId`  |
| `password` | `clientSecret` |
| `tenant` | `tenantId` |

Snapshot of `PropUpdater.cs` file in Visual Studio Code 

![7](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2ae0ffcf-8085-4003-a5e5-2cd239f4dc43)


4. Select File > Save All to save your work in Visual Studio.
