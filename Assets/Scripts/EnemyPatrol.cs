using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidad = 2f;
    private bool moviendoDerecha = true;

    private Rigidbody2D rb;
    private GroundDetector detector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        detector = GetComponent<GroundDetector>();
    }

    void Update()
    {
        // 1. Movimiento constante
        rb.linearVelocityX = moviendoDerecha ? velocidad : -velocidad;
        Flip();

        // 2. Si el detector dice que NO hay suelo (IsGrounded es false), nos giramos
        if (!detector.CheckGrounded())
        {
            float direccion = transform.localScale.x;

            if (direccion >= 0) moviendoDerecha = false;
            else moviendoDerecha = true;
        }
    }
    void Flip()
    {
        if (moviendoDerecha)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}