using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject VRPlayer;
    [SerializeField]
    private GameObject desktopPlayer;
    public Vector3 nextPizzaRecipientPosition;
    public Vector3 dir;


    private GameObject yRotationLoc;

    [SerializeField]
    private GameObject xRotationLocForDesktop;
    private GameObject xRotationLoc;
    private GameObject zRotationLoc;

    public Quaternion currentRotationQuaternion;

    public GameObject crosshair;

    void Start()
    {
        if (Singleton.Instance.GameManager.isVR)
        {
            player = VRPlayer;
        }
        else
        {
            player = desktopPlayer;
            yRotationLoc = desktopPlayer;
            xRotationLoc = xRotationLocForDesktop;
        }
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
    }

    void Update()
    {
        dir = Vector3.Normalize(nextPizzaRecipientPosition - crosshair.transform.position);
        Debug.Log(crosshair.transform.position);
        if (player == desktopPlayer)
        {
            //currentRotationQuaternion = new Quaternion(xRotationLoc.transform.rotation.eulerAngles.x, yRotationLoc.transform.rotation.eulerAngles.y, 0, 1);

            transform.rotation = Quaternion.LookRotation(dir);
        }
        else if (player == VRPlayer)
        {
            currentRotationQuaternion = new Quaternion(xRotationLoc.transform.rotation.eulerAngles.x, yRotationLoc.transform.rotation.eulerAngles.y, zRotationLoc.transform.rotation.eulerAngles.z, 1);
        }
        
        //transform.rotation = Quaternion.LookRotation(dir) * currentRotationQuaternion;
    }

    void updatePizzaRecipient()
    {
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
    }
}
