using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : WeaponBase
{
 
    public override string Name => "Pistol";

    public override string Description => "Shoots in a straight line.";

    private float delay = 1f;
    public override float Delay { get => delay; set => delay = value; }

    public override void Upgrade()
    {
        Debug.Log("Upgrade Called");
    }

    public override void Fire()
    {
        Debug.Log(originLocation.position.ToString());
        Debug.Log("Fire called");
    }
}
