using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{
    private bool pauseGame = false;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject crossHair;

    void Awake()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;
            if (pauseGame == true)
            {
                Time.timeScale = 0;
                pauseGame = true;
                pausePanel.SetActive(true);
                crossHair.SetActive(false); 
                Cursor.visible = true;
            }

            if (pauseGame == false)
            {
                Time.timeScale = 1;
                pauseGame = false;
                pausePanel.SetActive(false);
                crossHair.SetActive(true); 
                Cursor.visible = false;
            }
        }
	}
}

