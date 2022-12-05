using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbulb : MonoBehaviour
{
    
    private Transform t;
    private Rigidbody rb;
    private BoxCollider bc;
    public float floatDuration = .5f;
    void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        // if the lightbulb collides with the street light (i.e. the player hits their target)
        if (collision.collider.CompareTag("StreetLight"))
        {
            Debug.Log("collided with streetlight");
        }
    }

    IEnumerator floatTowards(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }
    IEnumerator rotateTowards(Quaternion targetRotation, float duration)
    {
        float time = 0;
        Quaternion startRotation = transform.rotation;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
