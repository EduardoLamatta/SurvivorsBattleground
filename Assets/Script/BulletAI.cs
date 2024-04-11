using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    private Rigidbody2D rbBulletAI;
    private Player player;
    [SerializeField] private float speedBulletAI;
    private float distanceToPlayer;
    [SerializeField] private float damageToPlayer;

    private void Start()
    {
        rbBulletAI = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
        LaunchProjectile();
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
        if (distanceToPlayer > 3f)
        {
            DestroyObject();
        }
    }

    private void LaunchProjectile()
    {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        transform.right = directionToPlayer;
        rbBulletAI.velocity = transform.right*speedBulletAI;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.ControlLifePlayer(damageToPlayer);
            DestroyObject();
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
