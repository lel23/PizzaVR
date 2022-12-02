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
    }
    
    public void OnPlayerUnlocked()
    {
        myRigidBody.useGravity = true;
        moveProvider.enabled = true;
    }

    public void OnLeftHandLock()
    {
        leftTurnProvider.enabled = false;
    }

    public void OnLeftHandUnlock()
    {
        if (PlayerLocks.Instance.IsRightHandLocked)
        {
            leftTurnProvider.enabled = true;
        }
        else
        {
            leftTurnProvider.enabled = false;
        }
    }

    public void OnRightHandLock()
    {
        rightTurnProvider.enabled = false;
        if (!PlayerLocks.Instance.IsLeftHandLocked)
        {
            leftTurnProvider.enabled = true;
        }
    }

    public void OnRightHandUnlock()
    {
        rightTurnProvider.enabled = true;
        leftTurnProvider.enabled = false;
    }    

    #endregion

}
