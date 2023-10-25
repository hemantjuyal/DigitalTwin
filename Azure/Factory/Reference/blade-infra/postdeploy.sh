iothubname=$1
adtname=$2
rgname=$3
location=$4
egname=$5
egid=$6
funcappid=$7
storagename=$8
containername=$9



echo "iot hub name: ${iothubname}"
echo "adt name: ${adtname}"
echo "rg name: ${rgname}"
echo "location: ${location}"
echo "egname: ${egname}"
echo "egid: ${egid}"
echo "funcappid: ${funcappid}"
echo "storagename: ${storagename}"
echo "containername: ${containername}"


# echo 'installing azure cli extension'
az config set extension.use_dynamic_install=yes_without_prompt
az extension add --name azure-iot -y

# echo 'retrieve files'
git clone https://github.com/garimasrivastavaa/blade-infra.git

# echo 'input model'
Numberoffloors=$(az dt model create -n $adtname --models ./blade-infra/models/Building.json --query [].id -o tsv)
NumberofRobotPalletizers=$(az dt model create -n $adtname --models ./blade-infra/models/FactoryFloor.json --query [].id -o tsv)
RoboticPalletizerID=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticPalletizer.json --query [].id -o tsv)
RoboticArmID=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticArm.json --query [].id -o tsv)
ConveyorBeltSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/ConveyorBelt.json --query [].id -o tsv)
LightCurtainResolution=$(az dt model create -n $adtname --models ./blade-infra/models/LightCurtainSensor.json --query [].id -o tsv)
PalletTurnTableRotationSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/PalletTurnTable.json --query [].id -o tsv)
DoorLastAccessedTime=$(az dt model create -n $adtname --models ./blade-infra/models/Door.json --query [].id -o tsv)
PalletStretchMachineWrappingSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/PalletStretchMachine.json --query [].id -o tsv)

# echo 'instantiate ADT Instances'
#1
    echo "Create Building BuildingA"
    az dt twin create -n $adtname --dtmi $Numberoffloors --twin-id "BuildingA"
    az dt twin update -n $adtname --twin-id "BuildingA" --json-patch '[{"op":"add", "path":"/Numberoffloors", "value": "'"BuildingA"'"}]'
#2
for i in {01..02}
do
    echo "Create FactoryFloor FF$i"
    az dt twin create -n $adtname --dtmi $NumberofRobotPalletizers --twin-id "FF$i"
    az dt twin update -n $adtname --twin-id "FF$i" --json-patch '[{"op":"add", "path":"/NumberofRobotPalletizers", "value": "'"FF$i"'"}]'
done
#3
for i in {01..10}
do
    echo "Create RoboticPalletizer RP0$i"
    az dt twin create -n $adtname --dtmi $RoboticPalletizerID --twin-id "RP0$i"
    az dt twin update -n $adtname --twin-id "RP0$i" --json-patch '[{"op":"add", "path":"/RoboticPalletizerID", "value": "'"RP0$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
#4p1
for i in {01..10}
do
    echo "Create RoboticArm RA0$i"
    az dt twin create -n $adtname --dtmi $RoboticArmID --twin-id "RA0$i"
    az dt twin update -n $adtname --twin-id "RA0$i" --json-patch '[{"op":"add", "path":"/RoboticArmID", "value": "'"RA0$i"'"}]'
done
#5p2
for i in {01..10}
do
    echo "Create ConveyorBelt CB0$i"
    az dt twin create -n $adtname --dtmi $ConveyorBeltSpeed --twin-id "CB0$i"
    az dt twin update -n $adtname --twin-id "CB0$i" --json-patch '[{"op":"add", "path":"/ConveyorBeltSpeed", "value": "'"CB0$i"'"}]'
done
#6p3
for i in {01..10}
do
    echo "Create LightCurtainSensor LC0$i"
    az dt twin create -n $adtname --dtmi $LightCurtainResolution --twin-id "LC0$i"
    az dt twin update -n $adtname --twin-id "LC0$i" --json-patch '[{"op":"add", "path":"/LightCurtainResolution", "value": "'"LC0$i"'"}]'
done
#7p4
for i in {01..10}
do
    echo "Create PalletTurnTable PT0$i"
    az dt twin create -n $adtname --dtmi $PalletTurnTableRotationSpeed --twin-id "PT0$i"
    az dt twin update -n $adtname --twin-id "PT0$i" --json-patch '[{"op":"add", "path":"/PalletTurnTableRotationSpeed", "value": "'"PT0$i"'"}]'
done
#8p5
for i in {01..10}
do
    echo "Create Door D0$i"
    az dt twin create -n $adtname --dtmi $DoorLastAccessedTime --twin-id "D0$i"
    az dt twin update -n $adtname --twin-id "D0$i" --json-patch '[{"op":"add", "path":"/DoorLastAccessedTime", "value": "'"D0$i"'"}]'
done
#9p6
for i in {01..10}
do
    echo "Create PalletStretchMachine PS0$i"
    az dt twin create -n $adtname --dtmi $PalletStretchMachineWrappingSpeed --twin-id "PS0$i"
    az dt twin update -n $adtname --twin-id "PS0$i" --json-patch '[{"op":"add", "path":"/PalletStretchMachineWrappingSpeed", "value": "'"PS0$i"'"}]'
done


# az eventgrid topic create -g $rgname --name $egname -l $location
az dt endpoint create eventgrid --dt-name $adtname --eventgrid-resource-group $rgname --eventgrid-topic $egname --endpoint-name "$egname-ep"
az dt route create --dt-name $adtname --endpoint-name "$egname-ep" --route-name "$egname-rt"

# Create Subscriptions
az eventgrid event-subscription create --name "$egname-broadcast-sub" --source-resource-id $egid --endpoint "$funcappid/functions/broadcast" --endpoint-type azurefunction

# Retrieve and Upload models to blob storage
az storage blob upload-batch --account-name $storagename -d $containername -s "./blade-infra/assets"