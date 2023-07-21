using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    [SerializeField] private GameObject ExplotionEffect;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Layers.Player)
        {
            GameObject ExpEffect = Instantiate(ExplotionEffect, other.transform.position,other.transform.rotation);
            Destroy(ExpEffect,3);
            Destroy(other.gameObject);
        }
    }
}
