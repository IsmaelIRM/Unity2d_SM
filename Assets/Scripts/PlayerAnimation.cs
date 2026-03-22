using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GroundDetector groundDetector;
    private SpriteRenderer sr;

    void Start()
    {
        // Obtenemos las referencias a los componentes que están en el mismo GameObject (el Player)
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        groundDetector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        Flip();
        // 1. Animación de Correr (Velocidad Horizontal)
        // Usamos Mathf.Abs para convertir números negativos (ir a la izquierda) en positivos.
        // Al Animator solo le importa "cuánto" te mueves, no hacia dónde.
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

        // 2. Animación de Saltar / Caer (Velocidad Vertical)
        // Si es mayor que 0, está subiendo. Si es menor, está cayendo.
        anim.SetFloat("VerticalVelocity", rb.linearVelocity.y);

        // 3. Animación de tocar el suelo
        // Le pasamos el valor exacto que calcula tu script de movimiento
        anim.SetBool("IsGrounded", groundDetector.IsGrounded);
    }

    void Flip()
    {
        if (rb.linearVelocity.x > 0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (rb.linearVelocity.x < -0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}