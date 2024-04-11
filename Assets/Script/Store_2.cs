using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_2 : MonoBehaviour
{
    void Start()
    {
        Store store = new Store();

        store.LoadData();
        store.SaveStart();
    }

}
