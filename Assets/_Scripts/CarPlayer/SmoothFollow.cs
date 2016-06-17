using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class SmoothFollow : MonoBehaviour
    {
        private Transform target;
        private float distance = 10f;
        private float height = 3f;
        private float rotationDamping =5.0f; 
        private float heightDamping = 5f;

        void Start()
        {
            PlayerState playerState = GameObject.FindObjectOfType<PlayerState> ();
            target = playerState.player.transform;
        }

        void LateUpdate()
        {
            if (!target) 
            {
                return;
            }

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