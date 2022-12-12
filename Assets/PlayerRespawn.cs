using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float minY = -1;
    private Vector3 _startPos;

    public Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            transform.position = _startPos;
            myRigidBody.velocity = Vector3.zero;
        }
    }
}
