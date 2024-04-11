using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedProjectile : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rbProjectile;
    public Transform playerPosition;
    public static float speedAditional;
    public Vector2 directionBullet;
    void Awake()
    {
        rbProjectile = GetComponent<Rigidbody2D>();
        playerPosition = FindAnyObjectByType<Player>().transform;
        animator = GetComponent<Animator>();
    }
    
    public void LaunchProjectile(Vector2 direction, float speedBullet)
    {
        rbProjectile.velocity = direction * speedBullet * speedAditional;
        directionBullet = direction;

    }

    public void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
