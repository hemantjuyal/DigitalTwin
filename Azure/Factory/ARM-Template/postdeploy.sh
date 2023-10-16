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
git clone https://github.com/adamlash/blade-infra.git

# echo 'input model'
RoboticPalletizerID=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticPalletizer.json --query [].id -o tsv)
RoboticArmID=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticArmID.json --query [].id -o tsv)
RoboticArmStatus=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticArmStatus.json --query [].id -o tsv)
RoboticArmPowerConsumption=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticArmPowerConsumption.json --query [].id -o tsv)
RoboticArmOperatingSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticArmOperatingSpeed.json --query [].id -o tsv)
RoboticArmLoadCapacity=$(az dt model create -n $adtname --models ./blade-infra/models/RoboticArmLoadCapacity.json --query [].id -o tsv)
ConveyorBeltSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/ConveyorBeltSpeed.json --query [].id -o tsv)
LightCurtainResolution=$(az dt model create -n $adtname --models ./blade-infra/models/LightCurtainResolution.json --query [].id -o tsv)
LightCurtainRange=$(az dt model create -n $adtname --models ./blade-infra/models/LightCurtainRange.json --query [].id -o tsv)
PalletTurnTableRotationSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/PalletTurnTableRotationSpeed.json --query [].id -o tsv)
DoorLastAccessedTime=$(az dt model create -n $adtname --models ./blade-infra/models/DoorLastAccessedTime.json --query [].id -o tsv)
DoorStatus=$(az dt model create -n $adtname --models ./blade-infra/models/DoorStatus.json --query [].id -o tsv)
PalletStretchMachineWrappingSpeed=$(az dt model create -n $adtname --models ./blade-infra/models/PalletStretchMachineWrappingSpeed.json --query [].id -o tsv)
PalletStretchMachineWrappingFilmRollStatus=$(az dt model create -n $adtname --models ./blade-infra/models/PalletStretchMachineWrappingFilmRollStatus.json --query [].id -o tsv)
PalletStretchMachineWrappingFilmUsage=$(az dt model create -n $adtname --models ./blade-infra/models/PalletStretchMachineWrappingFilmUsage.json --query [].id -o tsv)

# echo 'instantiate ADT Instances'
for i in {1..10}
do
    echo "Create RoboticPalletizer T$i"
    az dt twin create -n $adtname --dtmi $RoboticPalletizerID --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/RoboticPalletizerID", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create RoboticArmID T$i"
    az dt twin create -n $adtname --dtmi $RoboticArmID --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/RoboticArmID", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create RoboticArmStatus T$i"
    az dt twin create -n $adtname --dtmi $RoboticArmStatus --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/RoboticArmStatus", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create RoboticArmPowerConsumption T$i"
    az dt twin create -n $adtname --dtmi $RoboticArmPowerConsumption --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/RoboticArmPowerConsumption", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create RoboticArmOperatingSpeed T$i"
    az dt twin create -n $adtname --dtmi $RoboticArmOperatingSpeed --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/RoboticArmOperatingSpeed", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create RoboticArmLoadCapacity T$i"
    az dt twin create -n $adtname --dtmi $RoboticArmLoadCapacity --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/RoboticArmLoadCapacity", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create ConveyorBeltSpeed T$i"
    az dt twin create -n $adtname --dtmi $ConveyorBeltSpeed --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/ConveyorBeltSpeed", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create LightCurtainResolution T$i"
    az dt twin create -n $adtname --dtmi $LightCurtainResolution --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/LightCurtainResolution", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create LightCurtainRange T$i"
    az dt twin create -n $adtname --dtmi $LightCurtainRange --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/LightCurtainRange", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create PalletTurnTableRotationSpeed T$i"
    az dt twin create -n $adtname --dtmi $PalletTurnTableRotationSpeed --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/PalletTurnTableRotationSpeed", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create DoorLastAccessedTime T$i"
    az dt twin create -n $adtname --dtmi $DoorLastAccessedTime --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/DoorLastAccessedTime", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create DoorStatus T$i"
    az dt twin create -n $adtname --dtmi $DoorStatus --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/DoorStatus", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create PalletStretchMachineWrappingSpeed T$i"
    az dt twin create -n $adtname --dtmi $PalletStretchMachineWrappingSpeed --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/PalletStretchMachineWrappingSpeed", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create PalletStretchMachineWrappingFilmRollStatus T$i"
    az dt twin create -n $adtname --dtmi $PalletStretchMachineWrappingFilmRollStatus --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/PalletStretchMachineWrappingFilmRollStatus", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done
do
    echo "Create PalletStretchMachineWrappingFilmUsage T$i"
    az dt twin create -n $adtname --dtmi $PalletStretchMachineWrappingFilmUsage --twin-id "T$i"
    az dt twin update -n $adtname --twin-id "T$i" --json-patch '[{"op":"add", "path":"/PalletStretchMachineWrappingFilmUsage", "value": "'"T$i"'"},{"op":"add", "path":"/Alert", "value": false}]'
done


# az eventgrid topic create -g $rgname --name $egname -l $location
az dt endpoint create eventgrid --dt-name $adtname --eventgrid-resource-group $rgname --eventgrid-topic $egname --endpoint-name "$egname-ep"
az dt route create --dt-name $adtname --endpoint-name "$egname-ep" --route-name "$egname-rt"

# Create Subscriptions
az eventgrid event-subscription create --name "$egname-broadcast-sub" --source-resource-id $egid --endpoint "$funcappid/functions/broadcast" --endpoint-type azurefunction

# Retrieve and Upload models to blob storage
az storage blob upload-batch --account-name $storagename -d $containername -s "./blade-infra/assets"