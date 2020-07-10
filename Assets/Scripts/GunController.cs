using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public float FireDelay = 0.5f;
    public GameObject BulletObject;
    public int BulletLayer = 9;

    private float _coolDownTimer;

    private void FixedUpdate()
    {
        if (_coolDownTimer > 0)
        {
            _coolDownTimer = _coolDownTimer - Time.deltaTime;
        }
    }

    public void Fire() 
    {

        if (_coolDownTimer <= 0)
        {
            
          
            GameObject bullet = GameObjectManager.Manager.GetBullet();
            
            bullet.layer = BulletLayer;

            //Debug.Log(BulletLayer);
            
            Vector3 bulletPosition = bullet.transform.position;
            Vector3 playerPosition = transform.position;

            bulletPosition.x = playerPosition.x;
            bulletPosition.y = playerPosition.y;

            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = bulletPosition;

            
            bullet.SetActive(true);
            
            _coolDownTimer = FireDelay;
            
        }
        
    }
    
}
