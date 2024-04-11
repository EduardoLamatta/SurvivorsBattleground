using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agility : MonoBehaviour
{
    [SerializeField] private float velocityAditional;

    private Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        AgilityPlayer();
    }

    private void AgilityPlayer()
    {
        player.speed += player.speed * velocityAditional/100;
    }
    
}
