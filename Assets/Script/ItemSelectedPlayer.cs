using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectedPlayer : MonoBehaviour
{
    [SerializeField] private string[] itemsPlayerName;
    [SerializeField] private GameObject[] itemsAbilities;
    [SerializeField] private GameObject[] itemsWeapons;
    [SerializeField] private GameObject[] itemsStartGame;
    private Dictionary<string, int> tagToIndexWeapons = new Dictionary<string, int>();
    private Dictionary<string, int> tagToIndexAbilities = new Dictionary<string, int>();
    public Dictionary<string, GameObject> itemsStart = new Dictionary<string, GameObject>();
    [SerializeField] private GameObject[] weaponsPosition;
    private int positionNextWeapon;
    [SerializeField] private int numWeapon;
    private Player player;
    private bool nextWeapon;
    void Awake()
    {
        tagToIndexWeapons["NormalGun"] = 0;
        tagToIndexWeapons["MachineGun"] = 1;
        tagToIndexWeapons["ShootGun"] = 2;
        tagToIndexWeapons["Flamethrower"] = 3;
        tagToIndexWeapons["Rocket Launcher"] = 4;

        tagToIndexAbilities["Agility"] = 0;
        tagToIndexAbilities["Swiftload"] = 1;
        tagToIndexAbilities["BulletTurbo"] = 2;
        tagToIndexAbilities["PowerFire"] = 3;
        tagToIndexAbilities["Vitality"] = 4;

        nextWeapon = false;

        for (int i = 0; i < itemsPlayerName.Length; i++)
        {
            itemsStart[itemsPlayerName[i]] = itemsStartGame[i];
        }

        foreach (var item in ChangerMagicWeapon.selectedGun)
        {
            if (item.Value)
            {
                ActivateItem(item.Key);
            }
        }
        player = GetComponent<Player>();

    }

    private void Update()
    {
        transform.position = FindAnyObjectByType<Player>().transform.position;

        ChangeWeapon();
        HiddentObjects();
    }

    private void ActivateItem(string itemName)
    {
        Instantiate(itemsStart[itemName], weaponsPosition[positionNextWeapon].transform.position, Quaternion.identity);
        positionNextWeapon++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemsDestructor itemsDestructor))
        {
            if (tagToIndexWeapons.TryGetValue(collision.tag, out int indexWeapons))
            {
                if (indexWeapons >= 0 && itemsStart.ContainsKey(collision.tag) && !itemsDestructor.collisionFlames)
                {
                    if (numWeapon < 1) itemsWeapons[indexWeapons].SetActive(true);
                    numWeapon++;
                    if (numWeapon > 1) nextWeapon = true;
                }

            }

            else if (tagToIndexAbilities.TryGetValue(collision.tag, out int indexAbilities))
            {
                if (indexAbilities >= 0 && itemsStart.ContainsKey(collision.tag) && !itemsDestructor.collisionFlames)
                {
                    itemsAbilities[indexAbilities].SetActive(true);
                }
            }
        }
    }

    private void ChangeWeapon()
    {
        foreach (var itemWeapon in ChangerMagicWeapon.selectedGun)
        {
            if (Input.GetKeyDown(KeyCode.Q) && itemWeapon.Value && nextWeapon)
            {
                foreach (var item in itemsWeapons)
                {
                    if (item.name == itemWeapon.Key  && !item.activeSelf)
                    {
                        item.SetActive(true);
                        break;
                    }
                    else if (item.activeSelf && item.name == itemWeapon.Key)
                    {
                        item.SetActive(false);
                        break;
                    }
                }
            }
        }

    }

    private void HiddentObjects()
    {
        if (player.lifePlayer <= 0)
        {
            for (int i = 0; i < itemsAbilities.Length; i++)
            {
                itemsAbilities[i].SetActive(false);
            }
            for (int i = 0; i < itemsWeapons.Length; i++)
            {
                itemsWeapons[i].SetActive(false);
            }
        }

    }

}
