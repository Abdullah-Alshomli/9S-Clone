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
        PlayerTransform.position += PlayerInput.GetSpeedVectorNormalized() * (MovementSpeed * Time.deltaTime) ;

    }


}