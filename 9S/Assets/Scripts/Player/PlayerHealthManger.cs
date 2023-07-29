using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManger : MonoBehaviour
{

    [SerializeField] private GameObject Cube1;
    [SerializeField] private GameObject Cube2;
    
    [SerializeField] private GameObject ExplotionEffect;
    private HPComponent _hpComponent;
    

    void Start()
    {
        _hpComponent = GetComponent<HPComponent>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_hpComponent.Hp <= 0)
        {
            GameObject ExpEffect = Instantiate(ExplotionEffect, transform.position, transform.rotation);
            Destroy(ExpEffect, 3);
            Destroy(gameObject);
        }

        if (_hpComponent.Hp <= 2)
        {
            Cube1.SetActive(false);
        }
        if (_hpComponent.Hp <= 1)
        {
            Cube2.SetActive(false);
        }
    }
}
