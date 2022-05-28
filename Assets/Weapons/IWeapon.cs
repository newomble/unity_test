using UnityEngine;

public interface IWeapon
{
    string Name { get; }
    string Description { get; }
    float Delay { get; set; }

    void Init(Transform originLocation);
    void StartRoutine();
    void StopRoutine();
    void Fire();
    void Upgrade();
}
