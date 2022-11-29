using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject rayOrigin;
    public GameObject destinationPrefab;
    public GameObject initialPrefab;
    public LayerMask attachableLayers;
    
    public void FireShooter()
    {
        RaycastHit hit;
        
        if (!Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hit, attachableLayers))
        {
            return;
        }

        ReleaseDestination();
        destinationLocked = true;
        destinationCoordinates = hit.point;
        destinationObject = Instantiate(destinationPrefab, destinationCoordinates, Quaternion.identity);
        
        
        ReleaseInitial();
        initialLocked = true;
        initialCoordinates = transform.position;
        initialObject = Instantiate(initialPrefab, initialCoordinates, Quaternion.identity);
    }

    public void ReleaseShooter()
    {
        ReleaseDestination();
        ReleaseInitial();
    }
    
    private Vector3 destinationCoordinates;
    private GameObject destinationObject;
    private bool destinationLocked = false;

    private void ReleaseDestination()
    {
        if (!destinationLocked)
        {
            return;
        }
        Destroy(destinationObject);
        destinationLocked = false;
    }
    
    private Vector3 initialCoordinates;
    private GameObject initialObject;
    private bool initialLocked = false;
    
    private void ReleaseInitial()
    {
        if (!initialLocked)
        {
            return;
        }
        Destroy(initialObject);
        initialLocked = false;
    }
    
}
