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
    private Transform playerCameraTransform;
    public Vector3 nextPizzaRecipientPosition;
    public Vector3 dir;
    void Start()
    {
        if (Singleton.Instance.GameManager.isVR)
        {
            player = VRPlayer;
        }
        else
        {
            player = desktopPlayer;
        }
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
        playerCameraTransform = player.transform;
    }

    void Update()
    {
        dir = Vector3.Normalize(nextPizzaRecipientPosition - player.transform.position);
        transform.LookAt(transform.TransformDirection(dir));
    }

    void updatePizzaRecipient()
    {
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
    }
}
