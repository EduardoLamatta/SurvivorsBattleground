using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManager
{
   public static void SaveData(Store store)
   {
        StoreData storeData = new StoreData(store);
        string dataPath = Application.persistentDataPath + "/store.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, storeData);
        fileStream.Close();
   }

    public static StoreData LoadStoreData()
    {
        string dataPath = Application.persistentDataPath + "/store.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream (dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            StoreData storedata = (StoreData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("loaded");
            return storedata;
        }
        else
        {
            Store store = new Store();
            StoreData storeData = new StoreData(store);
            FileStream fileStream = new FileStream(dataPath, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, storeData);
            fileStream.Close();
            Debug.Log("created_01");
            return storeData;
        }
    }
    public static void DeleteStoreData()
    {
        string dataPath = Application.persistentDataPath + "/store.save";
        File.Delete(dataPath);
        Debug.Log("eliminated");
    }
}
