using UnityEngine;

public class FallingObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 90f;  // Rotation speed in degrees per second

    void Update()
    {
        // Rotate around the Y axis for a dynamic look
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
