using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float Firerate = 0.2f;

    [SerializeField] private GameObject BulletSpawnPoint;
    private float FirerateDelay;
    private bool CanFire = true;

    private bool IsPoweredUp = false;
    private float PowerUpTime = 0;
    [SerializeField] private float PowerUpTimeControl = 10;

    private void Start()
    {
        FirerateDelay = Firerate;
    }

    private void Shoot()
    {
        
        Instantiate(BulletPrefab, BulletSpawnPoint.transform.position, transform.rotation);
    }

    private void Update()
    {
        if ((Input.GetMouseButton(0) && CanFire) || (IsPoweredUp && Input.GetMouseButton(0)))
        {
            Shoot();
            CanFire = false;
        }

        if (!CanFire)
        {
            FirerateDelay = FirerateDelay - Time.deltaTime;
        }

        if (FirerateDelay <= 0)
        {
            CanFire = true;
            FirerateDelay = Firerate;
        }

        if (PowerUpTime > 0)
        {
            PowerUpTime -= Time.deltaTime;
        }
        else
        {
            IsPoweredUp = false;
        }

    }

    private void PowerUp()
    {
        IsPoweredUp = true;
        PowerUpTime = PowerUpTimeControl;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Layers.PowerUp)
        {
            Destroy(other.gameObject);
            PowerUp();
        }
    }
}