using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float TimeToSpawn = 0.5f;
    [SerializeField] private GameObject SpawnEffect;
    [SerializeField] private GameObject EffectSpawnPoint;

    private bool CanSpawn = true;
    private void Update()
    {
        TimeToSpawn -= Time.deltaTime;
        if (TimeToSpawn <= 0 && CanSpawn)
        {
            GameObject effect = Instantiate(SpawnEffect, EffectSpawnPoint.transform.position,
                EffectSpawnPoint.transform.rotation);
            Invoke("SpawnEnemy",1.01f);
            CanSpawn = false;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab,transform.position,transform.rotation);
        
        Destroy(gameObject);
    }
}