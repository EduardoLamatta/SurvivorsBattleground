using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFlames : MonoBehaviour
{
    private Collider2D colliderEnemy;
    [SerializeField] private float tiempoInactividadMaximo;
    private Vector3 posicionAnterior;
    private float tiempoInactivo;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        posicionAnterior = Input.mousePosition;
        tiempoInactivo = 0f;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        MouseMove();
    }

    private void MouseMove()
    {
        if (Input.mousePosition != posicionAnterior)
        {
            tiempoInactivo = 0f;
            posicionAnterior = Input.mousePosition;
            animator.SetBool("EndFlames", false);
        }
        else
        {
            tiempoInactivo += Time.deltaTime;

            if (tiempoInactivo >= tiempoInactividadMaximo)
            {
                animator.SetBool("EndFlames", true);
                audioSource.Stop();
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        colliderEnemy = collision;
        if (collision.TryGetComponent(out Enemy01 enemy))
        {
            enemy.ControlLifeEnemy(Flamethrower.damageFlamethrower * Time.deltaTime * PowerFire.powerAditional);

        }
        else if (collision.TryGetComponent(out ExplosiveEnemy explosiveEnemy) && colliderEnemy != null && explosiveEnemy.lifeEnemy > 0)
        {
            explosiveEnemy.ControlLifeEnemy(Flamethrower.damageFlamethrower * Time.deltaTime * PowerFire.powerAditional);
        }
    }
}
