using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : MonoBehaviour
{
    [SerializeField] private WeaponManager shootWeapons;
    [SerializeField] Transform weaponPrefab;
    void Awake()
    {
        shootWeapons.ShootEventHandler += this.ShootEventListener;
    }

    private void ShootEventListener(object sender, WeaponManager.ShootEventArgs e)
    {
        Debug.Log("Hit Shoot Listener");
        Instantiate(weaponPrefab, e.originPosition, Quaternion.identity);
    }
}
