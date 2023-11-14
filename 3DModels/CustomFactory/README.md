#  3D Scenes Studio Usage Guide 
## Create storage resources
Create a new storage account and a container in the storage account. 3D Scenes Studio will use this storage container to store your 3D file and configuration information.

1. Navigate to the https://portal.azure.com/#cloudshell/ in your browser.
   Run the following command to set the CLI context to your subscription for this session.

   ```Azure CLI
      az account set --subscription "<your-Azure-subscription-ID>"
   ```
2. Run the following command to create a storage account in your subscription. The command contains placeholders for you to enter a name and choose a region for your storage account, as well as a placeholder for your resource group.

   ```Azure CLI
      az storage account create --resource-group <your-resource-group> --name <name-for-your-storage-account> --location <region> --sku Standard_RAGRS
   ```
When the command completes successfully, you'll see details of your new storage account in the output. Look for the ID value in the output and copy it to use in the next command.

  <img width="1122" alt="Screenshot 2023-11-15 at 01 01 12" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/7660ffd5-8ed9-42d1-a302-517d540eff8d">

3. Run the following command to grant yourself the Storage Blob Data Owner on the storage account. This level of access will allow you to perform both read and write operations in 3D Scenes Studio. The command contains placeholders for the email associated with your Azure account and the ID of your storage account that you copied in the previous step.

   ```Azure CLI
   az role assignment create --role "Storage Blob Data Owner" --assignee <your-Azure-email> --scope <ID-of-your-storage-account>
   ```
When the command completes successfully, you'll see details of the role assignment in the output.

4. Run the following command to configure CORS for your storage account. This will be necessary for 3D Scenes Studio to access your storage container. The command contains a placeholder for the name of your storage account.

   ```Azure CLI
      az storage cors add --services b --methods GET OPTIONS POST PUT --origins https://explorer.digitaltwins.azure.net --allowed-headers Authorization x-ms-version x-ms-blob-type --account-name <your-storage-account>
   ```
This command doesn't have any output.

5. Run the following command to create a private container in the storage account. Your 3D Scenes Studio files will be stored here. The command contains a placeholder for you to enter a name for your storage container, and a placeholder for the name of your storage account.
 
   ```Azure CLI
      az storage container create --name <name-for-your-container> --public-access off --account-name <your-storage-account>
   ```
When the command completes successfully, the output will show "created": true.

## Adding Factory Floor 3D Scene to the Blob Storagw
Navigate to Microsoft Azure Portal https://portal.azure.com/?quickstart=true#home 

1. Search and Open "Storage Account" Azure Service

2. Click on "Containers" under Data Storage Menu.

   <img width="1440" alt="Screenshot 2023-11-15 at 00 49 57" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/432dd2cc-dc56-4b7f-9b04-afec67a0fdad">

3. Click on Upload.
   
   <img width="583" alt="Screenshot 2023-11-15 at 01 08 35" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/d244693b-7500-4f13-bff6-8563a9ede6b2">

4. Upload the following files

   ```powershell
      /DigitalTwin/3DModels/CustomFactory/3DSceneFactoryFloorMaster.glb
      /DigitalTwin/3DModels/CustomFactory/3DScenesConfiguration.json
   ```

## Initialize your 3D Scenes Studio environment
Now that all the resources are set up, you can use them to create an environment in 3D Scenes Studio.

1. Naviagte to the https://explorer.digitaltwins.azure.net/3dscenes/ The studio will open, connected to the Azure Digital Twins instance that you accessed last in the Azure Digital Twins Explorer. Dismiss the welcome demo.

2. Select the Edit icon next to the instance name to configure the instance and storage container details.

   <img width="1059" alt="Screenshot 2023-11-15 at 01 21 51" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/121e1d8a-9d47-4171-ae5b-231c796e0c86">

   a. For the Azure Digital Twins instance URL, fill the host name of your instance from the Collect host name step into this URL: https://<your-instance-host-name>.

   b. For the Azure Storage account URL, fill the name of your storage account from the Create storage resources step into this URL: https://<your-storage-account>.blob.core.windows.net.

   c. For the Azure Storage container name, enter the name of your storage container from the Create storage resources step.

   d. Select Save.
      <img width="1440" alt="Screenshot 2023-11-15 at 01 25 00" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/0637bca2-d0ee-4913-9fae-a8271a58d4fa">
3. Open the 3D Scene.

   <img width="1440" alt="Screenshot 2023-11-15 at 01 27 37" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/607b97fd-4fed-42f8-9232-38e41ccdb20b">

5. Factory Floor 3D Scene will open in the Build Mode, where elements and behaviours can be added 

   <img width="1440" alt="Screenshot 2023-11-15 at 01 29 01" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/8ec62f8f-e831-4079-8aa9-6146adf9f78d">

7. Toggle the View Mode to see the status of all components and their properties.

   <img width="1440" alt="Screenshot 2023-11-15 at 01 31 10" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/c5871fe3-0120-40eb-b935-15f86d266443">

* Properties.xlsx is a reference file that defines the "Need Attention", "Normal", and "Abnormal" ranges for properties of the Factory components. These ranges determine the visual rules of the proprties of components, where,

  a. "Normal" is represented using **Green** colour.

  b. "Need Attention" is represented using **Orange** colour.

  c. "Abnormal" is represented using **Red** colour.

  ![propexcel](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/f28a2090-7930-43a9-9303-88055dd80338)

6. Select individual Component Twins to check their status and properties.

   <img width="1440" alt="Screenshot 2023-11-15 at 01 41 02" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/6eac9639-bf9f-4298-a09b-86c862207caf">
 
   <img width="1440" alt="Screenshot 2023-11-15 at 01 41 49" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/94727887-d9ee-488d-a398-9cf1f1f96200">
