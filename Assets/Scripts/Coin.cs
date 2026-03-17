using UnityEngine;
public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador toca la moneda...
        if (other.CompareTag("Player"))
        {
            // Sumar punto al GameManager
            GameManager.Instance.AddCoin();
            // Destruir la moneda
            Destroy(gameObject);
        }
    }
}