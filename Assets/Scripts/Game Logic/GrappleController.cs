using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    [Header("Shooters")]
    public Shooter rightShooter;
    public Shooter leftShooter;

    [Header("Visualization")] 
    public GameObject destinationMarkPrefab;
    public GameObject originMarkPrefab;

    private GameObject destinationObjectLeft;
    private GameObject destinationObjectRight;

    private GameObject originObjectLeft;
    private GameObject originObjectRight;
}
