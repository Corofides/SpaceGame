using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform playerTransform;

    private void FixedUpdate()
    {

        if (playerTransform != null)
        {
            Vector3 cameraPosition = transform.position;
            Vector3 playerPosition = playerTransform.position;

            cameraPosition.x = playerPosition.x;
            cameraPosition.y = playerPosition.y;

            transform.position = cameraPosition;
        }

    }

}
