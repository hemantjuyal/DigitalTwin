using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public GameObject textPrefab;
    public TextMeshProUGUI textPrefabText;
    public RoboticPalletizerScriptableObject roboticPalletizer;
    // Start is called before the first frame update
    void Start()
    {
        textPrefabText = textPrefab.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textPrefabText.text=$"Robotic Palletizer ID: {roboticPalletizer.roboticPalletizerData.RoboticPalletizerID} and the Power Consumption: {roboticPalletizer.roboticPalletizerData.RoboticArmPowerConsumption}";
    }
}
