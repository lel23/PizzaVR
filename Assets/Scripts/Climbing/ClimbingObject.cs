using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimbingObject : MonoBehaviour
{
    public BoxCollider myCollider;
    public LayerMask climbableLayerMask;

    private GameObject _overlapObject;

    public void TryClimb()
    {
        Collider[] colliders = Physics.OverlapBox(myCollider.transform.position, myCollider.size/2.0f, myCollider.transform.rotation, climbableLayerMask);
        if (colliders.Length == 0)
        {
            return;
        }

        _overlapObject = colliders[0].gameObject;
    }
}
