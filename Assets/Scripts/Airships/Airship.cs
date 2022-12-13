using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship : MonoBehaviour
{
    public float time;
    private float _timer;
    
    public float speed;
    
    public Vector3 direction;
    public Vector3 flipDirection;

    private Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = direction.normalized;
        myRigidbody = GetComponent<Rigidbody>();
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= time)
        {
            _timer = 0;
            transform.Rotate(flipDirection * 180);
            direction *= -1;
        }

        myRigidbody.position += direction * speed * Time.deltaTime;
    }
}
