using System.Collections;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract float Delay { get; set; }

    public Transform originLocation;

    public void Init(Transform originLocation)
    {
        this.originLocation = originLocation;
    }

    public abstract void Upgrade();

    public abstract void Fire();

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
}
