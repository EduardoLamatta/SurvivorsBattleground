using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMain : MonoBehaviour
{
    private float movx;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private string[] weaponNameString;
    [SerializeField] private TextMeshProUGUI textWeapon;
    private Dictionary<string, GameObject> weaponToShow = new Dictionary<string, GameObject>();
    [SerializeField] private ChangerMagicWeapon changerMagicWeapon;

    void Start()
    {
        for (int i = 0; i < weaponNameString.Length; i++)
        {
            weaponToShow[weaponNameString[i]] = weapons[i];
        }
    }
    void FixedUpdate()
    {
        string weaponName = textWeapon.text;
        movx = Input.GetAxisRaw("Horizontal");
        if (movx != 0) transform.localScale = new Vector3(movx * 2, transform.localScale.y, transform.localScale.z);
    
        if (changerMagicWeapon.weaponsItem.activeSelf)
        {
            if (weaponToShow.ContainsKey(weaponName))
            {
                for (int i = 0; i < weaponNameString.Length; i++)
                {
                    weapons[i].SetActive(false);
                }
                weaponToShow[weaponName].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < weaponNameString.Length; i++)
            {
                weapons[i].SetActive(false);
            }
        }

    
    }
}
