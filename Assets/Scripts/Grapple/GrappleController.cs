using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrappleController : MonoBehaviour
{
    [Header("Shooters")]
    public Shooter rightShooter;
    public Shooter leftShooter;

    [Header("Grapple Settings")] 
    public float grappleSpeed = 2.0f;

    [Header("Player Controller")]
    public PlayerController playerController;

    private bool _grappleHoldsLock = false;
    
    private void Update()
    {
        if (!_grappleHoldsLock && (rightShooter.shooterState == Shooter.ShooterState.Locked || leftShooter.shooterState == Shooter.ShooterState.Locked))
        {
           _grappleHoldsLock = PlayerLocks.Instance.LockPlayer();
        }

        if (_grappleHoldsLock && rightShooter.shooterState != Shooter.ShooterState.Locked && leftShooter.shooterState != Shooter.ShooterState.Locked)
        {
            PlayerLocks.Instance.UnlockPlayer();
            _grappleHoldsLock = false;
        }

        Vector3 grappleForceRight = Vector3.zero;
        Vector3 grappleForceLeft = Vector3.zero;

        if (rightShooter.shooterState == Shooter.ShooterState.Locked)
        {
            var grappleDirection = (rightShooter.DestinationMarker.transform.position - rightShooter.rayOrigin.transform.position).normalized;
            grappleForceRight = grappleDirection * rightShooter.JoystickValue.y * grappleSpeed;
        }
        if (leftShooter.shooterState == Shooter.ShooterState.Locked)
        {
            var grappleDirection = (leftShooter.DestinationMarker.transform.position - leftShooter.rayOrigin.transform.position).normalized;
            grappleForceLeft = grappleDirection * leftShooter.JoystickValue.y * grappleSpeed;
        }
        
        playerController.lockedVelocity += grappleForceLeft + grappleForceRight;
    }

}
