# Factory DTDL Ontology Guide 

The Digital Twins Factory consists of a Building containing 2 Factory Floors comprising of 5 Robotic Palletizers on each floor.

Under Ontology > Factory, you will find the following files - 

![ontologyfiles](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/bfa8e00f-f7b5-4e01-a65c-d2d7565c69dc)

* This directory contains 9 .JSON files that are written in Digital Twins Definition Language (DTDL). These files are used to create Digital Twins of the Building, Factory Floor, Robotic Palletizers and its components in the Azure Digital Twins Explorer.

* Data.xlsx is a file that is compatible with Azure Digital Twins Explorer upload format.

* By uploading all the DTDL files and the Data.xlsx file, we will be able to see a graph of relationships between all the components - 

  ![graph](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/a4e867c3-ddc5-41c7-a703-06ac9335f977)

* Azure Digital Twin explorer will show properties for each component - 

  ![azuredt](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/6ac5c5f0-708a-4f7f-ad42-7934c8563799)

Note - Properties.xlsx is a reference file that can be used to provide properties` values for the respective components. 

  ![propexcel](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/f28a2090-7930-43a9-9303-88055dd80338)

## Using Digital Twins Factory DTDL models

1. Open the Azure Digital Twins Explorer and verify the Azure Twins Explorer Digital Twins URL obtained from the created resource group.

   ![urlpic](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/3220dce6-1c6a-4d3d-9317-ed3453814201)
   
   ![ADT-expsample](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/79d8736a-80c2-40d8-8c65-7ab001e2a480)
   
2. Upload the 9 DTDL files by following the given path -
   
   ``` powershell
   DigitalTwin\Ontology\Factory

  ![jsonupload](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/4ef83498-f074-48eb-879c-45c742906453)

3. After successfully uploading the files, you will receive a message - 
  
  ![uploaded](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/008eaaba-abd1-47ff-a65f-e7404dc7c80a)

4. Upload data.xlsx file using the import graph feature -
  
  ![import](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/bfba049f-75a4-43d6-9110-7a754f03bfca)
  
5. Save the graph preview -
  
  ![preview](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/2f08ccb2-9e39-46e2-abe9-a60848f9b0dd)

6. Import Successful popup will be visible - 

  ![impsuccess](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/37af2abf-9c48-44cb-85ac-bb6785686ba6)

7. Run queries - 

  ![query](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/f9fcddc6-bc34-4050-8e0f-66edada08106)

8. Data will be visible by double clicking on the Digital Twin - 

  ![data](https://github.com/hemantjuyal/DigitalTwin/assets/94553271/e8d09d17-f0cf-463a-ba64-712d82279b1d)
