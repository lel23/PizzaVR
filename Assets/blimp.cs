using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blimp : MonoBehaviour
{
    public float distance = 30.0f;
    public float speed = 3.0f;
    private Vector3 _start;
    private float currentVel;
    private void Start()
    {
        _start = transform.position;
        currentVel = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(currentVel * Time.deltaTime, 0 ,0);
        if (transform.position.x > _start.x + distance || transform.position.x < _start.x)
        {
            currentVel *= -1;
        }
    }
}
