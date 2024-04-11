using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsMain : MonoBehaviour
{
    public Transform player;
    [HideInInspector] public Vector2 worldPosition;

   

    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = worldPosition - (Vector2)transform.position;
        transform.right = direction;
        LookToward();
    }



    private void LookToward()
    {
        if (worldPosition.x - player.position.x != 0)
        {
            if (worldPosition.x - player.position.x > 0) GetComponentInParent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f) * player.transform.localScale.x;
            else GetComponentInParent<Transform>().localScale = new Vector3(0.3f, -0.3f, 0.3f) * player.transform.localScale.x;
        }
    }
}
