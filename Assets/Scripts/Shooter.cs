using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject rayOrigin;
    public GameObject destinationPrefab;

    public void FireShooter()
    {
        RaycastHit hit;
        
        if (!Physics.Raycast(rayOrigin.transform.position, -rayOrigin.transform.forward, out hit))
        {
            return;
        }

        Instantiate(destinationPrefab, hit.point, Quaternion.identity);
    }
}
