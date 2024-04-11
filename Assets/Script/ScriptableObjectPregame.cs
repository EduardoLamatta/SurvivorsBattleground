using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectPregame : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private WeaponSelector weaponSelector;
    private int index;
    private void Awake()
    {
        ChangerScriptableObjectWeaponsPregame(0);
        ChangerScriptableObjectAbilitiesPregame(0);
    }

    public void ChangerScriptableObjectWeaponsPregame(int change)
    {
        index += change;

        if (index < 0) index = scriptableObjects.Length - 1;
        else if (index > scriptableObjects.Length - 1) index = 0;

        if (weaponSelector != null) weaponSelector.LoadGuns((InfoItem)scriptableObjects[index]);
    }

    public void ChangerScriptableObjectAbilitiesPregame(int change)
    {
        index += change;

        if (index < 0) index = scriptableObjects.Length - 1;
        else if (index > scriptableObjects.Length - 1) index = 0;

        if (weaponSelector != null) weaponSelector.LoadAbilities((InfoItem)scriptableObjects[index]);
    }

    
}
