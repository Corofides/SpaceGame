using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float SpawnRate = 10f;
    public GameObject EnemyPrefab;

    private float _coolDownTimer = 2f;
    private int _layer = 9;

    private List<GameObject> _enemies;

    private void Start()
    {
        _enemies = new List<GameObject>();
    }

    private void SetupEnemy(GameObject enemyObject)
    {
        Vector3 enemyPosition = enemyObject.transform.position;
        Vector3 spawnPosition = transform.position;

        enemyPosition.x = spawnPosition.x;
        enemyPosition.y = spawnPosition.y;

        enemyObject.transform.position = enemyPosition;
        enemyObject.layer = _layer;

        enemyObject.transform.SetParent(transform);
        
    }

    private void FixedUpdate()
    {

        if (_coolDownTimer > 0)
        {
            _coolDownTimer -= Time.deltaTime;
            return;
        }

        if (_enemies.Count < 3)
        {  
            GameObject enemyObject = Instantiate(EnemyPrefab);
            SetupEnemy(enemyObject);
            _enemies.Add(enemyObject);
            _coolDownTimer = SpawnRate;
            return;
        }

        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == null)
            {
                _enemies[i] = Instantiate(EnemyPrefab);
                SetupEnemy(_enemies[i]);
                _coolDownTimer = SpawnRate;
                return;
            }
                
        }
           
        _coolDownTimer = SpawnRate;
        
        
    }
}
