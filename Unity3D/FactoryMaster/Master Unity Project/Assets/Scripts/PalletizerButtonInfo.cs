using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PalletizerButtonInfo : MonoBehaviour
{
    public TextMeshProUGUI roboticPalletizerTextLabel;
    public ProgressController progressController;
    public RoboticPalletizerScriptableObject roboticPalletizerData;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        printText();
    }

    private void printText(){
        roboticPalletizerTextLabel.text = $"Robotic Palletizer {roboticPalletizerData.roboticPalletizerData.RoboticPalletizerID}";
        progressController.CurrentValue = roboticPalletizerData.roboticPalletizerData.RoboticArmPowerConsumption;
    }
}
