using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DataDisplay : MonoBehaviour
{
public TextMeshProUGUI roboticPalletizerID;
public TextMeshProUGUI powerConsumption;
public TextMeshProUGUI operatingSpeed;
public TextMeshProUGUI loadCapacity;
public TextMeshProUGUI curtainResolution;
public TextMeshProUGUI rollStatus;
public GameObject Alert;
public RoboticPalletizerScriptableObject roboticPalletizer;

    // Update is called once per frame
    void Update()
    {
        roboticPalletizerID.text="Robotic Palletizer ID: "+roboticPalletizer.roboticPalletizerData.RoboticPalletizerID;
        powerConsumption.text="Robotic Arm Power Consumption: "+roboticPalletizer.roboticPalletizerData.RoboticArmPowerConsumption.ToString();
        operatingSpeed.text="Robotic Arm Operating Speed: "+roboticPalletizer.roboticPalletizerData.RoboticArmOperatingSpeed.ToString();
        loadCapacity.text="Robotic Arm Load Capacity: "+roboticPalletizer.roboticPalletizerData.RoboticArmLoadCapacity;
        curtainResolution.text="Light Curtain Resolution: "+roboticPalletizer.roboticPalletizerData.LightCurtainResolution;
        rollStatus.text="Film Roll Status: "+roboticPalletizer.roboticPalletizerData.PalletStretchMachineWrappingFilmRollStatus;
        
        if(roboticPalletizer.roboticPalletizerMetaData.Alert)
        {
            Alert.SetActive(true);
        }

        else
        {
            Alert.SetActive(false);
        }
    }
}
