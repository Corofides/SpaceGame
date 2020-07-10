using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float BulletSpeed = 1f;
    private CollisionDetector _collisionDetector;

    private void Start()
    {
        _collisionDetector = GetComponent<CollisionDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 velocity = new Vector3(0, BulletSpeed * Time.deltaTime, 0);
        position += transform.rotation * velocity;

        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }

    public void ResetHealth()
    {
        GetComponent<CollisionDetector>().Health = 1;
        //_collisionDetector.Health = 1;
    }
    
}
