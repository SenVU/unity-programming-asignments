using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float steerAngle;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveVec = new Vector3(0, 0, Input.GetAxis("Vertical") * speed);
        float targetRotation = Input.GetAxis("Horizontal") * steerAngle;
        Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
        
        moveVec = rotation * moveVec;

        rb.AddForce(moveVec);
        transform.rotation = rotation;
    }
}   
