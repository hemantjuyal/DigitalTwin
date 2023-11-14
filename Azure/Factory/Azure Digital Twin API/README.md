# Azure Digital Twin API Guide

1. Download and install Postman App to use the Postman API Platform - https://www.postman.com/downloads/

2. Click on import

   ![1](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/97258873-d198-4cff-800e-1207851677b8)

   ![2](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/1259ee8b-b7c2-42b6-bafe-8d47b60fa134)

3. Import Azure Digital Twin Data Update API.postman_collection.json file from the following path -

   ```powershell

   DigitalTwin\Azure\Factory\Azure Digital Twin API

4. Login to Azure account by running the following command in the Command Prompt
   ```cmd

   az login

5. Enter the following command to generate an access token
   ```cmd
   az account get-access-token --resource 0b07f429-9f4b-4714-9392-cc5e8e80c8b0

<img width="1440" alt="11" src="https://github.com/hemantjuyal/DigitalTwin/assets/94553271/58965f19-9308-47a1-a91a-6d50377e5d45">

6. Enter the access under the Authorisation tab<img width="1440" alt="Screenshot 2023-11-14 at 23 59 05" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/87b85292-f746-4ab2-87d1-67fe0df1ff6d">

7. Update the variables according to the Azure Credentials

   <img width="1440" alt="Screenshot 2023-11-15 at 00 05 58" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/de8e82cb-ca10-48c6-bfa3-dbebd5e05fd6">

8. Choose anyone of the Collection Item to update properties of any component, Update component ID and their values and click on "Send".
<img width="1440" alt="Screenshot 2023-11-15 at 00 08 48" src="https://github.com/hemantjuyal/DigitalTwin/assets/115024109/aa46de2a-bffa-4b45-a029-28da47eed7a1">

   
