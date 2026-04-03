using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GroundDetector groundDetector;
    private SpriteRenderer sr;

    void Start()
    {
        // Obtenemos las referencias a los componentes que est�n en el mismo GameObject (el Player)
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        groundDetector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        Flip();
        // 1. Animaci�n de Correr (Velocidad Horizontal)
        // Usamos Mathf.Abs para convertir n�meros negativos (ir a la izquierda) en positivos.
        // Al Animator solo le importa "cu�nto" te mueves, no hacia d�nde.
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
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