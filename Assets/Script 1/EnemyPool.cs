using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int[] poolSize;
    public List<GameObject> enemiesList;
    private int num;

    public static EnemyPool instance;
    public static EnemyPool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AddEnemiesToList();
    }

    private void AddEnemiesToList()
    {
        while(num < enemies.Length)
        {
            for (int i = 0; i < poolSize[num]; i++)
            {
                GameObject enemiesInstance = Instantiate(enemies[num]);
                enemiesList.Add(enemiesInstance);
                enemiesInstance.SetActive(false);
                enemiesInstance.transform.parent = transform;
            }
            num++;
        }

    }

    public GameObject RequestEnemy()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (!enemiesList[i].activeSelf)
            {
                enemiesList[i].SetActive(true);
                return enemiesList[i];
            }
        }
        return null;
    }
}
