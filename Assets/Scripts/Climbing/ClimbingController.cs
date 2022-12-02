using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    public ClimbingObject leftController;
    public ClimbingObject rightController;

    public Rigidbody myRigidbody;

    private void Update()
    {
        if (!leftController.isLocked && !rightController.isLocked)
        {
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
        //print(velocity);
        myRigidbody.AddForce(-velocity);
    }
}