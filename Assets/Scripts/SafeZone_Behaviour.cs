using UnityEngine;

public class SafeZoneDetector : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si el jugador SALE del área del colisionador...
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡El jugador ha salido de la zona segura!");

            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            if (health != null)
            {
                // Muerte instantánea o quitar toda la vida
                health.RecibirDano(999);
            }
        }
    }
}