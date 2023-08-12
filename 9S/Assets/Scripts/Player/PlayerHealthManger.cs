using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerHealthManger : MonoBehaviour
{

    [SerializeField] private GameObject Cube1;
    [SerializeField] private GameObject Cube2;
    
    [SerializeField] private GameObject ExplotionEffect;
    private HPComponent _hpComponent;
    
    [SerializeField] private GameObject explosionAudioPlayer;

    [SerializeField] private int currentLvl;

    void Start()
    {
        _hpComponent = GetComponent<HPComponent>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_hpComponent.Hp <= 0)
        {
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
    
    
    
    private void OnDestroy()
    {
        Instantiate(explosionAudioPlayer,transform.position,transform.rotation);
        GameObject ExpEffect = Instantiate(ExplotionEffect, transform.position, transform.rotation);
        Destroy(ExpEffect, 3);
        if (EnemisManger.numberOfEnemise > 0 )
        {
            GoToLVL(currentLvl);
        }
        else if (currentLvl == 27 && _hpComponent.Hp > 0)
        {
            GoToLVL(28);
        }
    }
    
    public void GoToLVL(int LVLNumber)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        string LVLName = "LVL " + LVLNumber;
        SceneManager.LoadScene(LVLName);
    }
    
}
