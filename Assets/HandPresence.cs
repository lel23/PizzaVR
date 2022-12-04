using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresence : MonoBehaviour
{
    public Transform target;
    private Rigidbody myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 distance = (target.position - transform.position);
        
        myRigidBody.velocity = distance / Time.fixedDeltaTime;
        
        // Quaternion rotDiff = target.rotation * Quaternion.Inverse(transform.rotation);
        // rotDiff.ToAngleAxis(out float angleDeg, out Vector3 rotAxis);
        // myRigidBody.angularVelocity = ((angleDeg * rotAxis) * Mathf.Deg2Rad) / Time.fixedDeltaTime;
        transform.rotation = target.transform.rotation;
    }

    public void FixHands()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
