using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour 
{
	[SerializeField] private GameObject scorePanel; 
    private WinSound winSound;

	public void NextRace()
	{
		PlayerState playerState=GameObject.FindObjectOfType<PlayerState>();
		playerState.SetPlayer2(); 
        scorePanel.SetActive(false);
		Cursor.visible = false;
	}

    public void RestartRace()
    {
        winSound = GameObject.FindObjectOfType<WinSound>();
        winSound.StopSound();
        SceneManager.LoadScene(0);
    }
}
