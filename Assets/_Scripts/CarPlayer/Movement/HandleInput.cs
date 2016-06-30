using UnityEngine;
using System.Collections;

public class HandleInput : MonoBehaviour 
{
    public static HandleInput inputH;
    public float motor;
    public float reverse;
    public float steering;
    public float driving;

    private float right;
    private float left;
    private float maxTorque=10f;
    private float maxSteeringAngle = 2f;
	
    void Awake () 
    {
        inputH = this;
	}

	void FixedUpdate () 
    {
        right = Mathf.Clamp(Input.GetAxis("RightTrigger"), 0, 1);
        motor = maxTorque * right;
        left = Mathf.Clamp(Input.GetAxis("LeftTrigger"), 0, 1);
        reverse = maxTorque * left;

        driving = motor - (reverse / 2.92f);
        steering = maxSteeringAngle * Input.GetAxis("LeftJoystickHorizontal");
	}
}
