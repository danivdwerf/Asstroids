using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DropObjects : MonoBehaviour 
{
    [SerializeField] private Sprite closed;
    [SerializeField] private Sprite open;
    private CrossHair crossHair; 
    private SpriteRenderer crossSprite;

    private AudioSource audioPlay;
    [SerializeField] private AudioClip babyClip;

    [SerializeField] private Transform spawnLocation;
	public List<GameObject> spawnPrefab = new List<GameObject>();

	private GameObject astroid;
	public bool astroidSpawn;
    public float astroidTimer;
	private float timeForAstroid = 4f;
    private float closeHand=15;
    private bool openHand;

	public bool spawnRain;
	private float rainTimer;
	private float timeForRain = 5f;
    [SerializeField] private Image blockDark1;
    [SerializeField] private Image blockDark2;
    [SerializeField] private Image beadsDark1;
    [SerializeField] private Image beadsDark2;

	void Start()
	{
		astroidSpawn = true;
        spawnRain = true;
        openHand = false;
        crossHair = GameObject.FindObjectOfType<CrossHair>();
        crossSprite = crossHair.GetComponent<SpriteRenderer>();
        crossSprite.sprite = closed;

        audioPlay=GetComponent<AudioSource>();

        blockDark1.fillAmount = astroidTimer/timeForAstroid;
        blockDark2.fillAmount = astroidTimer/timeForAstroid;
        beadsDark1.fillAmount = rainTimer/timeForRain;
        beadsDark2.fillAmount = rainTimer/timeForRain;
		
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
            blockDark1.fillAmount = astroidTimer/timeForAstroid;
            blockDark2.fillAmount = astroidTimer/timeForAstroid;
		}

		if (astroidTimer <= 0)
		{
			astroidSpawn = true;
			astroidTimer = timeForAstroid;
		}

		if (spawnRain == false) 
		{
			rainTimer -= Time.deltaTime;
            beadsDark1.fillAmount = rainTimer/timeForRain;
            beadsDark2.fillAmount = rainTimer/timeForRain;
		}

		if (rainTimer <= 0)
		{
			spawnRain = true;
			rainTimer = timeForRain;
		}

        if (closeHand == 0)
        {
            crossSprite.sprite = closed;
            openHand = false;
            closeHand = 15;
        }

        if (openHand == true)
        {
            closeHand--;
        }
    }

	public void MakeItRain()
	{
		astroid = (GameObject) Instantiate (spawnPrefab[1], spawnLocation.position, Quaternion.identity);
        crossSprite.sprite = open;
        openHand = true;
        audioPlay.PlayOneShot(babyClip);
	} 

	public void SpawnAstroid()
	{
		astroid = (GameObject) Instantiate (spawnPrefab[0], spawnLocation.position, Quaternion.identity);
        crossSprite.sprite = open;
        openHand = true;
	}
}
