using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// attack the player 
/// </summary>

public class Hunter : EnemyBase
{
    
    [SerializeField] private GameObject BulletSpawnPoint;
    [SerializeField] private float ShootRange;
    [SerializeField] private float Firerate = 2;
    private float FirerateDelay;


    void Start()
    {
        Player = FindObjectOfType<PlayerInput>().gameObject;
        HpComponent = GetComponent<HPComponent>();
        FirerateDelay = Firerate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            // Player is not destroyed
            transform.LookAt(Player.transform);
            
            if (CanShoot())
            {
                Shoot();
            }
        }
    }
    
    
    private bool CanShoot()
    {
        FirerateDelay = FirerateDelay - Time.deltaTime;
        if (Vector3.Distance(Player.transform.position, transform.position) <= ShootRange && FirerateDelay <= 0)
        {
            FirerateDelay = Firerate;
            return true;
        }

        return false;
    }
 
    private void Shoot()
    {
        Instantiate(BulletDestroyable, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
    }
}
