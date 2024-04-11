using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObectsChanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private WeaponSelector weaponSelector;
    private int index;
    private void Awake()
    {
        ChangerScriptableObject(0);
    }
    public void ChangerScriptableObject(int change)
    {
        index += change;

        if (index < 0) index = scriptableObjects.Length - 1;
        else if (index > scriptableObjects.Length - 1) index = 0;

        if (weaponSelector != null) weaponSelector.DisplayWeapon((InfoItem)scriptableObjects[index]);
    }

}
