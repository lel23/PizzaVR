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
    public Vector3 playerCameraPosition;
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
    }

    void Update()
    {
        playerCameraPosition = player.transform.position;
        dir = Vector3.Normalize(nextPizzaRecipientPosition - playerCameraPosition);
        transform.rotation = new Quaternion(dir.x, dir.y, dir.z, 1);
    }

    void updatePizzaRecipient()
    {
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
    }
}
