using UnityEngine;
using System.Collections;

public class AstroidHealth : MonoBehaviour 
{
	private int hits;
    private AudioSource source;

	void Awake() 
	{
		hits = 0;
        source = GetComponent<AudioSource>();
	}

	public void HurtMe()
	{
		hits ++;
        source.Play();
	}

	void Update () 
	{
		if (hits == 3) 
		{
			Destroy (gameObject);
			hits = 0;
		}
	}
}
