// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using UnityEngine;

public class RoboticPalletizerEventListener : MonoBehaviour
{
    [SerializeField]
    private RoboticPalletizerGameEvent gameEvent;

    [SerializeField]
    public RoboticPalletizerUnityEvent response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventRaised(RoboticPalletizerScriptableObject roboticPalletizerData)
    {
        response.Invoke(roboticPalletizerData);
    }
}