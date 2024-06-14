using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Start is called for "+name);
    }

    // Update is called once per frame
    void Update()
    {
		//Destroy(gameObject);
		Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") *speed , 0, Input.GetAxis("Vertical") * speed);
		transform.position = transform.position + moveVector;
    }
}
