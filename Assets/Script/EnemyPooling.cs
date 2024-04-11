using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int[] poolSize;
    public List<GameObject> enemiesList;
    private int num;

    public static EnemyPooling instance;
    public static EnemyPooling Instance { get { return instance; } }

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
        foreach (var enemy in enemies)
        {
            while (num < enemies.Length)
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
    }

    public GameObject RequestEnemy(string nameEnemy)
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (!enemiesList[i].activeSelf && enemiesList[i].name == nameEnemy)
            {
                enemiesList[i].SetActive(true);
                return enemiesList[i];
            }
        }
        return null;
    }



}
