using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboticPalletizerInitialise : MonoBehaviour
{
    public RoboticPalletizerSiteData siteData;
    public GameObject loadedAsset;
    void Start()
    {
        InstantiateRoboticPalletizer();
    }
     private void InstantiateRoboticPalletizer()
    {

       foreach (var roboticPalletizerData in siteData.roboticPalletizerData)
        {
        siteData.AddRoboticPalletizer(roboticPalletizerData, loadedAsset);
    }
}

}
