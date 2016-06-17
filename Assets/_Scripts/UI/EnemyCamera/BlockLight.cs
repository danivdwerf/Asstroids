using UnityEngine;
using System.Collections;

public class BlockLight : MonoBehaviour
{

    public Light blockLight;
    private DropObjects drop;

    void Awake()
    {
        blockLight = GetComponent<Light>();
        drop = GameObject.FindObjectOfType<DropObjects>();
    }

    void Update()
    {
        {
            if (Input.GetKey(KeyCode.Alpha1)) 
            {
                blockLight.intensity = 1;
            }
            else
            {
                blockLight.intensity = 0;
            }

            if (drop.astroidSpawn == false)
            {
                GetComponent<Light>().color = Color.red;
            }
            else
            {
                GetComponent<Light>().color = Color.cyan;
            }
        }
    }

}
