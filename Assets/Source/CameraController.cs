using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private static readonly float DEFAULT_MAX_VELOCITY_FOR_MAX_TURNING_SPEED = 10f;
    private static readonly float DEFAULT_MAX_TURNING_SPEED = 2f;

    private Vector3 offset;
    private float offsetMagnitude;
    public GameObject ball;
    private Transform ballTransform;
    private Rigidbody ballPhys;

    private void Awake()
    {
        ballTransform = ball.GetComponent<Transform>();
        ballPhys = ball.GetComponent<Rigidbody>();
    }

    private void Start () {
        offset = transform.position - ballTransform.position;
        offsetMagnitude = offset.magnitude;
	}
	
	private void Update () {
        // Assures that the distance between the camera and the ball is constant
        if (transform.position.Equals(ballTransform.position))
            transform.position += ballPhys.velocity;

        transform.position = ballTransform.position + ((transform.position - ballTransform.position).normalized * offsetMagnitude);
        transform.LookAt(ballTransform);
    }
}
