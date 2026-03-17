using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 7f;
    public float jumpForce = 14f;
    [Header("Detección de suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        // Comprobar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(
        groundCheck.position,
        groundCheckRadius,
        groundLayer);
        // Saltar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        // Voltear sprite según dirección
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0) sr.flipX = false;
        else if (h < 0) sr.flipX = true;
    }
    void FixedUpdate()
    {
        // Movimiento horizontal
        float h = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);
    }
}