using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMain : MonoBehaviour
{
    private Rigidbody2D rbZombie;
    private float speedEnemy = 0.5f;
    [SerializeField] private float valueY;
    private Vector3 startPosition;

    void Start()
    {
        rbZombie = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {        
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(3, valueY,0), speedEnemy * Time.deltaTime);

        if (transform.position == new Vector3(3, valueY, 0)) transform.Translate(startPosition);
    }
}
