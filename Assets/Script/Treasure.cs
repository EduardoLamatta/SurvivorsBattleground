using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private bool collectedTreasure;
    public float numRandom;
    private int totalCoins;
    public int numCoins;
    private PanelController panelController;
    private Transform playerPosition;
    private float distanceToPlayer;
    private void Start()
    {
        collectedTreasure = false;
        panelController = FindAnyObjectByType<PanelController>();
        playerPosition = FindAnyObjectByType<Player>().transform;
    }

    private void Update()
    {
        numCoins = int.Parse(panelController.scoreText.text);
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);
        if (distanceToPlayer > 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collectedTreasure) 
        {
            numCoins += 20;
            panelController.ControlScoreText(numCoins);
            collectedTreasure = true;
            totalCoins = PlayerPrefs.GetInt("TotalCoins");
            totalCoins += 20;
            PlayerPrefs.SetInt("TotalCoins", totalCoins);
            Destroy(gameObject);
        }
    }
}
