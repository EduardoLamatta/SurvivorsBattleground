using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SpeedProjectile
{
    public static float damageGun = 5;
    [SerializeField] private float volumen;
    [SerializeField] private float timeDestroy;
    [SerializeField] private AudioClip audioClip;
    private Collider2D colliderEnemy;

    private void OnEnable()
    {
        if (BulletPool.Instance.soundActive)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip, volumen);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        colliderEnemy = collision;

        if (collision.TryGetComponent(out Enemy01 enemy) && colliderEnemy != null && enemy.lifeEnemy > 0)
        {
            enemy.rbEnemy.AddForce(directionBullet * 6, ForceMode2D.Impulse);
            enemy.ControlLifeEnemy(damageGun * PowerFire.powerAditional);
            gameObject.SetActive(false);
            if (colliderEnemy != null && enemy.lifeEnemy > 0)
            {
                Invoke("ContinueMovement", 0.25f);
            }
            else DestroyObject();
        }
        else if (collision.TryGetComponent(out ExplosiveEnemy explosiveEnemy) && colliderEnemy != null && explosiveEnemy.lifeEnemy > 0)
        {
            explosiveEnemy.rbEnemy.AddForce(directionBullet * 1, ForceMode2D.Impulse);
            explosiveEnemy.ControlLifeEnemy(damageGun * PowerFire.powerAditional);
            gameObject.SetActive(false);
            if (colliderEnemy != null && explosiveEnemy.lifeEnemy > 0)
            {
                Invoke("ContinueMovement", 0.25f);
            }
            else DestroyObject();
        }
    }

    private void ContinueMovement()
    {
        if (colliderEnemy.TryGetComponent(out Enemy01 enemy))
        {
            DestroyObject();
            enemy.rbEnemy.AddForce(directionBullet * -6, ForceMode2D.Impulse);            
        }
        else if (colliderEnemy.TryGetComponent(out ExplosiveEnemy explosiveEnemy))
        {
            DestroyObject();
            explosiveEnemy.rbEnemy.AddForce(directionBullet * -1, ForceMode2D.Impulse);
        }


    }
}
