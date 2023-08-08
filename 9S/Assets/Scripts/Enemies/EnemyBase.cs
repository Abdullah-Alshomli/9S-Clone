using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


/// <summary>
///  take damage from player bullet and have the base variable of all enemies
/// </summary>

public class EnemyBase : MonoBehaviour
{
    private GameObject player;
    
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject bulletDestroyable;
    [SerializeField] private GameObject bulletNonDestroyable;
    [SerializeField] protected bool twoBulletTypes = false;

    [SerializeField] private GameObject explosionAudioPlayer;
    
    private HPComponent _hpComponent;

    #region Propretis

        public bool TwoBulletTypes => twoBulletTypes;
        
        public GameObject Player
        {
            get => player;
            set => player = value;
        }
        
        public GameObject BulletNonDestroyable
        {
            get => bulletNonDestroyable;
            set => bulletNonDestroyable = value;
        }

        public GameObject BulletDestroyable
        {
            get => bulletDestroyable;
            set => bulletDestroyable = value;
        }
        
        public HPComponent HpComponent
        {
            get => _hpComponent;
            set => _hpComponent = value;
        }

    #endregion

    
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerInput>().gameObject;
        _hpComponent = GetComponent<HPComponent>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Layers.Player_Bullet)
        {
            int Damage = other.gameObject.GetComponent<Bullet>().Damage;
            _hpComponent.TakeDamage(Damage);
            if (_hpComponent.Hp <= 0)
            {
                if (explosionEffect)
                {
                    GameObject ExpEffect = Instantiate(explosionEffect, transform.position, transform.rotation);
                    Destroy(ExpEffect,3);
                }

                Destroy(gameObject);

            }
            
        }

        if (other.gameObject.layer == Layers.Player)
        {
            if (explosionEffect)
            {
                GameObject ExpEffect = Instantiate(explosionEffect, other.transform.position, other.transform.rotation);
                Destroy(ExpEffect,3);
            }


            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (explosionAudioPlayer)
        {
            Instantiate(explosionAudioPlayer,transform.position,transform.rotation);
        }

    }
}
