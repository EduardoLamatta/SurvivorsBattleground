using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private Transform playerPosition;
    private float distanceToPlayer;
    private int totalCoins;
    public int numCoins;
    public PanelController panelController;

    private void Start()
    {
        playerPosition = FindAnyObjectByType<Player>().transform;
        panelController = FindAnyObjectByType<PanelController>();
    }
    private void Update()
    {
        numCoins = int.Parse(panelController.scoreText.text);
        distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);
        if (distanceToPlayer > 6 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            numCoins++;
            panelController.ControlScoreText(numCoins);
            totalCoins = PlayerPrefs.GetInt("TotalCoins");
            totalCoins += 1;
            PlayerPrefs.SetInt("TotalCoins", totalCoins);
            Destroy(gameObject);
        }
    }
}
