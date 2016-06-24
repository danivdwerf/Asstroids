using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
    [SerializeField] private Image blockDark1;
    [SerializeField] private Image blockDark2;
    [SerializeField] private Image beadsDark1;
    [SerializeField] private Image beadsDark2;
    private DropObjects dropScript;

	void Start () 
    {
        dropScript = GetComponent<DropObjects>();

        blockDark1.fillAmount = dropScript.astroidTimer/dropScript.timeForAstroid;
        blockDark2.fillAmount = dropScript.astroidTimer/dropScript.timeForAstroid;
        beadsDark1.fillAmount = dropScript.rainTimer/dropScript.timeForRain;
        beadsDark2.fillAmount = dropScript.rainTimer/dropScript.timeForRain;
	}

	void Update () 
    {
        blockDark1.fillAmount = dropScript.astroidTimer/dropScript.timeForAstroid;
        blockDark2.fillAmount = dropScript.astroidTimer/dropScript.timeForAstroid;
        beadsDark1.fillAmount = dropScript.rainTimer/dropScript.timeForRain;
        beadsDark2.fillAmount = dropScript.rainTimer/dropScript.timeForRain;
	}
}
