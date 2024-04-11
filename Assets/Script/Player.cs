using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    private float movx;
    private float movy;
    public float speed;
    public float lifePlayer;
    [SerializeField] private float lifeMax;
    private Renderer rend;
    private Animator animator;
    private bool damage;
    private bool playerDead;
    public bool isdead;

    void Start()
    {
        SpeedProjectile.speedAditional = 1;
        PowerFire.powerAditional = 1;
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lifePlayer = lifeMax;
        rend = GetComponent<Renderer>();
        isdead = false;
        playerDead = false;
    }
    void FixedUpdate()
    {
       if (!playerDead)
       {
            Movement();
       }
      
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ControlLifePlayer(5);
        }
    }

    public void Movement()
    {
        movx = Input.GetAxisRaw("Horizontal");
        movy = Input.GetAxisRaw("Vertical");
        rbPlayer.velocity = new Vector2(movx * speed, movy * speed);

        if (movx != 0) transform.localScale = new Vector3(movx, transform.localScale.y, transform.localScale.z);

        animator.SetBool("Walk", movx != 0 || movy != 0);

        if (!damage)
        {
            rend.material.color = Color.white;
        }

    }

    public void ControlLifePlayer(float damageToPlayer)
    {
        if (lifePlayer > 0)
        {
            lifePlayer -= damageToPlayer;
            rend.material.color = Color.red;
        }
        else
        {
            DeadPlayer();
        }
    }

    private void DeadPlayer()
    {
        playerDead = true;
        rbPlayer.velocity = Vector2.zero;
        animator.SetBool("DeadPlayer", true);
    }

    public void LifeRecoveredPlayer(float lifeRecovered)
    {
        if (!isdead)
        {
            lifePlayer += lifeRecovered;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "MiniBoss" || collision.tag == "BulletEnemy")
        {
            damage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        damage = false;
    }

    public void IsDeadPlayer()
    {
        isdead = true;
    }

}
