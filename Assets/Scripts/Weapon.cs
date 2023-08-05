using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    //System
    public static Weapon instance;

    //handler
    [SerializeField] private enum GunType {Semi , Burst , Auto}
    [SerializeField] private Transform _spawn;
    [SerializeField] private GunType gunType;

    private void Awake()
    {
        instance = this;
    }

    public void shoot()
    {
        Ray ray = new Ray(_spawn.position, _spawn.forward);
        RaycastHit hitInfo;
        float shotDistance = 20;

        if(Physics.Raycast(ray, out hitInfo, shotDistance))
        {
            shotDistance = hitInfo.distance;
        }
        Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red,1);
        
    }

    public void ShootContinuous()
    {
        if(gunType == GunType.Auto)
        {
            shoot();
        }
    }
}
