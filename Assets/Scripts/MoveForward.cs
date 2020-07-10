using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float Speed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 velocity = new Vector3(0, Speed * Time.deltaTime, 0);
        position += transform.rotation * velocity;

        transform.position = position;
    }
}
