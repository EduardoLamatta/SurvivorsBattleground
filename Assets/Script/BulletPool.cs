using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefab;
    [SerializeField] private GameObject bulletAI;
    [SerializeField] private int[] poolSize;
    [SerializeField] private int poolSizeAI;
    public bool soundActive;
    private int num;
    [SerializeField] private List<GameObject> bulletList, bulletAIList;
 
    private static BulletPool instace;
    public static BulletPool Instance { get { return instace; } }

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AddBulletToList(); 
        //AddBulletAIToList(poolSizeAI);
    }

    private void AddBulletToList()
    {
        foreach (var bullet in bulletPrefab)
        {
            while(num < bulletPrefab.Length)
            {
                for (int i = 0; i < poolSize[num]; i++)
                {
                    GameObject bulletInstance = Instantiate(bulletPrefab[num]);
                    bulletList.Add(bulletInstance);
                    bulletInstance.SetActive(false);
                    bulletInstance.transform.parent = transform;
                    soundActive = false;
                }
                num++;
            }
        }
    }
    public GameObject RequestBullet(string nameBullet)
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeSelf && bulletList[i].name == nameBullet)
            {
                soundActive = true;
                bulletList[i].SetActive(true);
                return bulletList[i];
            }
        }
        return null;
    }

    /*private void AddBulletAIToList(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bulletAIInstance = Instantiate(bulletAI);
            bulletAIList.Add(bulletAIInstance);
            bulletAIInstance.SetActive(false);
            bulletAIInstance.transform.parent = transform;
            soundActive = false;
        }
    }
    public GameObject RequestBulletAI()
    {
        for (int i = 0; i < bulletAIList.Count; i++)
        {
            if (!bulletAIList[i].activeSelf)
            {
                soundActive = true;
                bulletAIList[i].SetActive(true);
                return bulletAIList[i];
            }
        }
        AddBulletAIToList(1);
        bulletAIList.Add(bulletAIList[bulletAIList.Count - 1]);
        return bulletAIList[bulletAIList.Count - 1];
    }
    */
    


}
