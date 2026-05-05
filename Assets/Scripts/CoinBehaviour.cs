using System;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Buscamos el script de vida en el jugador y le quitamos vida
            if (GameManager.Instance == null)
            {
                Console.WriteLine("Error al leer GameManager.");
            }
            GameManager.Instance.AddCoin();
            Destroy(gameObject); // La bala desaparece al impactar
        }
    }
}