using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 ScreenPosition;
    private Vector3 WorldPosition;
    
    
    

    [SerializeField] private LayerMask LayersToHit;
    private Camera Camera;

    private void Start()
    {
        Camera = FindObjectOfType<Camera>();
    }

    public Vector3 GetSpeedVectorNormalized()
    {
        Vector3 speedVector = new Vector3(0, 0, 0);
        
        if (Input.GetKey(KeyCode.W))
        {
            speedVector.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speedVector.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speedVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedVector.x = -1;
        }
        
        speedVector = speedVector.normalized;
        return speedVector;
    }
    
    

    private void Update()
    {
        
        if (Camera)
        {
            // the camera exists
            
            ScreenPosition = Input.mousePosition;
            Ray Ray = Camera.ScreenPointToRay(ScreenPosition);
            
            //checking for collision with the world 
            if (Physics.Raycast(Ray, out RaycastHit HitData,float.MaxValue, LayersToHit))
            {
                WorldPosition = HitData.point;
                WorldPosition.y = transform.position.y;
                transform.LookAt(WorldPosition);
                
            }
        } 

        
    }
}
