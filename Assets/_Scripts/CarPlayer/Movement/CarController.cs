using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WheelMesh
{
    public GameObject leftWheel;
    public GameObject rightWheel;
    public bool front;
    public bool back;
}

public class CarController : MonoBehaviour 
{
    public List<WheelMesh> wheelMeshes;
    private Rigidbody rigidBody;

    private float maxTorque=10f;
    private float maxSteeringAngle = 2f;

	public float motor;
    public float reverse;
    public float steering;
	public float driving;

	private float right;
	private float left;

    private float wheelRotationY;
    private float wheelRotationZ = 0;

    private GameObject skidLeft;
    private GameObject skidRigh;
    [SerializeField] private GameObject prefab;
    private Vector3 leftTirePos;
    private Vector3 rightTirePos;
    private int index;

    public bool drive;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        drive = true;
    }

    void FixedUpdate()
    {
    	right = Mathf.Clamp(Input.GetAxis("RightTrigger"), 0, 1);
        motor = maxTorque * right;
        left = Mathf.Clamp(Input.GetAxis("LeftTrigger"), 0, 1);
        reverse = maxTorque * left;

        driving = motor - (reverse / 2.92f);
        rigidBody.MovePosition(transform.position + transform.forward * driving * Time.deltaTime);

        steering = maxSteeringAngle * Input.GetAxis("LeftJoystickHorizontal");
        wheelRotationY += steering * 4;
        wheelRotationY = Mathf.Clamp(wheelRotationY, -40, 40);
           
		if(driving!=0)
        {
            rigidBody.transform.Rotate(0f, driving > 0 ? steering : -steering, 0f);
        }
        if(steering==0&&wheelRotationY>0)
        {
            wheelRotationY-=3;
        }
        if(steering==0&&wheelRotationY<0)
        {
            wheelRotationY+=3;
        }

        foreach(WheelMesh theMesh in wheelMeshes)
        {
            if (theMesh.front)
            {
                theMesh.leftWheel.transform.Rotate(Vector3.left, motor);
                theMesh.rightWheel.transform.Rotate(Vector3.left, motor); 
                theMesh.leftWheel.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, wheelRotationY, wheelRotationZ);
                theMesh.rightWheel.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180+wheelRotationY, wheelRotationZ);
            }

            if (theMesh.back)
            {
                theMesh.leftWheel.transform.Rotate(Vector3.left, motor);
                theMesh.rightWheel.transform.Rotate(Vector3.left, motor); 
                leftTirePos = theMesh.leftWheel.transform.position;
                rightTirePos = theMesh.rightWheel.transform.position;
                
                if (steering >1.8|| steering<-1.8)
                {
                    if (skidLeft == null && skidRigh == null)
                    {
                        skidLeft = (GameObject)Instantiate(prefab, leftTirePos, Quaternion.identity); 
                        skidRigh = (GameObject)Instantiate(prefab, rightTirePos, Quaternion.identity);

                        index = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            skidLeft.GetComponent<LineRenderer>().SetPosition(i, leftTirePos);
                            skidRigh.GetComponent<LineRenderer>().SetPosition(i, rightTirePos);
                        }
                    }
                    else
                    {
                        index++;
                        for (int i = index; i < 50; i++)
                        {
                            skidLeft.GetComponent<LineRenderer>().SetPosition(i, leftTirePos);
                            skidRigh.GetComponent<LineRenderer>().SetPosition(i, rightTirePos);
                        }

                        if (index == 49)
                        {
                            skidLeft = (GameObject)Instantiate(prefab, leftTirePos, Quaternion.identity); 
                            skidRigh = (GameObject)Instantiate(prefab, rightTirePos, Quaternion.identity);

                            index = 0;
                            for (int i = 0; i < 50; i++)
                            {
                                skidLeft.GetComponent<LineRenderer>().SetPosition(i, leftTirePos);
                                skidRigh.GetComponent<LineRenderer>().SetPosition(i, rightTirePos);
                            }     
                        }
                    }
                }
                else
                {
                    skidLeft = null;
                    skidRigh = null;
                }
            }
        }
    }
}