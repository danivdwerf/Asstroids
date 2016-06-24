using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour 
{
    [SerializeField] private Sprite closed;
    [SerializeField] private Sprite open;
    public SpriteRenderer crossSprite;
    private float closeHand=15;
    private bool openHand;

    void Start()
    {
        crossSprite = GetComponent<SpriteRenderer>();
        crossSprite.sprite = closed;
        openHand = false;
    }

    void Update()
    {
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

    public void Open()
    {
        crossSprite.sprite = open;
        openHand = true;
    }
}
