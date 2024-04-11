using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPooling : MonoBehaviour
{
    [SerializeField] private GameObject[] backgroundsItems;
    [SerializeField] private int poolSize;
    public List<GameObject> backgroundList;

    public static BackgroundPooling instance;
    public static BackgroundPooling Instance { get { return instance; } }

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

    private void Start()
    {
        AddItemsToPool(poolSize);       
    }

    private void AddItemsToPool(int amount)
    {
        foreach (var item in backgroundsItems)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject background = Instantiate(item);
                backgroundList.Add(background);
                background.SetActive(false);
                background.transform.parent = transform;
            }
        }
    }

    public GameObject RequestItem()
    {
        for(int i = 0; i < backgroundList.Count; i++)
        {
            if (!backgroundList[i].activeSelf)
            {
                backgroundList[i].SetActive(true);
                return backgroundList[i];
            }
        }
        return null;
    }
}
