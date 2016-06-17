using UnityEngine;
using System.Collections;

public class AstroidCollision : MonoBehaviour 
{
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Astroid")) 
		{
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("Rain")) 
		{
			Destroy (other.gameObject);
		}
	}
}
