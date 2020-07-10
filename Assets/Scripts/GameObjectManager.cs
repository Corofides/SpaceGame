using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{

    private static GameObjectManager _manager;
    public static GameObjectManager Manager => _manager;
    public GameObject BulletPrefab;

    private int _initialPoolAmount = 10;
    private List<GameObject> _bullets;
    
    private void Awake()
    {

        if (_manager == null)
        {
            _manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        _bullets = new List<GameObject>(_initialPoolAmount);

        for (int i = 0; i < _initialPoolAmount; i++)
        {
            AddBulletToPool();
        }
        
        
    }

    private GameObject AddBulletToPool()
    {
        GameObject bulletObject = Instantiate(BulletPrefab);
        bulletObject.SetActive(false);
        bulletObject.transform.SetParent(transform);
        _bullets.Add(bulletObject);
        return bulletObject;
    }

    public GameObject GetBullet()
    {

        foreach (GameObject bullet in _bullets)
        {

            if (!bullet.activeInHierarchy)
            {
                //Debug.Log("Bullet Returned From Pool");
                BulletController bulletController = bullet.GetComponent<BulletController>();
                bulletController.ResetHealth();
                return bullet;
            }
            
        }

        return AddBulletToPool();
    }

}
