using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float RotationSpeed = 180;
    public float ViewDistance = 5f;
    public GunController[] Guns;
    public int Health = 1;
    
    private GameObject _player;
    private bool _playerNull = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(gameObject);
        //gameObject.SetActive(false);
        Health--;
    }

    private void FixedUpdate()
    {
        if (_playerNull)
            return;
        
        if (_player == null)
        {
            GameObject player = GameObject.Find("Player");

            if (player == null)
            {
                _playerNull = true;
                return;
            }

            _player = player;
        }

        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();

        //Eww maths. Yes, it has an 's'
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRoation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRoation, RotationSpeed * Time.deltaTime);

        foreach (GunController gun in Guns)
        {
            gun.Fire();
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        
        
    }
}
