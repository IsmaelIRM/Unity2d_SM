using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar niveles

public class UIManager : MonoBehaviour
{
    public GameObject panelGameOver;

    void Start()
    {
        // Nos suscribimos al evento de muerte del jugador si lo tienes, 
        // o podemos usar un método público.
        panelGameOver.SetActive(false);
    }

    public void MostrarGameOver()
    {
        panelGameOver.SetActive(true);

        // Congelamos el tiempo del juego para que los enemigos no sigan moviéndose
        Time.timeScale = 0f;
    }

    // Función para el botón de Reiniciar
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // ¡IMPORTANTE! Devolver el tiempo a la normalidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}