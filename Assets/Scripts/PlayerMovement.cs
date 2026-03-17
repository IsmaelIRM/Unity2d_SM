using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 7f;
    public float jumpForce = 14f;

    [Header("Detección de suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim; 

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        // 1. Comprueba si tocamos el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 2. SALTO: "Jump" en Unity es la barra espaciadora por defecto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 3. MOVIMIENTO: "Horizontal" lee automáticamente la A (-1) y la D (1)
        float h = Input.GetAxisRaw("Horizontal");
        
        // Volteamos el sprite según la dirección
        if (h > 0) sr.flipX = false;
        else if (h < 0) sr.flipX = true;

        // Le pasamos la velocidad al Animator para que cambie de Idle a Run
        anim.SetFloat("Speed", Mathf.Abs(h));
    }

    void FixedUpdate()
    {
        // Aplicamos la fuerza física real basada en si pulsaste A o D
        float h = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);
    }
}