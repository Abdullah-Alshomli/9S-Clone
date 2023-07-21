using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : EnemyBase
{
    [SerializeField] private List<GameObject> BulletSpawnPoints;
    [SerializeField] private float Firerate = 2;
    private float FirerateDelay;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerInput>().gameObject;
        HpComponent = GetComponent<HPComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            if (CanShoot())
            {
                Shoot();
            }
        }
    }
    
    
    private bool CanShoot()
    {
        FirerateDelay = FirerateDelay - Time.deltaTime;
        if (FirerateDelay <= 0)
        {
            FirerateDelay = Firerate;
            return true;
        }

        return false;
    }
 
    private void Shoot()
    {
        foreach (GameObject BulletSpawnPoint in BulletSpawnPoints)
        {
            Instantiate(BulletDestroyable, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
        }
        
    }
    
}
