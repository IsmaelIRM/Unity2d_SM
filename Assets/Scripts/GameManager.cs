using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Singleton: instancia única accesible desde cualquier script
    public static GameManager Instance;
    [Header("UI")]
    public TextMeshProUGUI coinText;
    public GameObject winPanel;
    private int coinCount = 0;
    void Awake()
    {
        // Configurar el Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
        UpdateCoinUI();
    }
    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();
    }
    public void Win()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }
    public void Respawn(Transform player, Vector3 startPos)
    {
        player.position = startPos;
    }
    private void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = "Monedas: " + coinCount;
    }
}