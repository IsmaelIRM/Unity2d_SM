using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [Header("Configuración del Sensor")]
    public Vector2 offset = new Vector2(0f, -0.2f);
    public float groundCheckRadius = 0.04f;
    public LayerMask groundLayer;

    public bool IsGrounded;

    void Update()
    {
        // CORRECCIÓN: Multiplicamos el offset.x por la escala actual en X
        // Si el personaje se gira (scaleX = -1), el punto de detección también se gira
        float direccion = transform.localScale.x;
        Vector2 offsetCorregido = new Vector2(offset.x * direccion, offset.y);
        
        Vector2 checkPosition = (Vector2)transform.position + offsetCorregido;

        IsGrounded = Physics2D.OverlapCircle(checkPosition, groundCheckRadius, groundLayer);
    }

    public bool CheckGrounded()
    {
        // Calculamos la posición con la escala ACTUAL (justo después del Flip)
        float direccion = transform.localScale.x;
        Vector2 checkPosition = (Vector2)transform.position + new Vector2(offset.x * direccion, offset.y);

        // Devolvemos el resultado real en este preciso instante
        return Physics2D.OverlapCircle(checkPosition, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos() // Cambiado a OnDrawGizmos para verlo siempre
    {
        // Reflejamos la misma lógica en el Gizmo para que lo veas moverse en el Editor
        float direccion = transform.localScale.x;
        Vector2 offsetCorregido = new Vector2(offset.x * direccion, offset.y);
        
        Vector2 checkPosition = (Vector2)transform.position + offsetCorregido;
        
        Gizmos.color = IsGrounded ? Color.green : Color.red; // Cambia a verde si detecta suelo
        Gizmos.DrawWireSphere(checkPosition, groundCheckRadius);
    }
}