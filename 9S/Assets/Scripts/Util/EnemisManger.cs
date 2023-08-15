using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemisManger : MonoBehaviour
{

    [SerializeField] private int nextLvl;

    private float loadingDealy = 1;
    
    public static int numberOfEnemise = 0;

    private PlayerHealthManger PlayerHP;
    void Start()
    {
         PlayerHP = FindObjectOfType<PlayerHealthManger>().gameObject.GetComponent<PlayerHealthManger>();
         EnemyBase[] enemies = FindObjectsOfType<EnemyBase>();
         Spawner[] spawners = FindObjectsOfType<Spawner>();
         numberOfEnemise = enemies.Length + spawners.Length;
    }
    
    void Update()
    {
        if (numberOfEnemise <= 0 && PlayerHP.isAlive)
        {
            loadingDealy -= Time.deltaTime;
            if (loadingDealy <=0)
            {
                GoToLVL(nextLvl);
            }
        }
    }
    
    public void GoToLVL(int LVLNumber)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        // Destroy all remaining game objects
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
        
        string LVLName = "LVL " + LVLNumber;
        SceneManager.LoadScene(LVLName);
    }
}
