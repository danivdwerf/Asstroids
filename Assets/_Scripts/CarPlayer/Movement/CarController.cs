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
    [SerializeField]private GameObject prefab;
    [SerializeField]private List<WheelMesh> wheelMeshes;
    private float wheelRotationY;
    private float wheelRotationZ;
    private int index;
    private bool drive;
    public bool Drive{get{return drive;} set{drive = value;}}

    private Rigidbody rigidBody;
    private HandleInput inputH;
    private GameObject skidLeft;
    private GameObject skidRigh;
    private Vector3 leftTirePos;
    private Vector3 rightTirePos;

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        inputH = this.GetComponent<HandleInput>();
        drive = true;
    }

    void FixedUpdate()
    {
        //Move car
        rigidBody.MovePosition(this.transform.position + this.transform.forward * inputH.Driving * Time.deltaTime);

        this.wheelRotationY += inputH.Steering * 4; 
        this.wheelRotationY = Mathf.Clamp(this.wheelRotationY, -40, 40);
           
        //Turn the car
        if(inputH.Driving != 0)
            rigidBody.transform.Rotate(0f, inputH.Driving > 0 ? inputH.Steering : inputH.Steering, 0f);

        //Reset wheelrotation when not steering
        if(inputH.Steering == 0 && wheelRotationY != 0)
            wheelRotationY = 0;
         

        foreach(WheelMesh currentWheel in wheelMeshes)
        {
            if (currentWheel.front)
            {
                currentWheel.leftWheel.transform.Rotate(Vector3.left, inputH.Driving*-1);
                currentWheel.rightWheel.transform.Rotate(Vector3.left, inputH.Driving); 
            }
               
            if (currentWheel.back)
            {
                currentWheel.leftWheel.transform.Rotate(Vector3.left, inputH.Driving*-1);
                currentWheel.rightWheel.transform.Rotate(Vector3.left, inputH.Driving); 
                leftTirePos = currentWheel.leftWheel.transform.position;
                rightTirePos = currentWheel.rightWheel.transform.position;
            }
                
            if (inputH.Steering < 1.8f && inputH.Steering > -1.8f)
            {
                skidLeft = null;
                skidRigh = null;
                continue;
            }

            if (skidLeft == null && skidRigh == null && inputH.Driving > 0)
            {
                skidLeft = (GameObject)Instantiate(prefab, leftTirePos, Quaternion.identity); 
                skidRigh = (GameObject)Instantiate(prefab, rightTirePos, Quaternion.identity);

                index = 0;
                for (int i = 0; i < 50; i++)
                {
                    skidLeft.GetComponent<LineRenderer>().SetPosition(i, leftTirePos);
                    skidRigh.GetComponent<LineRenderer>().SetPosition(i, rightTirePos);
                }
                continue;
             }

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
}