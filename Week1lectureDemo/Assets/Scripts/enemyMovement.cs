using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    Transform transform;
    Rigidbody rigidbody;

    public Transform followBody;
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = (followBody.position - transform.position).normalized;

        //transform.rotation = Quaternion.FromToRotation(Vector3.right, new Vector3(movement.x, 0, movement.z));
        transform.rotation = Quaternion.LookRotation(movement);
        movement = movement * movementSpeed;

        rigidbody.AddForce(movement);
    }
}
