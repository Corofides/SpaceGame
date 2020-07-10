using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    public float Speed;
    public float RotationSpeed;
    public float FireDelay = 0.5f;
    public int Health = 10;

    public GameObject BulletObject;
    public GunController[] Guns;
    
    private Rigidbody2D _playerBody;
    private BoxCollider2D _playerCollider;

    private float _moveVertical;
    private float _moveHorizontal;
    private int _collectables;

    private bool _isFiring;
    private float _coolDownTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _playerBody = GetComponent<Rigidbody2D> ();
        _playerCollider = GetComponent<BoxCollider2D> ();
        _moveVertical = 0.0f;
        _moveHorizontal = 0.0f;
    }

    // Update is called once per frame.
    void Update() {
        _moveVertical = Input.GetAxis("Vertical");
        _moveHorizontal = Input.GetAxis("Horizontal");
        _isFiring = Input.GetButton("Jump");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(gameObject);
        //gameObject.SetActive(false);

        int itemLayer = other.gameObject.layer;

        switch (itemLayer)
        {
            case 11:
                Destroy(other.gameObject);
                _collectables++;
                break;
            case 12:
                if (_collectables >= 1)
                {
                    other.gameObject.GetComponent<SpaceStation>().AddParts();
                    _collectables--;
                }
                break;
            default:
                Debug.Log("Player Collision Detected");
                Health--;
                break;
        }
    }

    public int TotalCollectables()
    {
        return _collectables;
    }

    public int GetHealth()
    {
        return Health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //Make it so...
        Quaternion rot = transform.rotation;
        float zRotation = rot.eulerAngles.z;
        zRotation -= _moveHorizontal * RotationSpeed * Time.deltaTime;
        //transform.rotation.eulerAngles.z = zRotation;
        transform.rotation = Quaternion.Euler(0, 0, zRotation);

        Vector3 position = transform.position;
        Vector3 velocity = new Vector3 (0.0f, _moveVertical * Speed * Time.deltaTime, 0.0f);

        position += transform.rotation * velocity;

        transform.position = position;

        /*if (_isFiring)
        {
            
            //Implement Shooting.
            GameObject bulletObject = Instantiate(BulletObject);
            Vector3 bulletPosition = bulletObject.transform.position;
            bulletPosition.x = transform.position.x;
            bulletPosition.y = transform.position.y;

            bulletObject.transform.position = bulletPosition;

        }*/

        if (_isFiring)
        {
            foreach (GunController gunController in Guns)
            {
                gunController.Fire();
            }
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    
}
