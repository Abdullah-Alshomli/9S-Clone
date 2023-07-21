using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float MovementSpeed = 5;

    [SerializeField]
    private PlayerInput PlayerInput;
    
    private Transform PlayerTransform;
    private Rigidbody Rb;

    private Vector3 SpeedVector = new Vector3(0, 0, 0);
    
    private void Start()
    {
        PlayerTransform = transform;
        Rb = GetComponent<Rigidbody>();
    }
    

    private void Update()
    {
        //moving the player
        PlayerTransform.position += PlayerInput.GetSpeedVectorNormalized() * (MovementSpeed * Time.deltaTime);

        //SpeedVector = PlayerInput.GetSpeedVectorNormalized();
    }

    private void FixedUpdate()
    {
        //PlayerTransform.position += PlayerInput.GetSpeedVectorNormalized() * (MovementSpeed * Time.deltaTime);
        //Rb.MovePosition(transform.position + SpeedVector * (MovementSpeed * Time.deltaTime));
        
    }
}
