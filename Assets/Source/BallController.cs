using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float torque;
    
    private Rigidbody rigidbody;

    public BallController()
    {
        torque = 15f;
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xAxis = -Input.GetAxis("Horizontal");
        float zAxis = -Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, zAxis).normalized;
        direction.Normalize();

        Vector3 torqueAxis = Vector3.Cross(direction, Vector3.up);
        torqueAxis.Normalize();

        rigidbody.AddTorque(torqueAxis * torque, ForceMode.Acceleration);

        Debug.DrawLine(transform.position, transform.position + torqueAxis, Color.magenta, Time.fixedDeltaTime);
    }
}
