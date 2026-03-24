using UnityEngine;
using System; // Necesario para usar Action (Eventos)

public class GameManager : MonoBehaviour
{
    // EL TRUCO SINGLETON: Esto crea una instancia única accesible desde cualquier otro script
    public static GameManager Instance;

    public event Action OnCoinCollected;

    private int coinCount = 0;       // El conteo interno de monedas

    void Awake()
    {
        // Configurar el Singleton: Si no hay ningún GameManager, soy yo. Si ya hay otro, me destruyo.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Esta función la llamarán las monedas cuando las recojas
    [ContextMenu("Simular Recoger Moneda")]
    public void AddCoin() 
    {
        coinCount++; 
        // Disparamos el evento. El interrogante significa "¿Hay alguien escuchando? Si es así, avísale".
        OnCoinCollected?.Invoke();
    }
}