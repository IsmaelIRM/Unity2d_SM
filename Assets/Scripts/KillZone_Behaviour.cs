using UnityEngine;

public class KillZone_Behaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si lo que cae es el jugador...
        if (collision.CompareTag("Player"))
        {
            // Buscamos el script de vida
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.RecibirDano(999);
            }
        }
    }
}