using UnityEngine;
using System.Collections;

public class BlockFall:MonoBehaviour 
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip fall;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}

	void Update () 
    {
	   
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Room"))
        {
            audioSource.PlayOneShot(fall);
        }
    }
}
