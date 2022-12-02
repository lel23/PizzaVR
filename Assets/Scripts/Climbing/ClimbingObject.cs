using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimbingObject : MonoBehaviour
{
    public GameObject myHand;
        
    public BoxCollider myCollider;
    public LayerMask climbableLayerMask;

    public Vector3 DeviceVelocity { get; set; } = Vector3.zero;

    private GameObject _overlapObject;
    public bool isLocked = false;
    
    public void TryClimb()
    {
        Collider[] colliders = Physics.OverlapBox(myCollider.transform.position, myCollider.size/2.0f, myCollider.transform.rotation, climbableLayerMask);
        if (colliders.Length == 0)
        {
            return;
        }

        _overlapObject = colliders[0].gameObject;
        isLocked = true;
        
        myHand.transform.parent = null;
    }

    public void ReleaseClimb()
    {
        isLocked = false;
        
        myHand.transform.parent = transform;
        myHand.transform.localPosition = Vector3.zero;
        myHand.transform.localRotation = Quaternion.identity;
    }
}
