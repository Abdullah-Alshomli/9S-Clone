using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float Velocty = 30;
    [SerializeField] private float LivingTime = 5;

    [SerializeField] protected GameObject BulletHitEffect;
    [SerializeField] public int Damage = 1;

    [SerializeField] private GameObject HitAudioPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,LivingTime);
        // TODO: add bullet shot sound
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (Velocty * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Layers.Ground)
        {
            Instantiate(HitAudioPlayer,transform.position,transform.rotation);
        }
        
        if (other.gameObject.layer != Layers.Player_Bullet && other.gameObject.layer != Layers.Player && other.gameObject.tag != "non")
        {
            Destroy(gameObject);
            
            // TODO: add bullet destroyed sound 
            
            // spawn bullet Hit something effect 
            GameObject ExplodeEffect = Instantiate(BulletHitEffect, transform.position, transform.rotation);
            Destroy(ExplodeEffect,2);
            
        }
    }
    
}
