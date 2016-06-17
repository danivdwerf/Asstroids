using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class TimeStamp : MonoBehaviour 
{
	private float timeStamp1;
	private float timeStamp2;
	private float timeStamp3;
	private float timeStamp4;

    public float player1Time;
    public float player2Time;

    [SerializeField] private Transform location;
    private CarController player;
    private Vector3 carPos; 
    private Quaternion carRot;

	void Start () 
	{
		player1Time = 0;
		player2Time = 0;
        player = GameObject.FindObjectOfType<CarController>();
        carPos = new Vector3 (location.transform.position.x, location.transform.position.y, location.transform.position.z);
        carRot = new Quaternion (location.transform.rotation.x, location.transform.rotation.y, location.transform.rotation.z,0f);
	}

	public void Player1Start()
	{
		timeStamp1 = Time.time;
	}

	public void Player2Start()
	{
		timeStamp3 = Time.time;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player1"))
		{
          
			ShowScore showScore = GameObject.FindObjectOfType<ShowScore> ();
			timeStamp2 = Time.time;
            player1Time = timeStamp2 - timeStamp1;
            showScore.Finnish (player1Time, player2Time);
                
            player.gameObject.transform.position = carPos;
            player.gameObject.transform.rotation = carRot;
            player.motor = 0;
            player.steering = 0;
            player.reverse = 0;
            player.drive = false;
		}
		if (other.CompareTag("Player2")) 
		{
			ShowScore showScore = GameObject.FindObjectOfType<ShowScore> ();
			timeStamp4 = Time.time;
			player2Time = timeStamp4 - timeStamp3;
			showScore.Finnish (player1Time, player2Time); 
            player.drive = false;
            player.gameObject.transform.position = carPos;
            player.gameObject.transform.rotation = carRot;
		}
	}
}
