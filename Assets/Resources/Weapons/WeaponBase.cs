using System.Collections;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract float Delay { get; set; }
    public abstract void Upgrade();
    public abstract void Fire();

    private readonly string resourceFolder = "Weapons/";
    public Transform originLocation; 

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
            Fire();
        }
    }
    public GameObject getPrefab(string weaponPath)
    {
        //Note: interpolation was giving me a string with the operator in it ("$pathValue")
        return Resources.Load<GameObject>(resourceFolder + weaponPath);
    }
}
