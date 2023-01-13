
## spaceship control script

```
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 50.0f;
    public float verticalInput;
    public float horizontalInput;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input from player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the spaceship forward
        rb.AddRelativeForce(Vector3.forward * speed * verticalInput);

        // rotate the spaceship left and right
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}

```

This script uses the UnityEngine's "Transform" component to control the movement of the homing missile. The "target" variable should be assigned to the spaceship object in the inspector. The "Quaternion.LookRotation" method is used to calculate the direction to the target and the "Quaternion.RotateTowards" method is used to rotate the missile towards the target. The "Vector3.MoveTowards" method is used to move the missile towards the target.



## homing missile 

```
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target; // assign the target spaceship object in the inspector
    public float speed = 10.0f;
    public float rotateSpeed = 200.0f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // calculate the direction to the target
            Vector3 direction = (target.position - transform.position).normalized;

            // rotate towards the target
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);

            // move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
```


This script uses the UnityEngine's "Transform" component to control the movement of the homing missile. The "target" variable should be assigned to the spaceship object in the inspector. The "Quaternion.LookRotation" method is used to calculate the direction to the target and the "Quaternion.RotateTowards" method is used to rotate the missile towards the target. The "Vector3.MoveTowards" method is used to move the missile towards the target.