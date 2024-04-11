using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{

    public Rigidbody2D rbEnemy;
    public Transform playerTransform;
    public Player player;
    public float speedEnemy;
    public float lifeEnemy, lifeMax;
    [SerializeField] private GameObject prefabCoin;
    [SerializeField] private GameObject prefabTreasure;
    public Animator animator;
    public PanelController panelController;
    [SerializeField] private float damageToPlayer;

    private void OnEnable()
    {
        lifeEnemy = lifeMax;
    }
    void Start()
    {
        playerTransform = FindAnyObjectByType<Player>().transform;
        player = FindAnyObjectByType<Player>();
        rbEnemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        panelController = FindAnyObjectByType<PanelController>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speedEnemy * Flamethrower.velocityLow * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, playerTransform.position) > 2.5f)
        {
            DestroyEnemy();
        }


        DeadEnemy();

        LookPlayer();
    }

    protected virtual void DeadEnemy()
    {
        if (lifeEnemy <= 0)
        {
            if (gameObject.tag == "Enemy") Coins();
            else if (gameObject.tag == "MiniBoss") Treasure();
            panelController.countKills++;
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        gameObject.SetActive(false); 
    }

    public void ControlLifeEnemy(float damage)
    {
        lifeEnemy -= damage;
        animator.SetTrigger("Damage");
    }

    protected virtual void LookPlayer()
    {
        if (transform.position.x - playerTransform.position.x > 0) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }

    private void Coins()
    {
        int num = Random.Range(0, 101);

        if (num < 30)
        {
            Instantiate(prefabCoin, transform.position, Quaternion.identity);
        }
    }
    private void Treasure()
    {
        int num = Random.Range(0, 101);

        if (num < 10)
        {
            Instantiate(prefabTreasure, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.ControlLifePlayer(damageToPlayer * Time.deltaTime);
        }
    }


}
