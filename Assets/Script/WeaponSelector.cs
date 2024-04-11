using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gunName;
    [SerializeField] private TextMeshProUGUI gunDescription;
    [SerializeField] private TextMeshProUGUI priceItem;
    [SerializeField] private TextMeshProUGUI itemLocked;
    [SerializeField] private Image gunImage;
    [SerializeField] private Transform gunHolder;
    [SerializeField] private Button buttonSelect;
    [SerializeField] private Store store;
    public bool itemLock;

    public void DisplayWeapon(InfoItem gun)
    {
        ChangeInfoItem(gun);
        DestroyChild(gun);
    }

    public void LoadGuns(InfoItem gun)
    {
        StoreData storeData = SaveManager.LoadStoreData();
        ChangeInfoItem(gun);
        foreach (var item in storeData.weaponsData)
        {
            if (item.Key == gunName.text && item.Value)
            {
                ItemLocked(gun, "Select", true, false);
            }
            else if (!item.Value && item.Key == gunName.text)
            {
                ItemLocked(gun, "Locked", false, true);
            }
        }
        DestroyChild(gun);
    }

    public void LoadAbilities(InfoItem ability)
    {
        StoreData storeData = SaveManager.LoadStoreData();
        ChangeInfoItem(ability);
        foreach (var item in storeData.abilitiesData)
        { 
            if (item.Key == ability.name && item.Value)
            {
                ItemLocked(ability, "Select", true, false);
            }
            else if (item.Key == ability.name && !item.Value)
            {
                ItemLocked(ability, "Locked", false, true);
            }
        }
        DestroyChild(ability);
    }

    private void ChangeInfoItem(InfoItem gun)
    {
        gunName.text = gun.name;
        gunDescription.text = gun.description;
        gunImage.sprite = gun.imageItemStore;
        priceItem.text = gun.itemPrice.ToString();
    }
    private void DestroyChild(InfoItem gun)
    {
        if (gunHolder.childCount > 0)
        {
            Destroy(gunHolder.GetChild(0).gameObject);
        }

        Instantiate(gun.imageItemStore, gunHolder.position, gunHolder.rotation, gunHolder);
    }
    private void ItemLocked(InfoItem gun, string word, bool button, bool item)
    {
        itemLocked.text = word;
        buttonSelect.interactable = button;
        itemLock = item;
    }

}
