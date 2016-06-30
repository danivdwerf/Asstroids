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

        rigidBody.MovePosition(transform.position + transform.forward * HandleInput.inputH.driving * Time.deltaTime);

        wheelRotationY += HandleInput.inputH.steering * 4; 
        wheelRotationY = Mathf.Clamp(wheelRotationY, -40, 40);
           
        if(HandleInput.inputH.driving!=0)
        {
            rigidBody.transform.Rotate(0f, HandleInput.inputH.driving > 0 ? HandleInput.inputH.steering : -HandleInput.inputH.steering, 0f);
        }
        if(HandleInput.inputH.steering==0&&wheelRotationY>0)
        {
            wheelRotationY-=3;
        }
        if(HandleInput.inputH.steering==0&&wheelRotationY<0)
        {
            wheelRotationY+=3;
        }

        foreach(WheelMesh theMesh in wheelMeshes)
        {
            if (theMesh.front)
            {
                theMesh.leftWheel.transform.Rotate(Vector3.left, HandleInput.inputH.motor);
                theMesh.rightWheel.transform.Rotate(Vector3.left, HandleInput.inputH.motor); 
                theMesh.leftWheel.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, wheelRotationY, wheelRotationZ);
                theMesh.rightWheel.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180+wheelRotationY, wheelRotationZ);
            }

            if (theMesh.back)
            {
                theMesh.leftWheel.transform.Rotate(Vector3.left, HandleInput.inputH.motor);
                theMesh.rightWheel.transform.Rotate(Vector3.left, HandleInput.inputH.motor); 
                leftTirePos = theMesh.leftWheel.transform.position;
                rightTirePos = theMesh.rightWheel.transform.position;
                
                if (HandleInput.inputH.steering >1.8|| HandleInput.inputH.steering<-1.8)
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