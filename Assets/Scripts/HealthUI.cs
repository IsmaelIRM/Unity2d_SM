using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Para usar Listas

public class HealthUI : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject heartPrefab; // Tu prefab de la imagen del corazón (con el sprite lleno por defecto)
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    // Guardamos una lista de los corazones que hemos instanciado para modificarlos luego
    private List<Image> corazonesInstanciados = new List<Image>();

    void Start()
    {
        // 1. Nos suscribimos a los eventos del GameManager o PlayerManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStart += SetupInitialHearts; // Para instanciar al principio
            GameManager.Instance.OnHealthChanged += UpdateHearts;   // Para cambiar el sprite cuando te pegan
        }
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameStart -= SetupInitialHearts;
            GameManager.Instance.OnHealthChanged -= UpdateHearts;
        }
    }

    // Se ejecuta al empezar el nivel
    private void SetupInitialHearts(int maxHealth)
    {
        // Instanciamos tantos corazones como vida máxima tengamos
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject nuevoCorazon = Instantiate(heartPrefab, transform);
            // Guardamos el componente Image en nuestra lista para usarlo más tarde
            corazonesInstanciados.Add(nuevoCorazon.GetComponent<Image>());
        }
    }

    // Se ejecuta cada vez que recibes daño o te curas
    private void UpdateHearts(int currentHealth)
    {
        // Recorremos la lista de corazones que ya creamos al principio
        for (int i = 0; i < corazonesInstanciados.Count; i++)
        {
            if (i < currentHealth)
            {
                corazonesInstanciados[i].sprite = corazonLleno;
            }
            else
            {
                corazonesInstanciados[i].sprite = corazonVacio;
            }
        }
    }
}