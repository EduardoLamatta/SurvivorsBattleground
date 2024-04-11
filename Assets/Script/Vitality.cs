using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitality : MonoBehaviour
{
    [SerializeField] private float lifeRecovered;
    private float lastTimeRecovered;
    
    private Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }
    void Update()
    {
        lastTimeRecovered += Time.deltaTime;
        
        if (lastTimeRecovered > 1 && player.lifePlayer <= 100 && player.lifePlayer > 0)
        {
            player.LifeRecoveredPlayer(lifeRecovered);
            lastTimeRecovered = 0;
        }
    }


}
