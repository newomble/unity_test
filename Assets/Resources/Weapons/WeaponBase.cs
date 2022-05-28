using System.Collections;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public abstract string Name { get; }

    public abstract string Description { get; }

    public abstract float Delay { get; set; }

    /// <summary>
    /// Path to the projectile prefab. These must be in the Resources folder.
    /// EX:
    ///     If the real path is `{{Project}}/Resources/Weapons/Pistol/Bullet.prefab`. 
    ///     The prefab path is `Weapons/Pistol/Bullet`
    ///</summary>
    public abstract string PrefabPath { get; }

    private readonly string resourceFolder = "Weapons/";
    
    public Transform originLocation;

    public abstract void Upgrade();

    public void Init(Transform originLocation)
    {
        this.originLocation = originLocation;
    }

    public void StartRoutine()
    {
        StartCoroutine(nameof(ShootRoutine));
    }

    public void StopRoutine()
    {
        StopCoroutine(nameof(ShootRoutine));
    }

    public IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            GameObject weapon = getPrefab();
            Instantiate(weapon, originLocation.position, Quaternion.identity);
        }
    }
    private GameObject getPrefab()
    {
        //Note: interpolation was giving me a string with the operator in it ("$pathValue")
        return Resources.Load<GameObject>(resourceFolder + PrefabPath);
    }
}
