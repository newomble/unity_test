using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public class ShootEventArgs : EventArgs
    {
        public Vector2 originPosition; 
    }

    public event EventHandler<ShootEventArgs> ShootEventHandler;

    private Transform sourceOriginPosition;

    void Awake()
    {
        //Gets the transform component of the GameObject the script is a component of
        sourceOriginPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        SendShootEvent();
    }

    private void SendShootEvent()
    {
        ShootEventHandler?.Invoke(this, new ShootEventArgs {
            originPosition = sourceOriginPosition.position
        });
    }
}
