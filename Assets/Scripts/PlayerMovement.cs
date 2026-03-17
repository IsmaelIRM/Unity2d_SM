using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 7f;
    public float jumpForce = 14f;

    [Header("Detección de suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Controles (Input System)")]
    public InputActionReference moveAction; // Reference to the Move action (Vector2)
    public InputActionReference jumpAction; // Reference to the Jump action (Button)

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;
    private float horizontalInput;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        // Subscribe to the jump action event when the script is enabled
        jumpAction.action.performed += ContextToJump;
    }
    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks when the script is disabled/destroyed
        jumpAction.action.performed -= ContextToJump;
    }
    private void ContextToJump(InputAction.CallbackContext context)
    {
        // Saltar
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void Update()
    {
        // Comprobar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position, 
            groundCheckRadius, 
            groundLayer);

        // Leer el valor de movimiento
        // We assume "Move" is a Vector2 (like a thumbstick or WASD). We extract the X axis.
        horizontalInput = moveAction.action.ReadValue<Vector2>().x;

        // Voltear sprite según dirección
        if (horizontalInput > 0) sr.flipX = false;
        else if (horizontalInput < 0) sr.flipX = true;
    }
    void FixedUpdate()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
}