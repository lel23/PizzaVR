using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopGrabController : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask grabbableMask;
    public float grabMaxDistance;
    
    private DesktopGrabInteractable heldItem;
    private Transform heldItemOldTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttemptGrab();
        }
    }
    
    public void AttemptGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, grabMaxDistance, grabbableMask))
        {
            SetHeldItem(hit.collider.gameObject);
        }
    }

    private void SetHeldItem(GameObject newItem)
    {
        if (heldItem != null)
        {
            
        }
    }
}
