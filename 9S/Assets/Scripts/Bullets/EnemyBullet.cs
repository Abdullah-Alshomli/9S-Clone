using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] protected GameObject PlayerExplodeEffect;
    [SerializeField] private GameObject SparkEffect;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Layers.Player_Bullet)
        {
            // collided with a player bullet
            // TODO: add bullet destroyed sound 
            GameObject Spark = Instantiate(SparkEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(Spark,3);
            Destroy(gameObject);
            
        }
        else if (other.gameObject.layer == Layers.Player)
        {
            // collided with the player
            GameObject PlayerExplodeEffectPrefab = Instantiate(PlayerExplodeEffect, other.transform.position, other.transform.rotation);
            Destroy(PlayerExplodeEffectPrefab,3);
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
        else
        {
            GameObject Spark = Instantiate(SparkEffect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(Spark,3);
            Destroy(gameObject);
        }
    }
}
