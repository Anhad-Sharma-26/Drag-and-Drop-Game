using UnityEngine;

public class FallingObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 90f;  

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
