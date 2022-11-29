using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public Shooter rightHandShooter;
    public Shooter leftHandShooter;

    private void Update()
    {
        print("Right: " + rightHandShooter.JoystickValue);
        print("Left: " + leftHandShooter.JoystickValue);
    }
}
