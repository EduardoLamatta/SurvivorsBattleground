using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestructor : MonoBehaviour
{
    private Transform playerTransform;

    public float distanceToPlayer;
    private void Start()
    {
        playerTransform = FindAnyObjectByType<Player>().transform;
    }
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > 4)
        {
            gameObject.SetActive(false);
        }
    }

}
