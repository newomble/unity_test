using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public bool WeaponsActive { get; set; }

    private Dictionary<string, IWeapon> weapons;
    private Transform parentTransform;

    void Awake()
    {
        //Gets the transform component of the GameObject the script is a component of
        parentTransform = GetComponent<Transform>();
        weapons = new Dictionary<string, IWeapon>();
        WeaponsActive = true;
    }

    private void Start()
    {
        PistolWeapon pistol = gameObject.AddComponent<PistolWeapon>();
        AddWeapon(pistol);
    }

    public void AddWeapon(IWeapon newWeapon)
    {
        if (weapons.ContainsKey(newWeapon.Name)) {
            weapons[newWeapon.Name].Upgrade();
        } 
        else
        {
            InitWeapon(newWeapon);
            weapons.Add(newWeapon.Name, newWeapon);
        }
    }

    public void StartAllWeapons()
    {
        WeaponsActive = true;
        foreach (KeyValuePair<string, IWeapon> weapon in weapons)
        {
            weapon.Value.StartRoutine();
        }
    }

    public void StopAllWeapons()
    {
        WeaponsActive = false;
        foreach (KeyValuePair<string, IWeapon> weapon in weapons)
        {
            weapon.Value.StopRoutine();
        }
    }

    private void InitWeapon(IWeapon weapon)
    {
        weapon.Init(parentTransform);
        if (WeaponsActive)
        {
            weapon.StartRoutine();
        }
    }
}
