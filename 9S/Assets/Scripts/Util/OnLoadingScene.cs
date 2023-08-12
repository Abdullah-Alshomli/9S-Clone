using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnLoadingScene : MonoBehaviour
{

    [SerializeField] private float countDownTime = 3f;

    [SerializeField] private TMP_Text CountTextMesh;

    private float gameSpeed = 1.2f;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    
    void Update()
    {
        
        countDownTime -= Time.unscaledDeltaTime;
        if (countDownTime > 0)
        {
            CountTextMesh.text = ((int)countDownTime).ToString();
        }
    
        if (countDownTime <= 0)
        {
            CountTextMesh.text = "GO";
            Time.timeScale = gameSpeed;
        }
    
        if (countDownTime <= -0.5f)
        {
            Destroy(gameObject);
        }
    }
}
