using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UpAndDownMovmentComponent : MonoBehaviour
{
    [SerializeField] private float Speed = 0.2f;
    private bool GoUp = true;
    [SerializeField] private float Height = 0.5f;
    private Vector3 orgin;

    private void Start()
    {
        Height = transform.position.y + Height;
        orgin = transform.position;
    }


    void Update()
    {
        if (transform.position.y < Height && GoUp)
        {
            transform.position += new Vector3(0, Speed, 0) * Time.deltaTime;
        }
        else 
        {
            GoUp = false;
            transform.position -= new Vector3(0, Speed, 0) * Time.deltaTime;
            if (transform.position.y <= orgin.y)
            {
                GoUp = true;
            }
        }
    }
}
