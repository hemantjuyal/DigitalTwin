// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;
using UnityEngine;

public class SiteOverviewRoboticPalletizerButton : MonoBehaviour, IMixedRealityFocusHandler
{
    public SiteOverviewUIPanel siteOverviewPanel;

    [Header("UI Components")]
    [SerializeField]
    private TextMeshProUGUI roboticPalletizerNameLabel;

    [SerializeField]
    private ProgressController progressController;

    [SerializeField]
    private GameObject warningIndicator;

    private RoboticPalletizerScriptableObject roboticPalletizerData;

    public RoboticPalletizerScriptableObject RoboticPalletizerData
    {
        get => roboticPalletizerData;
        set
        {
            roboticPalletizerData = value;
            roboticPalletizerData.onDataUpdated += OnRoboticPalletizerDataChanged;
            OnRoboticPalletizerDataChanged();
        }
    }

    [Header("Events")]
    public RoboticPalletizerGameEvent focusOnRoboticPalletizerEvent;

    public RoboticPalletizerGameEvent onHoverStart;
    public RoboticPalletizerGameEvent onHoverEnd;

    private void OnValidate()
    {
        if (roboticPalletizerData)
        {
            OnRoboticPalletizerDataChanged();
        }
    }

    private void ShowWarningIndicator(bool show)
    {
        Debug.Log("Warning Indicator activated in SiteOverviewRoboticPalletizerButton");
        warningIndicator.gameObject.SetActive(show);
    }

    private void OnRoboticPalletizerDataChanged()
    {
        /*Debug.Log("Button is generated for the Robotic Palletizer ID "
        +roboticPalletizerData.roboticPalletizerData.RoboticPalletizerID+" and the status of alert is "
        +roboticPalletizerData.roboticPalletizerMetaData.Alert);*/
        roboticPalletizerNameLabel.text = 
        $"Robotic Palletizer {roboticPalletizerData.roboticPalletizerData.RoboticPalletizerID}";
        progressController.CurrentValue = roboticPalletizerData.roboticPalletizerData.RoboticArmPowerConsumption;
        ShowWarningIndicator(roboticPalletizerData.roboticPalletizerMetaData.Alert);
    }

    public void OnClicked()
    {
        focusOnRoboticPalletizerEvent.Raise(roboticPalletizerData);
    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        siteOverviewPanel.OnHoverRoboticPalletizerButton(RoboticPalletizerData);
        onHoverStart.Raise(RoboticPalletizerData);
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        siteOverviewPanel.OnHoverRoboticPalletizerEnd();
        onHoverEnd.Raise(RoboticPalletizerData);
    }
}