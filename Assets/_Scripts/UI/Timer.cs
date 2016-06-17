using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    public float minutes;
    public float seconds;
    public float milliseconds;
    public float gameTime;

	public Text timeText; 

    void Start()
    {
        gameTime = 0;
    }
 	
    void Update()
	{
        gameTime += Time.deltaTime;
        minutes = gameTime / 60;
        seconds = gameTime % 60;
        milliseconds = gameTime * 1000;
		milliseconds = milliseconds % 1000;
		timeText.text = Mathf.Floor(minutes) + ":" + Mathf.Floor(seconds) + ":" + Mathf.Floor(milliseconds);
	}
}