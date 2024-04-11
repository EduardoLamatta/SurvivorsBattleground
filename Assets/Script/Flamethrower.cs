using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private Vector2 worldPosition, direction;
    [SerializeField] private GameObject flames;
    [SerializeField] private float damage;
    [SerializeField] private Collider2D colliderFlames;
    private PanelController panelController;
    [HideInInspector] public Player player;
    [HideInInspector] public float distanceToPlayer;
    public AudioClip audioClip;
    public static float damageFlamethrower = 10;
    public static float velocityLow = 1;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        panelController = FindAnyObjectByType<PanelController>();
    }
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = worldPosition - (Vector2)transform.position;
        transform.right = direction;
        distanceToPlayer = Vector3.Distance(worldPosition, player.transform.position);

        if (Input.GetMouseButton(0) && !panelController.inPause && distanceToPlayer > 0.2 && !player.isdead)
        {
            flames.SetActive(true);
            colliderFlames.enabled = true;
        }
        else
        {
            FinishAnimation();
        }

        LookToward();
    }
  
    private void LookToward()
    {
        if (worldPosition.x - player.transform.position.x != 0)
        {
            if (worldPosition.x - player.transform.position.x > 0) GetComponentInParent<Transform>().localScale = new Vector3(0.4f * player.transform.localScale.x, 0.4f, 0.4f);
            else GetComponentInParent<Transform>().localScale = new Vector3(0.4f * player.transform.localScale.x, -0.4f, 0.4f);
        }
    }

    public void FinishAnimation()
    {
        flames.SetActive(false);
        colliderFlames.enabled = false;
    }





}
