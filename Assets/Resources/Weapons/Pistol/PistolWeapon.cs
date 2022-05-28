using UnityEngine;

public class PistolWeapon : WeaponBase
{
    private float delay = 1f;
    public override string Name => "Pistol";
    public override string PrefabPath => "Pistol/Bullet";

    public override string Description => "Shoots in a straight line.";

    public override float Delay { get => delay; set => delay = value; }


    public override void Upgrade()
    {
        Debug.Log("Upgrade Called");
    }
}
