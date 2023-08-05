using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;
    [SerializeField] private Transform _spawn;

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
}
