using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SceneLoader))]
public class PlayerControler : MonoBehaviour
{
    [SerializeField] AudioSource driftSound;
    [SerializeField] AudioSource engineSound;

    [SerializeField] bool isWSControl = false;

    [SerializeField] float speed = 20;
    [SerializeField] float steerAngle = 30;

    float targetRotation = 0;
    float RotationAngle = 0;

    Rigidbody rb;

    Vector3 startPos;

    void Start()
    {
        Debug.Assert(driftSound != null, "Player DriftSound is not set");
        Debug.Assert(engineSound != null, "Player EngineSound is not set");

        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
    }

    void Update()
    {
        HandleMovament();
        HandleSounds();
    }

    void HandleMovament()
    {
        // if WSContol is enabled then use the verticle Axis multiplied bt speed, otherwise just use a constant speed
        Vector3 moveVector = isWSControl ? 
                new Vector3(0, 0, Input.GetAxisRaw("Vertical") * speed) : 
                new Vector3(0, 0, speed);
        
        targetRotation = Input.GetAxisRaw("Horizontal") * steerAngle;
        RotationAngle = Mathf.Lerp(RotationAngle, targetRotation, .1f);
        Quaternion rotation = Quaternion.Euler(0, RotationAngle, 0);

        moveVector = rotation * moveVector;

        rb.AddForce((moveVector*Time.deltaTime)*100);
        transform.rotation = rotation;
    }

    void HandleSounds()
    {
        float rotationDifferance = targetRotation - RotationAngle;

        if (/*!driftSound.isPlaying && */
           Input.GetAxisRaw("Horizontal") !=0 &&
            (rotationDifferance < -steerAngle*1.5f || rotationDifferance > steerAngle*1.5f))
        {
            
            driftSound.Play();
        }

        if(!engineSound.isPlaying)
        {
            engineSound.Play();
        }
        engineSound.pitch = rb.velocity.magnitude/9;
    }

    void OnCollisionEnter(Collision collision)
    {
        // loads th "CrashMenu" scene if player collides with "Obstacle" tagged object
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<SceneLoader>().LoadScene("CrashMenu");
        }
    }
}
 
