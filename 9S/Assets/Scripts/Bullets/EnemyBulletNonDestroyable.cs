using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletNonDestroyable : EnemyBullet
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Layers.Player)
        {
            // collided with the player
            GameObject PlayerExplodeEffectPrefab = Instantiate(SparkEffect, transform.position, transform.rotation);
            Destroy(PlayerExplodeEffectPrefab,2);
            other.gameObject.GetComponent<HPComponent>().TakeDamage(1);
            Destroy(gameObject);
            
        }

        else if (other.gameObject.layer == Layers.Wall)
        {
            GameObject PlayerExplodeEffectPrefab = Instantiate(SparkEffect, transform.position, transform.rotation);
            Destroy(PlayerExplodeEffectPrefab,2);
            Destroy(gameObject);
        }
    }
}
