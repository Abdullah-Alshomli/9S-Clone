using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private float TimeToSpawn = 0.5f;
    private bool CanSpawn = true;
    private void Update()
    {
        TimeToSpawn -= Time.deltaTime;
        if (TimeToSpawn <= 0 && CanSpawn)
        {
            Instantiate(EnemyPrefab,transform.position,transform.rotation);
            CanSpawn = false;
            Destroy(gameObject);
        }
    }
}
