using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5;

    [SerializeField] private PlayerInput PlayerInput;

    private Transform PlayerTransform;
    private Rigidbody Rb;

    private Vector3 SpeedVector = new(0, 0, 0);

    private void Start()
    {
        PlayerTransform = transform;
        Rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //moving the player
        Vector3 RaycastPostion = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        // Debug.DrawRay(RaycastPostion, PlayerInput.GetSpeedVectorNormalized() * 0.5f,Color.red);
        if (Physics.Raycast(RaycastPostion, PlayerInput.GetSpeedVectorNormalized(),out RaycastHit HitData,0.5f))
        {
            if (HitData.transform.gameObject.layer == Layers.Wall)
            {
                return;
            }
        }
        PlayerTransform.position += PlayerInput.GetSpeedVectorNormalized() * (MovementSpeed * Time.deltaTime) ;
        
    }
}