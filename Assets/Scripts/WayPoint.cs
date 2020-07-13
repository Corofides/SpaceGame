using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    public Transform GetTransform()
    {
        return transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("WayPoint Collision");
        Debug.Log(other.gameObject.layer);

        if (other.gameObject.layer != 9)
            return;
        
        EnemyController enemyController = other.gameObject.GetComponent<EnemyController>();

        if (enemyController != null)
            enemyController.ChangeWayPoint();
    }

}
