using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShootProjectile : MonoBehaviour
{
    [HideInInspector] public Transform shootPosition;
    [HideInInspector] public PanelController panelController;
    [HideInInspector] public Vector2 worldPosition;
    [HideInInspector] public Player player;
    [HideInInspector] public float distanceToPlayer;

    protected virtual void Start()
    {
        panelController = FindAnyObjectByType<PanelController>();
        player = FindAnyObjectByType<Player>();
    }
    protected virtual void Update()
    {
        LookToward();
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = worldPosition - (Vector2)transform.position;
        transform.right = direction;

        distanceToPlayer = Vector3.Distance(worldPosition, player.transform.position);
    }

    private void LookToward()
    {
        if (worldPosition.x - player.transform.position.x != 0)
        {
            if (worldPosition.x - player.transform.position.x > 0) GetComponentInParent<Transform>().localScale = new Vector3(0.4f * player.transform.localScale.x, 0.4f, 0.4f);
            else GetComponentInParent<Transform>().localScale = new Vector3(0.4f * player.transform.localScale.x, -0.4f, 0.4f);
        }
    }

}
