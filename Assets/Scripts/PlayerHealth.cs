using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Estadísticas del Jugador")]
    public int maxHealth = 3; // ¡AQUÍ SE DEFINE! Puedes cambiarlo en el Inspector a 5, 10...
    private int currentHealth;

    IEnumerator Start()
    {
        currentHealth = maxHealth;

        // ESPERAMOS 1 FRAME: Esto garantiza que todos los demás scripts 
        // (como HealthUI) hayan terminado de ejecutar su Start() y estén suscritos.
        yield return null;

        // Usamos ?.Invoke() que es más seguro y moderno que comprobar OnGameStart != null
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStart?.Invoke(maxHealth);
        }
    }

    public void RecibirDano(int cantidadDano)
    {
        currentHealth -= cantidadDano;
        if (currentHealth < 0) currentHealth = 0;

        // Cambia la forma en la que llamas al evento por esta (?.Invoke):
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnHealthChanged?.Invoke(currentHealth);
        }

        if (currentHealth == 0)
        {
            Morir();
        }
    }

    [ContextMenu("Simular Morir")]
    private void Morir()
    {
        Debug.Log("El jugador ha muerto");
        // Aquí llamarías al evento de Game Over
        FindFirstObjectByType<UIManager>()?.MostrarGameOver();
        this.enabled = false;
    }
}