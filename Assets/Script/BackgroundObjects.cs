using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjects : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float rangeDistance;

    private void Start()
    {
        playerTransform = FindAnyObjectByType<Player>().transform;
    }
    private void Update()
    {
        for (int i = 0; i < BackgroundPooling.Instance.backgroundList.Count; i++)
        {
            if (!BackgroundPooling.Instance.backgroundList[i].activeSelf)
            {
                RandomInstance();
            }
        }

    }

     
    private void RandomInstance()
    {
        float randoRangeDistance = Random.Range(rangeDistance, rangeDistance + 1);
        float angulo = Random.Range(0, 361);
        float x = playerTransform.position.x + Mathf.Cos(angulo) * randoRangeDistance; 
        float y = playerTransform.position.y + Mathf.Sin(angulo) * randoRangeDistance; ;
        float z = playerTransform.position.z;
        GameObject background = BackgroundPooling.Instance.RequestItem();
        background.transform.position = new Vector3(x, y, z);
    }

    
}
