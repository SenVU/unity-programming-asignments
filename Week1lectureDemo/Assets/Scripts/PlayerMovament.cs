using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovament : MonoBehaviour
{
    public float rotationSpeed = 500f;
    public float movementSpeed = 1f;
    Transform transform;
    Rigidbody rigidbody;
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed;
        rotation = rotation * Time.deltaTime;
        transform.Rotate(new Vector3(0, rotation, 0));

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        movement = transform.rotation * movement * movementSpeed;

        rigidbody.AddForce(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "enemy")
        {
            Debug.Log("you have been vented");
        }

    }
}
