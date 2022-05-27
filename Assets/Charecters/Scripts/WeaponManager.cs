using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public class ShootEventArgs : EventArgs
    {
        public Vector2 originPosition; 
    }

    public event EventHandler<ShootEventArgs> ShootEventHandler;

    private Transform parentTransform;
    private Timer shootTimer;

    void Awake()
    {
        //Gets the transform component of the GameObject the script is a component of
        parentTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine("SendShootEvents");
    }

    private IEnumerator SendShootEvents()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SendShootEvent();
        }
    }

    public void SendShootEvent()
    {
        Debug.Log("Send Event");
        ShootEventHandler?.Invoke(this, new ShootEventArgs {
            originPosition = parentTransform.position
        });
    }
}
