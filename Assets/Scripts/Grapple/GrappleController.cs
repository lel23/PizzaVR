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

    private float _currentGrappleSpeed;

    [Header("Player Controller")]
    public PlayerController playerController;

    private bool _grappleHoldsLock = false;

    public float minGrappleSize = 0.2f;

    private void Start()
    {
        _currentGrappleSpeed = grappleSpeed;
    }
    private void Update()
    {
        if (!_grappleHoldsLock && (rightShooter.shooterState == Shooter.ShooterState.Locked || leftShooter.shooterState == Shooter.ShooterState.Locked))
        {
           _grappleHoldsLock = PlayerLocks.Instance.LockPlayer();
        }

        if (rightShooter.shooterState != Shooter.ShooterState.Locked && leftShooter.shooterState != Shooter.ShooterState.Locked)
        {
            UnspeedGrapple();
            if (_grappleHoldsLock)
            {
                PlayerLocks.Instance.UnlockPlayer();
                _grappleHoldsLock = false;    
            }

            return;
        }

        Vector3 grappleForceRight = Vector3.zero;
        Vector3 grappleForceLeft = Vector3.zero;

        if (rightShooter.shooterState == Shooter.ShooterState.Locked && 
            (Vector3.Distance(rightShooter.DestinationMarker.transform.position, rightShooter.transform.position) > minGrappleSize) || rightShooter.JoystickValue.y < 0)
        {
            var grappleDirection = (rightShooter.DestinationMarker.transform.position - rightShooter.rayOrigin.transform.position).normalized;
            grappleForceRight = grappleDirection * rightShooter.JoystickValue.y * _currentGrappleSpeed;
        }
        if (leftShooter.shooterState == Shooter.ShooterState.Locked && 
            (Vector3.Distance(leftShooter.DestinationMarker.transform.position, leftShooter.transform.position) > minGrappleSize) || leftShooter.JoystickValue.y < 0)
        {
            var grappleDirection = (leftShooter.DestinationMarker.transform.position - leftShooter.rayOrigin.transform.position).normalized;
            grappleForceLeft = grappleDirection * leftShooter.JoystickValue.y * _currentGrappleSpeed;
        }
        
        playerController.lockedVelocity += grappleForceLeft + grappleForceRight;
    }

    public void SpeedGrapple()
    {
        _currentGrappleSpeed = 2 * grappleSpeed;
    }

    public void UnspeedGrapple()
    {
        _currentGrappleSpeed = grappleSpeed;
    }

}
