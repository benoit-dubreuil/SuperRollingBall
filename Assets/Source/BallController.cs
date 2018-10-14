using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float torque = 15f;

    new private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.angularDrag = 0;
        rigidbody.maxAngularVelocity = 100;
    }

    private void FixedUpdate()
    {
        float xAxis = -Input.GetAxis("Horizontal");
        float zAxis = -Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, zAxis).normalized;
        direction.Normalize();

        Vector3 torqueAxis = Vector3.Cross(direction, Vector3.up);
        torqueAxis.Normalize();

        rigidbody.AddTorque(torqueAxis * torque * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
