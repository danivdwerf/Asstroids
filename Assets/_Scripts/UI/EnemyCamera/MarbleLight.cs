using UnityEngine;
using System.Collections;

public class MarbleLight : MonoBehaviour
{

    public Light marbleLight;
    private DropObjects drop;

    void Awake()
    {
        marbleLight = GetComponent<Light>();
        drop = GameObject.FindObjectOfType<DropObjects>();
    }

    void Update()
    {
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                marbleLight.intensity = 1;
            }
            else
            {
                marbleLight.intensity = 0;
            }

            if (drop.spawnRain == false)
            {
                GetComponent<Light>().color = Color.red;
            }
            else
            {
                GetComponent<Light>().color = Color.green;
            }
        }
    }

}
