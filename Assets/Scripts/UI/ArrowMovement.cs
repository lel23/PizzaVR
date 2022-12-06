using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Camera playerCamera;
    public Vector3 playerCameraPosition;
    public Vector3 nextPizzaRecipientPosition;
    public Vector3 targetMinusOriginNormalized;
    void Start()
    {
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
        playerCameraPosition = playerCamera.transform.position;
    }

    void Update()
    {
        playerCameraPosition = playerCamera.transform.position;
        targetMinusOriginNormalized = Vector3.Normalize(nextPizzaRecipientPosition - playerCameraPosition);
        transform.rotation = new Quaternion(targetMinusOriginNormalized.x, targetMinusOriginNormalized.y, targetMinusOriginNormalized.z, 1);
    }

    void updatePizzaRecipient()
    {
        nextPizzaRecipientPosition = Singleton.Instance.GameManager.getNextPizzaRecipientPosition();
    }
}
