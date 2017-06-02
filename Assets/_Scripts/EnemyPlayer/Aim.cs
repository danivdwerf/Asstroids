using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour 
{
	void Awake()
	{
		Cursor.visible = false;
	}

    void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 10;
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}