using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [Header("Configuración del Sensor")]
    [Tooltip("Distancia desde el centro del personaje hasta sus pies")]
    public Vector2 offset = new Vector2(0f, -0.2f);
    public float groundCheckRadius = 0.04f;
    public LayerMask groundLayer;

    // Propiedad pública de solo lectura
    public bool IsGrounded;

    void Update()
    {
        // Calculamos la posición matemáticamente: Posición actual + nuestro desplazamiento
        Vector2 checkPosition = (Vector2)transform.position + offset;

        // Hacemos el círculo en esa posición calculada
        IsGrounded = Physics2D.OverlapCircle(checkPosition, groundCheckRadius, groundLayer);
    }

    // Como ya no hay un objeto físico para ver dónde está el detector,
    // usamos los Gizmos para dibujar un círculo rojo en el editor y poder ajustarlo visualmente.
    private void OnDrawGizmosSelected()
    {
        Vector2 checkPosition = (Vector2)transform.position + offset;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPosition, groundCheckRadius);
    }
}