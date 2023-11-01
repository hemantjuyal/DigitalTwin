// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using BladeMR.Events;
using System;
using UnityEngine;

namespace BladeMR.ADT
{
    /// <summary>
    /// Gets and sets the Alert property of the Robotic Palletizer on the Azure Digital Twins (ADT) service.
    /// </summary>
    [Serializable]
    public class ADTRoboticPalletizerAlertController : MonoBehaviour
    {
        /// <summary>
        /// Communicates with the Azure Digital Twins service using its Rest API.
        /// </summary>
        private ADTRestClient adtClient;

        #region Inspector Parameters

        [SerializeField]
        private ADTRestAPICredentialsScriptableObject adtConnectionInfo;

        /// <summary>
        /// The Scriptable Object containing the data of the Robotic Palletizer on which the operations will be performed.
        /// </summary>
        [Header("RoboticPalletizer")]
        [SerializeField]
        private RoboticPalletizerScriptableObject RoboticPalletizer;

        [SerializeField]
        private AudioSource alertAudioSource;

        /// <summary>
        /// The ID of the Robotic Palletizer on which the operations will be performed.
        /// </summary>
        private string RoboticPalletizerID => RoboticPalletizer.roboticPalletizerData.RoboticPalletizerID;

        #endregion Inspector Parameters

        #region Events
        /// <summary>
        /// Event used to signal that information has been retrieved from ADT though the Rest API.
        /// </summary>
        [Header("Events")]
        [SerializeField]
        private RoboticPalletizerGameEvent OnADTReceived;

        [SerializeField]
        private ADTAuthenticationGameEvent OnADTAuthenticated;

        [SerializeField]
        private ADTAuthenticationGameEvent OnADTOnADTAuthenticationFailed;
        #endregion Events

        #region Unity Callbacks

        private void Start()
        {
            // Initialize the ADT Rest Client with the service principal credentials
            adtClient = new ADTRestClient(adtConnectionInfo.adtInstanceUrl, adtConnectionInfo.clientId, adtConnectionInfo.clientSecret, adtConnectionInfo.tenantId)
            {
                OnADTReceivedTwinData = OnADTReceived,
                OnADTRestAuthenticate = OnADTAuthenticated,
                OnADTRestAuthenticationFailed = OnADTOnADTAuthenticationFailed
            };
            Debug.Log("REST API Connection is Esablished");
            if(alertAudioSource == null)
            {
                alertAudioSource = GetComponent<AudioSource>();
            }
        }

        public void PlayAlertAudio(RoboticPalletizerScriptableObject roboticPalletizer)
        {
            if(roboticPalletizer.roboticPalletizerMetaData.Alert)
            {
                alertAudioSource.PlayOneShot(alertAudioSource.clip);
            }
        }

        /// <summary>
        /// Sets the Alert property of the Robotic Palletizer's digital twin to true
        /// </summary>
        public async void SetAlert() => await adtClient.SetAlertOnTwin(RoboticPalletizerID);

        /// <summary>
        /// Sets the Alert property of the Robotic Palletizer's digital twin to false
        /// </summary>
        public async void ClearAlert() => await adtClient.ClearAlertOnTwin(RoboticPalletizerID);

        /// <summary>
        /// Retrieves the Robotic Palletizer's digital twin data from ADT through the Rest API.
        /// </summary>
        public async void GetData() => await adtClient.GetRoboticPalletizerTwinData(RoboticPalletizerID);

        #endregion Unity Callbacks
    }
}