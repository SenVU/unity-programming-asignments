using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerControls : MonoBehaviour
{
	public float speed=1;

    Rigidbody rb;
    Vector3 startPosition;

    void Start()
    {
		rb=GetComponent<Rigidbody>();
		startPosition = transform.position;
        ResetPosition();
    }

    void Update()
    {
		Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//transform.Translate(moveVector * speed);
        rb.AddForce(moveVector*speed);
    }

    void ResetPosition()
    {
        rb.position = startPosition;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            ResetPosition();
        }
    }
}
