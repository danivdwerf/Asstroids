﻿using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class SmoothFollow : MonoBehaviour
    {
        [SerializeField]private Transform target;
        [SerializeField]private float distance;
        [SerializeField]private float height;
        [SerializeField]private float rotationDamping; 
        [SerializeField]private float heightDamping;

        void Start()
        {
            PlayerState playerState = GameObject.FindObjectOfType<PlayerState> ();
            target = playerState.Player.transform;
        }

        void LateUpdate()
        {
            if (!target) 
               return;

            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;
            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);
            transform.LookAt(target);
        }
    }
}