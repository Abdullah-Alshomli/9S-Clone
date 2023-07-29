using UnityEngine;


public class RotatingComponent : MonoBehaviour
{
    [SerializeField] private Vector3 Rotation;
    
    private void FixedUpdate()
    {
        transform.Rotate(Rotation);
    }
}
