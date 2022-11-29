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

    [Header("Motion")]
    public ContinuousMoveProviderBase moveProvider;
    public ContinuousTurnProviderBase turnProvider;

    private bool _playerLocked = false;

    private void Update()
    {
        _playerLocked = rightShooter.shooterState == Shooter.ShooterState.Locked || leftShooter.shooterState == Shooter.ShooterState.Locked;
        
        //Only disable turning if right is locked
        if (rightShooter.shooterState == Shooter.ShooterState.Locked)
        {
            turnProvider.enabled = false;
        }
        
        if (_playerLocked)
        {
            moveProvider.enabled = false;
        }
        
        if (!_playerLocked)
        {
            moveProvider.enabled = true;
            turnProvider.enabled = true;
        }
    }
}
