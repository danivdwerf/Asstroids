using UnityEngine;
using System.Collections;

public class WinSound : MonoBehaviour 
{
    private AudioSource source;
    [SerializeField] private AudioClip cheering;
    [SerializeField] private AudioClip clicking;

	void Start () 
    {
        source=GetComponent<AudioSource>(); 
        source.Stop();
	}

    public void Cheering()
    {
        source.PlayOneShot(cheering);
    }

    public void Click()
    {
        source.PlayOneShot(clicking);
    }

    public void StopSound()
    {
        source.Stop();
    }
}
