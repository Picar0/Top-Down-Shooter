using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    //System
    public static Weapon instance;

    //handler
    [SerializeField] private enum GunType { Semi, Burst, Auto }
    [SerializeField] private Transform _spawn;
    [SerializeField] private GunType gunType;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float autoShootTimerMax = .1f;

    private float autoShootTimer = 0f;

    private void Awake()
    {
        instance = this;
    }

    public void shoot()
    {
        Ray ray = new Ray(_spawn.position, _spawn.forward);
        RaycastHit hitInfo;
        float shotDistance = 20;

        if (Physics.Raycast(ray, out hitInfo, shotDistance))
        {
            shotDistance = hitInfo.distance;
        }
        // Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red,1);
        //* Spawn the bullet here with spawn points position and rotation
        Instantiate(bullet, _spawn.position, _spawn.rotation);


    }

    public void ShootContinuous()
    {
        if (gunType == GunType.Auto)
        {
            //? Increase the timer that is needed to shoot
            autoShootTimer += Time.deltaTime;
            if (autoShootTimer >= autoShootTimerMax)
            {
                //? Here timer was equal to the rate of fire
                autoShootTimer = 0f;
                shoot();
            }
        }
    }
}
