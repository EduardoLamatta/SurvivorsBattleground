using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceEnemies : MonoBehaviour
{
    private float timeInstanceEnemy;
    private Player player;
    [SerializeField] private float rangeDistance;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        timeInstanceEnemy = 0;
    }

    void Update()
    {
        timeInstanceEnemy += Time.deltaTime;

        InstanceEnemy(2f, "NormalEnemy(Clone)");
        InstanceEnemy(45f, "MediumEnemy(Clone)");
        InstanceEnemy(60f, "TreeMan(Clone)");
        InstanceEnemy(120f, "ShooterEnemy(Clone)");
        InstanceEnemy(240f, "ExplosiveEnemy(Clone)");
        InstanceEnemy(480f, "MiniBoss(Clone)");
    }

    private void InstanceEnemy(float timeSpawn, string nameEnemy)
    {
        if (timeInstanceEnemy > timeSpawn)
        {
            for (int i = 0; i < EnemyPooling.Instance.enemiesList.Count; i++)
            {
                if (!EnemyPooling.Instance.enemiesList[i].activeSelf && EnemyPooling.Instance.enemiesList[i].name == nameEnemy)
                {
                    RandomInstance(nameEnemy);
                }
            }

        }
    }
    private void InstanceNormalEnemy(float timeSpawn, string nameEnemy)
    {
        if (timeInstanceEnemy > timeSpawn)
        {
            for (int i = 0; i < EnemyPooling.Instance.enemiesList.Count; i++)
            {
                if (!EnemyPooling.Instance.enemiesList[i].activeSelf && EnemyPooling.Instance.enemiesList[i].name == nameEnemy)
                {
                    RandomInstance(nameEnemy);
                }
            }

        }
    }

    private void RandomInstance(string name)
    {
       
        float angulo = Random.Range(0,361);
        float x = player.transform.position.x + Mathf.Cos(angulo) * rangeDistance;
        float y = player.transform.position.y + Mathf.Sin(angulo) * rangeDistance;
        float z = player.transform.position.z;
        GameObject enemyInstance = EnemyPooling.Instance.RequestEnemy(name);
        enemyInstance.transform.position = new Vector3(x, y, z);
    }


}
