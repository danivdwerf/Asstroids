using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour 
{
	public Text finalTime1;
	public Text finalTime2;
    [SerializeField] private Text winner; 
    [SerializeField] private GameObject scorePanel;  
    [SerializeField] private GameObject winPanel;
    private Button[] buttons;
    private WinSound winSound;

	void Awake()
	{
        scorePanel.SetActive(false); 
        buttons = scorePanel.GetComponentsInChildren<Button> ();
        winSound = GetComponent<WinSound>();
	}

	public void Finnish (float player1Time, float player2Time) 
	{
		finalTime1.text = "Player1: " + System.Math.Round(player1Time,2).ToString() + " sec";
		finalTime2.text = "Player2: " + System.Math.Round(player2Time,2).ToString() + " sec";
        scorePanel.SetActive(true);
        Cursor.visible = true;

        if (player2Time == 0)
        {
            for (int i = 0; i < buttons.Length; i++) 
            {
                if (buttons [i].gameObject.name == "NextButton") 
                {
                    buttons[i].gameObject.SetActive(true);
                }

                if (buttons [i].gameObject.name == "ReplayButton")
                {
                    buttons[i].gameObject.SetActive(false);
                    winPanel.SetActive(false);
                }
            }

            winner.enabled = false;
        }

        if (player2Time != 0)
        {	
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].gameObject.name == "NextButton")
                {
                    buttons[i].gameObject.SetActive(false);
                }

                if (buttons[i].gameObject.name == "ReplayButton")
                {
                    buttons[i].gameObject.SetActive(true);
                    winPanel.SetActive(true);
                    winSound.Cheering();
                }
            }

            winner.enabled = true;
            if (player1Time < player2Time)
            {
                winner.text="Player1 Wins!!!";
            }

            if (player1Time > player2Time)
            {
                winner.text="Player2 Wins!!!";
            }
		}
	}
}
