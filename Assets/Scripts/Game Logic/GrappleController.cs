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
    public float slowdownScale = 1.0f;
    
    [Header("Motion References")]
    public ContinuousMoveProviderBase moveProvider;
    public ContinuousTurnProviderBase rightTurnProvider;
    public ContinuousTurnProviderBase leftTurnProvider;
    
    private Rigidbody _rigidBody;
    
    private bool _playerLocked = false;
    private bool _bothShootersLocked = false;
    private bool _wasPlayerLocked = false;
    
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        UpdateLocks();
        UpdateGrappleMotion();
        
        _wasPlayerLocked = _playerLocked;
    }

    private void UpdateLocks()
    {
        _playerLocked = rightShooter.shooterState == Shooter.ShooterState.Locked || leftShooter.shooterState == Shooter.ShooterState.Locked;
        _bothShootersLocked = rightShooter.shooterState == Shooter.ShooterState.Locked &&
                              leftShooter.shooterState == Shooter.ShooterState.Locked;

        if (_bothShootersLocked && Shooter.IsValueStill(rightShooter.JoystickValue.y) && !Shooter.IsValueStill(leftShooter.JoystickValue.y))
        {
            rightShooter.UnlockShooter();
            rightShooter.ActivateShooter();
        }

        if (_bothShootersLocked && !Shooter.IsValueStill(rightShooter.JoystickValue.y) && Shooter.IsValueStill(leftShooter.JoystickValue.y))
        {
            leftShooter.UnlockShooter();
            leftShooter.ActivateShooter();
        }
        
        //Only disable turning if right is locked
        rightTurnProvider.enabled = rightShooter.shooterState != Shooter.ShooterState.Locked;
        leftTurnProvider.enabled = leftShooter.shooterState != Shooter.ShooterState.Locked && _playerLocked;

        moveProvider.enabled = !_playerLocked;

        _rigidBody.useGravity = !_playerLocked;
    }

    private Vector3 _currentGrappleForce;
    private void UpdateGrappleMotion()
    {
        if (!_playerLocked)
        {
            return;
        }

        if (_bothShootersLocked)
        {
            _rigidBody.velocity = Vector3.zero;
            return;
        }

        Vector3 grappleDirection;
        float joystickInput;
        
        if (rightShooter.shooterState == Shooter.ShooterState.Locked)
        {
            grappleDirection  = rightShooter.DestinationMarker.transform.position - rightShooter.rayOrigin.transform.position;
            joystickInput = rightShooter.JoystickValue.y;
        }
        else
        {
           grappleDirection = (leftShooter.DestinationMarker.transform.position - leftShooter.rayOrigin.transform.position).normalized;
           joystickInput = leftShooter.JoystickValue.y;
        }
        
        Vector3 grappleVelocity = grappleDirection.normalized * joystickInput * grappleSpeed;
        _rigidBody.velocity = grappleVelocity;
        _currentGrappleForce = grappleVelocity;
    }

}
