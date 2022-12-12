using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    [Header("Motion References")]
    public ContinuousMoveProviderBase moveProvider;
    public ContinuousTurnProviderBase rightTurnProvider;
    public ContinuousTurnProviderBase leftTurnProvider;

    [Header("Rigid Body")] public Rigidbody myRigidBody;

    public float jumpForce = 2.0f;
    
    #region Motion Update

    [HideInInspector]
    public Vector3 lockedVelocity = Vector3.zero;
    
    private void Update()
    {
        if (PlayerLocks.Instance.IsPlayerLocked)
        {
            myRigidBody.velocity = lockedVelocity;
        }
        lockedVelocity = Vector3.zero;
    }

    #endregion

    #region Motion Locks

    public void OnPlayerLocked()
    {
        myRigidBody.useGravity = false;
        moveProvider.enabled = false;
        leftTurnProvider.enabled = true;
    }
    
    public void OnPlayerUnlocked()
    {
        myRigidBody.useGravity = true;
        moveProvider.enabled = true;
        leftTurnProvider.enabled = false;
    }

    public void OnLeftHandLock()
    {
        OnPlayerLocked();
    }

    public void OnLeftHandUnlock()
    {
        
    }

    public void OnRightHandLock()
    {
        OnPlayerLocked();
    }

    public void OnRightHandUnlock()
    {
        
    }

    public Transform groundedPoint;
    public float groundedDistance = 0.2f;
    public void OnJump()
    {
        print("Jump");
        if (Physics.Raycast(groundedPoint.position  + new Vector3(0,0.15f,0), Vector3.down, groundedDistance) || Physics.Raycast(groundedPoint.position  + new Vector3(0,0.15f,0), Vector3.up, groundedDistance))
        {
            myRigidBody.velocity += new Vector3(0,jumpForce, 0);
        }
    }

    #endregion

}
