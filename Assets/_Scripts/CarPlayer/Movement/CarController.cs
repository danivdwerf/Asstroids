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
    private GameObject skidLeft;
    private GameObject skidRigh;
    private Vector3 leftTirePos;
    private Vector3 rightTirePos;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        drive = true;
    }

    void FixedUpdate()
    {
        //Move car
        rigidBody.MovePosition(this.transform.position + this.transform.forward * HandleInput.inputH.driving * Time.deltaTime);

        this.wheelRotationY += HandleInput.inputH.steering * 4; 
        this.wheelRotationY = Mathf.Clamp(this.wheelRotationY, -40, 40);
           
        //Turn the car
        if(HandleInput.inputH.driving != 0)
            rigidBody.transform.Rotate(0f, HandleInput.inputH.driving > 0 ? HandleInput.inputH.steering : -HandleInput.inputH.steering, 0f);

        //Reset wheelrotation when not steering
        if(HandleInput.inputH.steering == 0 && wheelRotationY != 0)
            wheelRotationY = 0;
         

        foreach(WheelMesh currentWheel in wheelMeshes)
        {
            if (currentWheel.front)
            {
                currentWheel.leftWheel.transform.Rotate(Vector3.left, HandleInput.inputH.driving*-1);
                currentWheel.rightWheel.transform.Rotate(Vector3.left, HandleInput.inputH.driving); 
            }
               
            if (currentWheel.back)
            {
                currentWheel.leftWheel.transform.Rotate(Vector3.left, HandleInput.inputH.driving*-1);
                currentWheel.rightWheel.transform.Rotate(Vector3.left, HandleInput.inputH.driving); 
                leftTirePos = currentWheel.leftWheel.transform.position;
                rightTirePos = currentWheel.rightWheel.transform.position;
            }
                
            if (HandleInput.inputH.steering < 1.8f && HandleInput.inputH.steering > -1.8f)
            {
                skidLeft = null;
                skidRigh = null;
                continue;
            }

            if (skidLeft == null && skidRigh == null && HandleInput.inputH.driving > 0)
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