using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DieAfterAll : MonoBehaviour
{
    [SerializeField] private GameObject MainEnemy;
    [SerializeField] private List<GameObject> Enemies;

    private void Start()
    {
        MainEnemy.GetComponent<HPComponent>().IsActive = false;
    }

    void Update()
    {
        float DeadEnemis = 0;

        foreach (var Enemy in Enemies)
        {
            if (Enemy.IsDestroyed())
            {
                DeadEnemis++;
            }
        }
        if (Enemies.Count == DeadEnemis)
        {
            MainEnemy.GetComponent<HPComponent>().IsActive = true;
            Destroy(gameObject);
        }
    }
}
