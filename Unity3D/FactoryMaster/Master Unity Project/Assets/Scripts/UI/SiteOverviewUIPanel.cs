// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// UI Panel which lists all the Robotic Palletizers in the scene.
/// </summary>
public class SiteOverviewUIPanel : MonoBehaviour
{
    public RoboticPalletizerSiteData siteData;
    public SiteOverviewRoboticPalletizerButton roboticPalletizerButtonPrefab;
    public RectTransform contentTransform;
    public RoboticPalletizerUIPanel hoverPanel;
    
    [SerializeField]
    private ProgressController powerOutputBar;
    
    private Dictionary<RoboticPalletizerScriptableObject, SiteOverviewRoboticPalletizerButton> roboticPalletizerButtons;

    private void Start()
    {
        ClearContent();
        PopulateUIMenu();
        OnHoverRoboticPalletizerEnd();
        UpdateTotalPowerOutput();
    }

    private void PopulateUIMenu()
    {
        roboticPalletizerButtons = new Dictionary<RoboticPalletizerScriptableObject, SiteOverviewRoboticPalletizerButton>();
        foreach (var roboticPalletizerData in siteData.roboticPalletizerData)
        {
            Debug.Log("RoboticPalletizerID "+roboticPalletizerData.roboticPalletizerData.RoboticPalletizerID+
            "    "+"RoboticArmPowerConsumption "+roboticPalletizerData.roboticPalletizerData.RoboticArmPowerConsumption);
            var button = Instantiate(roboticPalletizerButtonPrefab, contentTransform);
            button.siteOverviewPanel = this;
            button.RoboticPalletizerData = roboticPalletizerData;
            roboticPalletizerData.onDataUpdated += UpdateTotalPowerOutput;
            roboticPalletizerButtons.Add(roboticPalletizerData, button);
            
        }
    }

    private void UpdateTotalPowerOutput()
    {
        var averagePower = siteData.roboticPalletizerData.Select(roboticPalletizerData => roboticPalletizerData.roboticPalletizerData.RoboticArmPowerConsumption).Average();
        powerOutputBar.CurrentValue = averagePower;
    }

    public void OnHoverRoboticPalletizerButton(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        if (hoverPanel)
        {
            Debug.Log("Button is Hovered");
            hoverPanel.gameObject.SetActive(true);
            hoverPanel.SetRoboticPalletizerData(roboticPalletizerData);
        }
    }

    public void OnHoverRoboticPalletizerEnd()
    {
        if (hoverPanel)
        {
            hoverPanel.gameObject.SetActive(false);
        }
    }

    private void ClearContent()
    {
        var buttons = GetComponentsInChildren<SiteOverviewRoboticPalletizerButton>();
        foreach (var button in buttons)
        {
            if (Application.isPlaying)
            {
                Destroy(button.gameObject);
            }
            else
            {
                //Make this safe to call outside of playmode
                DestroyImmediate(button.gameObject);
            }
        }
    }
}