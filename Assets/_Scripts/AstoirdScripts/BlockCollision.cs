using UnityEngine;

public class BlockCollision : MonoBehaviour 
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip fall;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Room"))
            audioSource.PlayOneShot(fall);
    }
}
