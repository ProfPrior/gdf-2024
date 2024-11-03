using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Automatically add Rigidbody component if not already present.
public class PlayerController : MonoBehaviour {
    float speed = 7.0f;
    float rotationSpeed = 200.0f; 
    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen.
        Cursor.visible = false; // Hide cursor.
    }


    private void FixedUpdate() {
        HandleMovement();
        HandleRotation();
    }

    /// <summary>
    /// Physics-based movement of player. Uses the Legacy Input System to get vertical and horizontal input.
    /// </summary>
    private void HandleMovement() {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movementVertical = transform.forward * moveVertical * speed * Time.deltaTime;
        Vector3 movementHorizontal = transform.right * moveHorizontal * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movementVertical + movementHorizontal);
    }

    /// <summary>
    /// Physics-based rotation of player. Uses the Legacy Input System to get mouse input.
    /// </summary>
    private void HandleRotation() {
        // Rotate player based on mouse input.
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = Vector3.up * mouseX * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
