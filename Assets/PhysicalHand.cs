using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalHand : MonoBehaviour
{
    public Transform controllerTransform;

    private Rigidbody myRigidBody;
    
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = (controllerTransform.position - transform.position) / Time.fixedDeltaTime;
        Quaternion rotationDifference = controllerTransform.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float degrees, out Vector3 axis);
        myRigidBody.angularVelocity = (degrees * axis * Mathf.Deg2Rad) / Time.fixedDeltaTime;
    }
}
