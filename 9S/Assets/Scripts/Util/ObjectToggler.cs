using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    [SerializeField] private GameObject Object;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Object.activeSelf)
        {
            Object.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Object.SetActive(false);
            Time.timeScale = 1.2f;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1.2f;
    }
}
