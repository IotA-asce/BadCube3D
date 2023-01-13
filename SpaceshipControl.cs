/*
This script uses the UnityEngine's "Rigidbody" component to control 
the movement of the spaceship. The "AddRelativeForce" method is used 
to move the spaceship forward, left, right, up, and down. The "Input.GetKey" 
method is used to detect when the W, S, D, A, L-Shift, L-Ctrl, and space 
keys are pressed. The "Instantiate" method is used to spawn a laser when the 
space key is pressed.
*/


using UnityEngine;




public class SpaceshipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float brakeSpeed = 5.0f;
    public float rotationSpeed = 50.0f;
    public float upwardSpeed = 5.0f;
    public float downwardSpeed = 5.0f;
    public Rigidbody rb;
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // throttle forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * speed);
        }

        // apply brake
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * brakeSpeed);
        }

        // right push
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * rotationSpeed);
        }

        // left push
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * rotationSpeed);
        }

        // up
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddRelativeForce(Vector3.up * upwardSpeed);
        }

        // down
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddRelativeForce(Vector3.down * downwardSpeed);
        }

        // shoot laser
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
        }
    }
}

