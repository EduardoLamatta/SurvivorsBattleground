using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    void Update()
    {
        EnemyPool.instance.RequestEnemy();
    }
}
