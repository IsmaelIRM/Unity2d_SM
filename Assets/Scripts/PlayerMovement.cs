using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 7f;
    public float jumpForce = 7f;

    [Header("Controles (Input System)")]
    public InputActionReference moveAction; // Reference to the Move action (Vector2)
    public InputActionReference jumpAction; // Reference to the Jump action (Button)

    private GroundDetector groundDetector;
    private Rigidbody2D rb;

    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();

    }
    void OnEnable()
    {
        // Subscribe to the jump action event when the script is enabled
        jumpAction.action.performed += ContextToJump;

        // Para el movimiento, necesitamos saber cuándo empieza/cambia (performed) y cuándo se suelta (canceled)
        moveAction.action.performed += ContextToMove;
        moveAction.action.canceled += ContextToMove;
    }

    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks when the script is disabled/destroyed
        jumpAction.action.performed -= ContextToJump; 
        moveAction.action.performed -= ContextToMove;
        moveAction.action.canceled -= ContextToMove;
    }

    private void ContextToJump(InputAction.CallbackContext context)
    {
        // Saltar
        if (groundDetector.IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    private void ContextToMove(InputAction.CallbackContext context)
    {
        // Cada vez que el jugador mueve el stick/teclas, o las suelta, actualizamos la variable
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    void FixedUpdate()
    {
        // Aplicamos la fuerza física real basada en si pulsaste A o D
        rb.linearVelocityX = horizontalInput * moveSpeed;
    }
}