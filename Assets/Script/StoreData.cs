using System.Collections.Generic;
using System.Diagnostics;

[System.Serializable]

public class StoreData
{
    public Dictionary<string, bool> weaponsData = new Dictionary<string, bool>();
    public Dictionary<string, bool> abilitiesData = new Dictionary<string, bool>();

    public bool saved;
    public StoreData(Store store)
    {
        saved = store.save;

        foreach (var item in store.abilitiesInInventary) 
        {
            abilitiesData[item.Key] = item.Value;
        }
        foreach (var item in store.weaponsInInventary)
        {
            weaponsData[item.Key] = item.Value;
        }

    }

}
