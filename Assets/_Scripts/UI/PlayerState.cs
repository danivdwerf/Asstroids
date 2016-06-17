using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour 
{
	public GameObject player;
    [SerializeField]private GameObject spawnPrefab; 
	public Transform startLocation;
	private CarController car;

	void Awake()
	{
		
		SetPlayer1 ();
	}

	public void SetPlayer1()
	{
		TimeStamp timeStamp = GameObject.FindObjectOfType<TimeStamp> ();
		car = GameObject.FindObjectOfType<CarController> ();
		player = (GameObject)Instantiate (spawnPrefab, startLocation.position, Quaternion.identity);
		player.tag = "Player1";
		timeStamp.Player1Start ();
	}

	public void SetPlayer2()
	{
		TimeStamp timeStamp = GameObject.FindObjectOfType<TimeStamp> (); 
		car = GameObject.FindObjectOfType<CarController> ();
        player.tag = "Player2";
        Timer timer = GameObject.FindObjectOfType<Timer>();
        timer.gameTime = 0;
        car.drive = true;
		timeStamp.Player2Start ();
	}
}