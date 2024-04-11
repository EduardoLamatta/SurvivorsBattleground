using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangerMagicWeapon : MonoBehaviour
{
    public GameObject weaponsItem;
    [SerializeField] private GameObject abilitysItem;
    [SerializeField] private GameObject buttonShowWeapons;
    [SerializeField] private GameObject buttonShowAbilitys;
    [SerializeField] private GameObject buttonPlay;
    [SerializeField] private string[] weapons;
    [SerializeField] private TextMeshProUGUI gunTextWeapon;
    [SerializeField] private TextMeshProUGUI abilityText;
    [SerializeField] private Store store;
    public static Dictionary<string, bool> selectedGun = new Dictionary<string, bool>();
    private string weaponName, abilityName;
    private int numWeapon, numAbility;
    [SerializeField] private Button buttonWeaponSelector, buttonAbilitySelector;
    [SerializeField] WeaponSelector[] weaponSelector;
    private int weaponsBought, abilityBought;
    private void Start()
    {
        numAbility = 0;
        numWeapon = 0;

        foreach (string nameWeapon in weapons)
        {
            selectedGun[nameWeapon] = false;
        }

        StoreData storeData = SaveManager.LoadStoreData();

        foreach (var weapon in storeData.weaponsData)
        {
            if (weapon.Value) weaponsBought++;
        }
        foreach (var ability in storeData.abilitiesData)
        {
            if (ability.Value) abilityBought++;
        }
    }
    void Update()
    {
        weaponName = gunTextWeapon.text;
        abilityName = abilityText.text;

        ShowButtonsAttacks();

        if (selectedGun.ContainsKey(weaponName))
        {
            bool value = selectedGun[weaponName];
            if (value || weaponSelector[0].itemLock) buttonWeaponSelector.interactable = false;
            else if (value || !weaponSelector[0].itemLock) buttonWeaponSelector.interactable = true;
        }

        if (selectedGun.ContainsKey(abilityName))
        {
            bool value = selectedGun[abilityName];
            if (value || weaponSelector[1].itemLock) buttonAbilitySelector.interactable = false;
            else if (value || weaponSelector[1].itemLock) buttonAbilitySelector.interactable = true;
        }

    }

    private void ShowButtonsAttacks()
    {

        if (weaponsBought == 1)
        {
            if (abilityBought == 0)
            {
                if (numWeapon == 1)
                {
                    buttonShowAbilitys.SetActive(false);
                    buttonPlay.SetActive(true);
                    weaponsItem.SetActive(false);
                    buttonWeaponSelector.enabled = false;
                }
                else
                {
                    buttonPlay.SetActive(false);
                    buttonShowAbilitys.SetActive(false);
                }
            }
            else if (abilityBought > 0)
            {
                if (numWeapon == 1)
                {
                    buttonShowAbilitys.SetActive(true);
                    weaponsItem.SetActive(false);
                    buttonWeaponSelector.enabled = false;
                }
                else
                {
                    buttonShowAbilitys.SetActive(false);
                }
            }
        }

        else if (weaponsBought > 1)
        {
            if (abilityBought == 0)
            {
                if (numWeapon == 2)
                {
                    buttonShowAbilitys.SetActive(false);
                    buttonPlay.SetActive(true);
                    weaponsItem.SetActive(false);
                    buttonWeaponSelector.enabled = false;
                }
                else
                {
                    buttonPlay.SetActive(false);
                    buttonShowAbilitys.SetActive(false);
                }
            }
            else if (abilityBought > 0)
            {
                if (numWeapon == 2)
                {
                    buttonShowAbilitys.SetActive(true);
                    weaponsItem.SetActive(false);
                    buttonWeaponSelector.enabled = false;
                }
                else
                {
                    buttonShowAbilitys.SetActive(false);
                }
            }
        }

        if (abilityBought == 1)
        {
            if (numAbility == 1)
            {
                buttonPlay.SetActive(true);
                abilitysItem.SetActive(false);
            }
            else buttonPlay.SetActive(false);
        }
        else if (abilityBought > 1)
            {
                if (numAbility == 2)
                {
                    buttonPlay.SetActive(true);
                    abilitysItem.SetActive(false);
                }
                else buttonPlay.SetActive(false);
            }
    }

    public void ShowWeapons()
    {
        weaponsItem.SetActive(true);
        abilitysItem.SetActive(false);
        buttonShowWeapons.SetActive(false);
        AudioGameManager.Instance.SoundSelect();
    }

    public void ShowAbilitys()
    {
        weaponsItem.SetActive(false);
        abilitysItem.SetActive(true);
        buttonShowAbilitys.SetActive(false);
        numWeapon++;
        AudioGameManager.Instance.SoundSelect();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
        AudioGameManager.Instance.SoundSelect();
    }

    public void SelectWeapon()
    {
        if (selectedGun.ContainsKey(weaponName) && numWeapon < 2 && !selectedGun[weaponName])
        {
            numWeapon++;
            selectedGun[weaponName] = true;
            AudioGameManager.Instance.SoundSelect();
        }
    }
    public void SelectAbility()
    {
        if (selectedGun.ContainsKey(abilityName) && numAbility < 2 && !selectedGun[abilityName])
        {
            numAbility++;
            selectedGun[abilityName] = true;
            AudioGameManager.Instance.SoundSelect();
        }
    }

    public void BackMain()
    {
        SceneManager.LoadScene(0);
        AudioGameManager.Instance.SoundSelect();
    }

}