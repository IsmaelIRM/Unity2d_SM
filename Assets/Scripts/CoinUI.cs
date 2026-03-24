using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [Header("Configuración Visual")]
    public GameObject uiCoinPrefab; // Arrastra aquí tu Prefab del UI_CoinIcon

    void Start()
    {
        // Al empezar la partida, nos suscribimos al evento del GameManager
        // Le decimos: "Cuando avises de una moneda, ejecuta mi función CreateCoinIcon"
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinCollected += CreateCoinIcon;
        }
    }

    void OnDestroy()
    {
        // Por seguridad, si este contenedor se destruye, nos desuscribimos
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinCollected -= CreateCoinIcon;
        }
    }

    // Esta es la función que reacciona
    private void CreateCoinIcon()
    {
        // Instanciamos el icono. 
        // "transform" hace referencia a este mismo objeto (el CoinContainer), 
        // por lo que la moneda se crea automáticamente como hija y se coloca en fila.
        Instantiate(uiCoinPrefab, transform);
    }
}