using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour 
{
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private Image loadImage;
    [SerializeField] private Text loadText;

    public void LoadGame()
    {
        StartCoroutine(LevelCoroutine());
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator LevelCoroutine()
    {
        loadPanel.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync(1);

        while(!async.isDone)
        {
            float percentage = Mathf.Floor((async.progress * 100) / 0.9f);
            loadImage.fillAmount = async.progress / 0.9f;
            loadText.text = percentage.ToString() + "%";
            yield return null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
