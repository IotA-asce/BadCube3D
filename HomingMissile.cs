/*
This script uses the UnityEngine's "Transform" component to control the movement of the 
homing missile. The "target" variable should be assigned to the spaceship object in the 
inspector. The "Quaternion.LookRotation" method is used to calculate the direction to the 
target and the "Quaternion.RotateTowards" method is used to rotate the missile towards the 
target. The "Vector3.MoveTowards" method is used to move the missile towards the target
*/

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