using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    [SerializeField] private GameObject prefabBulletAI;
    private Player player;
    private float time;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > 2 && Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            //GameObject bulletAI = BulletPool.Instance.RequestBulletAI();
            GameObject bulletAI = Instantiate(prefabBulletAI, transform.position, Quaternion.identity);
            bulletAI.transform.position = transform.position;
            time = 0;
        }

    }
}
