using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : EnemyCharacter
{
    public float speed;
    private bool nearly = false;
    [SerializeField] AudioClip audioExplosion;
    [SerializeField] private float volumen;

    private void OnEnable()
    {
        nearly = false;
    }
    void Update()
    {
      
         float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (!nearly)
        {
            if (distance > 0.2)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Flamethrower.velocityLow * Time.deltaTime);
            }
            else
            {
                animator.SetBool("Quiet", true);
                Invoke("ExplosionAnimation", 0.5f);
            }
        }

        base.LookPlayer();

        

    }

    private void ExplosionAnimation()
    {
        animator.SetTrigger("Explosion");
        if (!nearly)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(audioExplosion, volumen);
            nearly = true;
        }
    }

    public void ExplosionDead()
    {
        base.DeadEnemy();
        //gameObject.SetActive(false);
        
    }
}
