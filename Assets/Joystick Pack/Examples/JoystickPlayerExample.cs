using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        float horizontal = floatingJoystick.Horizontal;
        float vertical = floatingJoystick.Vertical;
        Vector3 dir = new Vector3(horizontal * speed, 0, vertical * speed);
        rb.velocity = dir;
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

}