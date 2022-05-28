using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : WeaponBase
{
    private float delay = 1f;
    private string prefabPath = "Pistol/Pistol";

    public override string Name => "Pistol";

    public override string Description => "Shoots in a straight line.";

    public override float Delay { get => delay; set => delay = value; }

    public override void Upgrade()
    {
        Debug.Log("Upgrade Called");
    }

    public override void Fire()
    {
        GameObject pistol = getPrefab(prefabPath);
        Instantiate(pistol, originLocation.position, Quaternion.identity);
        /**
         * TODO:
         *   Add transform
         *   Figure out how to kill
         * */
    }
}
