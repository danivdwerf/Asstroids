using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;

public class DropObjects : MonoBehaviour 
{
    private CrossHair crossHair;

    private AudioSource audioPlay;
    [SerializeField] private AudioClip babyClip;

    [SerializeField] private Transform spawnLocation;
	public List<GameObject> spawnPrefab = new List<GameObject>();

	private GameObject astroid;
	public bool astroidSpawn;
    public float astroidTimer;
    public float timeForAstroid = 4f;

	public bool spawnRain;
    public float rainTimer;
    public float timeForRain = 5f;

	void Start()
	{
		astroidSpawn = true;
        spawnRain = true;
        crossHair = GameObject.FindObjectOfType<CrossHair>();


        audioPlay = GetComponent<AudioSource>();
		
		rainTimer = timeForRain;
        astroidTimer = timeForAstroid;

		if (spawnLocation == null	||spawnPrefab.Count==0) 
		{
			Debug.LogError("retard alert: SpawnerScript");
			return;
		}
	}

	void Update()
	{
        if (Input.GetKeyUp(KeyCode.Alpha1) && astroidSpawn == true) 
		{
			SpawnAstroid ();
			astroidSpawn = false;
		}

        if (Input.GetKeyUp(KeyCode.Alpha2) && spawnRain == true) 
		{
            MakeItRain ();
			spawnRain = false;
		}

		if (astroidSpawn == false) 
		{
			astroidTimer -= Time.deltaTime;
		}

		if (astroidTimer <= 0)
		{
			astroidSpawn = true;
			astroidTimer = timeForAstroid;
		}

		if (spawnRain == false) 
		{
			rainTimer -= Time.deltaTime;
		}

		if (rainTimer <= 0)
		{
			spawnRain = true;
			rainTimer = timeForRain;
		}
    }

	public void MakeItRain()
	{
		astroid = (GameObject) Instantiate (spawnPrefab[1], spawnLocation.position, Quaternion.identity);
        audioPlay.PlayOneShot(babyClip);
        crossHair.Open();
	} 

	public void SpawnAstroid()
	{
		astroid = (GameObject) Instantiate (spawnPrefab[0], spawnLocation.position, Quaternion.identity);
        crossHair.Open();
	}
}
