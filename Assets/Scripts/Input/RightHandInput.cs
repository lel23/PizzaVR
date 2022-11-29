using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RightHandInput : HandInput
{
    void Awake()
    {
        InputDeviceCharacteristics desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        Initialize(desiredCharacteristics);
    }
}
