// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Robotic PalletizerUIPanel uses the scriptable object to update relevant UI
/// </summary>
public class RoboticPalletizerUIPanel : MonoBehaviour
{
    /// <summary>
    /// Robotic Palletizer Data
    /// </summary>
    [SerializeField]
    private RoboticPalletizerScriptableObject roboticPalletizerData;

    [SerializeField]
    private bool animateValueTransitions = true;

    [SerializeField]
    private float valueTransitionTime = 2f;

    [SerializeField]
    private RoboticPalletizerLineRendererConnector lineRendererConnector;

    [SerializeField]
    private RoboticPalletizerGameEvent onResetCommandSent;

    [Header("UI Components")]
    public TextMeshProUGUI roboticPalletizerNameLabel;

    public ProgressController progressControllerRoboticArmPowerComsumption;
    public ProgressController progressControllerRoboticArmPowerComsumptionBar;
    public ProgressController progressControllerRoboticArmOperatingSpeed;
    public ProgressController progressControllerConveyerBeltSpeed;
    public ProgressController progressControllerPalletTurnTableRotationSpeed;
    public TextMeshProUGUI dataValueDoorStatus;
    public TextMeshProUGUI dataValueRoboticArmStatus;
    public TextMeshProUGUI descriptionTextPalletStretchMachineWrappingFilmRollStatus;
    public GameObject descriptionPanel;
    public GameObject warningIndicator;

    private IEnumerator currentAnimation;

    /// <summary>
    /// Setup the on data updated callback.
    /// </summary>
    private void OnEnable()
    {
        if (roboticPalletizerData)
        {
            SetRoboticPalletizerData(roboticPalletizerData);
        }

        descriptionPanel.SetActive(false);
    }

    private void OnDisable()
    {
        UnsubscribeFromUpdate();
    }

    /// <summary>
    /// Sets the ScriptableObject containing the info for this panel.
    /// Will refresh all UI values
    /// </summary>
    /// <param name="roboticPalletizerData"></param>
    public void SetRoboticPalletizerData(RoboticPalletizerScriptableObject palletizerData)
    {
        UnsubscribeFromUpdate();
        roboticPalletizerData = palletizerData;
        roboticPalletizerData.onDataUpdated += OnRoboticPalletizerDataUpdated;
        OnRoboticPalletizerDataUpdated();
        if (lineRendererConnector)
        {
            lineRendererConnector.SetTarget(palletizerData);
        }
    }

    public void SendResetCommand()
    {
        onResetCommandSent.Raise(roboticPalletizerData);
    }

    /// <summary>
    /// Enable the Event Description panel and show the specified message
    /// </summary>
    /// <param name="eventDescription"></param>
    public void ShowEventDescription(string PalletStretchMachineWrappingFilmRollStatus)
    {
        descriptionPanel.SetActive(true);
        descriptionTextPalletStretchMachineWrappingFilmRollStatus.text = PalletStretchMachineWrappingFilmRollStatus;
    }

    /// <summary>
    /// Update relevant UI based on new data.
    /// </summary>
    private void OnRoboticPalletizerDataUpdated()
    {
        roboticPalletizerNameLabel.text = roboticPalletizerData.roboticPalletizerData.RoboticPalletizerID;
        dataValueDoorStatus.text = roboticPalletizerData.roboticPalletizerData.DoorStatus.ToString();
        dataValueRoboticArmStatus.text = roboticPalletizerData.roboticPalletizerData.RoboticArmStatus.ToString();
        warningIndicator.SetActive(roboticPalletizerData.roboticPalletizerMetaData.Alert);
        descriptionPanel.SetActive(roboticPalletizerData.roboticPalletizerMetaData.Alert);
        descriptionTextPalletStretchMachineWrappingFilmRollStatus.text = roboticPalletizerData.roboticPalletizerData.PalletStretchMachineWrappingFilmRollStatus.ToString();

        if (animateValueTransitions)
        {
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);
            }
            currentAnimation = AnimatePanelValues();
            StartCoroutine(currentAnimation);
        }
        else
        {
            SetUIValues();
        }
    }

    private IEnumerator AnimatePanelValues()
    {
        var startTime = Time.time;
        var elapsedTime = 0f;

        while (elapsedTime < valueTransitionTime)
        {
            elapsedTime = Time.time - startTime;
            var t = elapsedTime / valueTransitionTime;

            progressControllerRoboticArmPowerComsumption.CurrentValue = Mathf.Lerp(
                (float)progressControllerRoboticArmPowerComsumption.CurrentValue,
                (float)roboticPalletizerData.roboticPalletizerData.RoboticArmPowerComsumption, t);
            progressControllerRoboticArmOperatingSpeed.CurrentValue = Mathf.Lerp(
                (float)progressControllerRoboticArmOperatingSpeed.CurrentValue,
                (float)roboticPalletizerData.roboticPalletizerData.RoboticArmOperatingSpeed, t);
            progressControllerConveyerBeltSpeed.CurrentValue = Mathf.Lerp(
                (float)progressControllerConveyerBeltSpeed.CurrentValue,
                (float)roboticPalletizerData.roboticPalletizerData.ConveyorBeltSpeed, t);
            progressControllerPalletTurnTableRotationSpeed.CurrentValue = Mathf.Lerp(
                (float)progressControllerPalletTurnTableRotationSpeed.CurrentValue,
                (float)roboticPalletizerData.roboticPalletizerData.PalletStretchMachineWrappingSpeed, t);

            yield return null;
        }

        SetUIValues();
    }

    private void SetUIValues()
    {
        progressControllerRoboticArmPowerComsumptionBar.CurrentValue = roboticPalletizerData.roboticPalletizerData.RoboticArmPowerComsumption;
        progressControllerRoboticArmOperatingSpeed.CurrentValue = roboticPalletizerData.roboticPalletizerData.RoboticArmOperatingSpeed;
        progressControllerConveyerBeltSpeed.CurrentValue = roboticPalletizerData.roboticPalletizerData.ConveyorBeltSpeed;
        progressControllerPalletTurnTableRotationSpeed.CurrentValue = roboticPalletizerData.roboticPalletizerData.PalletStretchMachineWrappingSpeed;
    }

    private void UnsubscribeFromUpdate()
    {
        if (roboticPalletizerData != null)
        {
            roboticPalletizerData.onDataUpdated -= OnRoboticPalletizerDataUpdated;
        }
    }
}