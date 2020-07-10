using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    public int Health = 1;
    public float InvulnerabilityTimeout = 2;

    private float _invuln;
    private int _originalLayer;


    private void Start()
    {
        _originalLayer = gameObject.layer;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Detected");

        if (_invuln > 0) return;
        
        Health--;
        _invuln = InvulnerabilityTimeout;
        _originalLayer = gameObject.layer;
        gameObject.layer = 10;

        //Destroy(gameObject);
    }

    private void FixedUpdate()
    {

        /*if (_invuln > 0)
        {
            _invuln -= Time.deltaTime;
        }
        else
        {
            gameObject.layer = _originalLayer;
        }
        
        if (Health == 0)
        {
            gameObject.SetActive(false);
        }*/
    }
}
