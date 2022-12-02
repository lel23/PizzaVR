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
    [HideInInspector] public bool isLocked = false;

    protected bool _objectHasLock = false;
    
    public virtual void TryClimb()
    {
        Collider[] colliders = Physics.OverlapBox(myCollider.transform.position, myCollider.size/2.0f, myCollider.transform.rotation, climbableLayerMask);
        if (colliders.Length == 0)
        {
            return;
        }

        _overlapObject = colliders[0].gameObject;
        isLocked = true;
    }

    public virtual void ReleaseClimb()
    {
        if (!isLocked)
        {
            return;
        }
        isLocked = false;
    }
}
