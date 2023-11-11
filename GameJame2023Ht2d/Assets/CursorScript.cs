using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 mousePosition;

    [SerializeField]
    private float moveSpeed = 5f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Use the new input system to get mouse position
        mousePosition = Mouse.current.position.ReadValue();

        // Convert screen space mouse position to world space
        Vector2 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y));

        // Move the GameObject towards the mouse position
        transform.position = Vector3.Lerp(transform.position, worldMousePosition, moveSpeed * Time.deltaTime);
    }
}
