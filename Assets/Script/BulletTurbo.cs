using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurbo : MonoBehaviour
{
    [SerializeField] private float speedBulletTurbo;

    private void Start()
    {    
        SpeedProjectile.speedAditional = speedBulletTurbo;
    }
}
