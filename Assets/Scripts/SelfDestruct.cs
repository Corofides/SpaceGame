using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    
    public float Timer = 1f;
    private float _currentTime;

    private void Start()
    {
        _currentTime = Timer;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            gameObject.SetActive(false);
            _currentTime = Timer;
        }

    }
}
