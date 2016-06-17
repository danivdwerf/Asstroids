using UnityEngine;
using System.Collections;

public class EnemyMovement: MonoBehaviour 
{
    private Transform target;
    private float height = 30f;
    private float heightDamping = 1f;

    void Start()
    {
        PlayerState playerState = GameObject.FindObjectOfType<PlayerState>();
        target = playerState.player.transform;
    }

    void LateUpdate()
    {
        if (!target)
        {
            return;
        }
        var wantedHeight = target.position.y + height;
        var currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        transform.position = target.position;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.LookAt(target);
    }
}