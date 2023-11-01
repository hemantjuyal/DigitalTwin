// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using UnityEngine;
using TMPro;

/// <summary>
/// Implements the Alert panel's reaction to the event of receiving ADT data
/// </summary>
public class RoboticPalletizerAlert : MonoBehaviour
{
    /// <summary>
    /// Label showing the description of the alert
    /// </summary>
    public TMP_Text text;

    /// <summary>
    /// Shows the alert panel with the alert message
    /// </summary>
    /// <param name="eventData"></param>
    public void ShowAlertMessageForRoboticPalletizer(ADTRoboticPalletizerEventData eventData)
    {
        Debug.Log(eventData);
        Debug.Log($"Robotic Palletizer: {eventData.roboticPalletizerData.RoboticPalletizerID} has an alert");
        text.text = $"Robotic Palletizer: {eventData.roboticPalletizerData.RoboticPalletizerID} has an alert";

    }
}