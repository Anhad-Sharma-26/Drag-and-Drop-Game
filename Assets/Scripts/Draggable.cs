using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        rb.useGravity = false;
        rb.velocity = Vector3.zero; // Stop current movement
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPosition() + offset;
            // Only allow movement on X & Y (lock Z or set as needed)
            newPos.z = 0;
            transform.position = newPos;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.useGravity = true;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
