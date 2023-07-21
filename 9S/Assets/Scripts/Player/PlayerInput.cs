using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 ScreenPosition;
    private Vector3 WorldPosition;
    
    private Vector3 SpeedVector = new Vector3(0, 0, 0);
    

    [SerializeField] private LayerMask LayersToHit;
    private Camera Camera;

    private void Start()
    {
        Camera = FindObjectOfType<Camera>();
    }

    public Vector3 GetSpeedVectorNormalized()
    {
        SpeedVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            SpeedVector.z = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            SpeedVector.z = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            SpeedVector.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            SpeedVector.x = -1;
        }
        
        SpeedVector = SpeedVector.normalized;
        return SpeedVector;
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
