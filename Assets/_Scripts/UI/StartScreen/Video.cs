using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Video : MonoBehaviour 
{
    [SerializeField] private MovieTexture movie;

	void Start () 
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
        movie.loop = true;
	}
}
