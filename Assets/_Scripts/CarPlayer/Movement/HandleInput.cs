using UnityEngine;
using System.Collections;

public class HandleInput : MonoBehaviour 
{
    private float motor;
    public float Motor{get{return motor;} set{motor = value;}}
    private float reverse;
    public float Reverse{set{reverse = value;}}
    private float steering;
    public float Steering{get{return steering;} set{steering = value;}}
    private float driving;
    public float Driving{get{return driving;}}

    private float right;
    private float left;
    private float maxTorque=10f;
    private float maxSteeringAngle = 2f;

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
