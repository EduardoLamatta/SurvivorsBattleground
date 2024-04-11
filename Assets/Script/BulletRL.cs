using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRL : SpeedProjectile
{
    [HideInInspector] public Vector2 endPosition, startPosition;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volumen;
    private Collider2D colliderEnemy;
    public static float damageRocketLauncher = 40;
    [SerializeField] AudioClip audioExplosion;
    private bool nearly;

    private void OnEnable()
    {
        if (BulletPool.Instance.soundActive)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(audioClip, volumen);
        }
        nearly = false;
    }
    void Update()
    {
        startPosition = transform.position;
        
        float distance = Vector3.Distance(startPosition, endPosition);

        if (distance < 0.05 && !nearly)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(audioExplosion, 0.5f);
            rbProjectile.velocity = Vector2.zero;
            animator.SetTrigger("Destroy");
            nearly = true;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliderEnemy = collision;

        if (collision.TryGetComponent(out Enemy01 enemy) && colliderEnemy != null && enemy.lifeEnemy > 0)
        {
            enemy.ControlLifeEnemy(damageRocketLauncher * PowerFire.powerAditional);
        }
        else if (collision.TryGetComponent(out ExplosiveEnemy explosiveEnemy) && colliderEnemy != null && explosiveEnemy.lifeEnemy > 0)
        {
            explosiveEnemy.rbEnemy.AddForce(directionBullet * 1, ForceMode2D.Impulse);
            explosiveEnemy.ControlLifeEnemy(damageRocketLauncher * PowerFire.powerAditional);
            if (colliderEnemy != null && explosiveEnemy.lifeEnemy > 0)
            {
                Invoke("ContinueMovement", 0.25f);
            }
        }
    }

    private void ContinueMovement()
    {
        if (colliderEnemy.TryGetComponent(out Enemy01 enemy))
        {
            enemy.rbEnemy.AddForce(directionBullet * -6, ForceMode2D.Impulse);
        }
        else if (colliderEnemy.TryGetComponent(out ExplosiveEnemy explosiveEnemy))
        {
            explosiveEnemy.rbEnemy.AddForce(directionBullet * -1, ForceMode2D.Impulse);
        }


    }
}
