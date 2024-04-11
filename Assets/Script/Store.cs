using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private TextMeshProUGUI itemsName;
    private int totalCoins;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private int priceItem;
    public TextMeshProUGUI priceText;
    public Button buttonBuyItem;
    public Dictionary<string, bool> weaponsInInventary = new Dictionary<string, bool>();
    public Dictionary<string, bool> abilitiesInInventary = new Dictionary<string, bool>();
    public bool save;
    

    private void Awake()
    {
        Debug.Log(save);
        LoadData();
        SaveStart();
        Debug.Log(save);

        
    }

    void Update()
    {
        priceItem = int.Parse(priceText.text);
        textCoins.text = PlayerPrefs.GetInt("TotalCoins").ToString();
        totalCoins = PlayerPrefs.GetInt("TotalCoins");
        BuyAbilities();
        BuyWeapons();


        //Linea de Codigo de prueba
        if (Input.GetKeyDown(KeyCode.H))
        {
            FuntionSaveTest();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerPrefs.SetInt("TotalCoins", 0);
            SaveManager.DeleteStoreData();
        }

    }

    private void BuyAbilities()
    {
        foreach (var ability in abilitiesInInventary)
        {
            if (abilitiesInInventary.ContainsKey(itemsName.text))
            {
                if (!abilitiesInInventary[itemsName.text])
                {
                    buttonText.text = "Buy Item";
                    if (priceItem > totalCoins) buttonBuyItem.interactable = false;
                    else buttonBuyItem.interactable = true;
                }
                else
                {
                    buttonText.text = "Sold";
                    buttonBuyItem.interactable = false;
                }

            }

        }
    }
    private void BuyWeapons()
    {
        foreach (var weapon in weaponsInInventary)
        {
            if (weaponsInInventary.ContainsKey(itemsName.text))
            {
                if (!weaponsInInventary[itemsName.text])
                {
                    buttonText.text = "Buy Item";
                    if (priceItem > totalCoins) buttonBuyItem.interactable = false;
                    else buttonBuyItem.interactable = true;
                }
                else
                {
                    buttonText.text = "Sold";
                    buttonBuyItem.interactable = false;
                }
            }
                

        }
    }

    public void ExitStore()
    {
        SceneManager.LoadScene(0);
        AudioGameManager.Instance.SoundSelect();
    }

    public void BuyItem()
    {
        totalCoins -= priceItem;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        save = true;
        AudioGameManager.Instance.SoundSelect();

        foreach (var ability in abilitiesInInventary)
        {
            if (ability.Key == itemsName.text)
            {
                abilitiesInInventary[itemsName.text] = true;
                break;
            }
        }
        foreach (var weapon in weaponsInInventary)
        {
            if (weapon.Key == itemsName.text)
            {
                weaponsInInventary[itemsName.text] = true;
                break;
            }
        }
        SaveManager.SaveData(this);
    }


    public void LoadData()
    {
        StoreData storeData = SaveManager.LoadStoreData();

        save = storeData.saved;

        foreach (var item in storeData.abilitiesData)
        {
            abilitiesInInventary[item.Key] = item.Value;
        }
        foreach (var item in storeData.weaponsData)
        {
            weaponsInInventary[item.Key] = item.Value;
        }

    }
    public void SaveStart()
    {
        if (!save)
        {
            weaponsInInventary["NormalGun"] = false;
            weaponsInInventary["MachineGun"] = false;
            weaponsInInventary["ShootGun"] = false;
            weaponsInInventary["Flamethrower"] = false;
            weaponsInInventary["Rocket Launcher"] = false;
            abilitiesInInventary["Agility"] = false;
            abilitiesInInventary["Swiftload"] = false;
            abilitiesInInventary["BulletTurbo"] = false;
            abilitiesInInventary["PowerFire"] = false;
            abilitiesInInventary["Vitality"] = false;
            Debug.Log("gunsValue");
            save = true;
            SaveManager.SaveData(this);
        }
    }














    private void FuntionSaveTest()
    {
        save = false;
        PlayerPrefs.SetInt("TotalCoins", 0);
        foreach (var item in abilitiesInInventary)
        {
            if (item.Key == itemsName.text)
            {
                abilitiesInInventary[itemsName.text] = false;
                break;
            }
        }
        foreach (var item in weaponsInInventary)
        {
            if (item.Key == itemsName.text)
            {
                weaponsInInventary[itemsName.text] = false;
                break;
            }

        }
        SaveManager.SaveData(this);

        Debug.Log("save game _ 01");

    }
    
}
