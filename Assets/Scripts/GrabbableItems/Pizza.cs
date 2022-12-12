using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
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
        // if the pizza recipient collides with the pizza box (i.e. the player hits their target)
        if (collision.collider.CompareTag("PizzaRecipient") && Singleton.Instance.GameManager.isValidRecipient(collision.collider.gameObject))
        {
            Debug.Log("collided with pizza guy");
            // make the pizza box float front of the recipient (so it looks like they're holding it)
            rb.useGravity = false;
            bc.enabled = false;
            Vector3 recipientPosition = collision.collider.gameObject.transform.position;
            Vector3 targetPosition = new Vector3(recipientPosition.x, recipientPosition.y, recipientPosition.z - 2);
            StartCoroutine(floatTowards(targetPosition, floatDuration));
            Quaternion targetRotation = new Quaternion(0, 0, 0, 1);
            StartCoroutine(rotateTowards(targetRotation, floatDuration));
            rb.constraints = RigidbodyConstraints.FreezePosition;
            // change the color of the recipient
            collision.collider.GetComponent<PizzaRecipient>().changeColor();

            // update game manager
            Singleton.Instance.GameManager.getPizza(collision.collider.gameObject);

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
