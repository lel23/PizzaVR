using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    public ClimbingObject leftController;
    public ClimbingObject rightController;

    public PlayerController playerController;

    public Transform playerTranform;

    private bool _climbingControllerHoldsLock;
    private void Update()
    {
        if (!_climbingControllerHoldsLock && (rightController.isLocked || leftController.isLocked))
        {
            _climbingControllerHoldsLock = PlayerLocks.Instance.LockPlayer();
        }

        if (!rightController.isLocked && !leftController.isLocked)
        {
            if (_climbingControllerHoldsLock)
            {
                PlayerLocks.Instance.UnlockPlayer();
                _climbingControllerHoldsLock = false;    
            }
            return;
        }
        
        Vector3 velocity = Vector3.zero;
        if (leftController.isLocked)
        {
            velocity += leftController.DeviceVelocity;
        }
        
        if (rightController.isLocked)
        {
            velocity += rightController.DeviceVelocity;
        }

        playerController.lockedVelocity = playerTranform.TransformDirection(-velocity);
    }
}