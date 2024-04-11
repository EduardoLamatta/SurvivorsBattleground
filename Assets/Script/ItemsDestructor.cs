using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDestructor : MonoBehaviour
{
    [HideInInspector] public bool collisionFlames;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireFlamethrower")
        {
            collisionFlames = true;
        }

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FireFlamethrower")
        {
            collisionFlames = false;;
        }
    }
}
