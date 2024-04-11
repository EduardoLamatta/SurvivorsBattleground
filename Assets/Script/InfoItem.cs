using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="StoreMain", menuName =("Templates/Item"))]
public class InfoItem : ScriptableObject
{
    public string itemName;
    public float itemPrice;
    public Sprite imageItemStore;
    public string description;

   

}
