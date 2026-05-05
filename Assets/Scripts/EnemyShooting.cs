using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Ajustes de Bala")]
    public GameObject balaPrefab;
    public float cadenciaDisparo = 2f;
    private float tiempoSiguienteDisparo;

    [Header("Configuración del Punto de Disparo")]
    [Tooltip("Desplazamiento desde el centro del enemigo para disparar")]
    public Vector2 offsetDisparo = new Vector2(0.5f, 0f);

    [Header("Visión")]
    public float distanciaVista = 5f;
    public LayerMask capaJugador;

    void Update()
    {
        // 1. Calculamos la posición actual del "cañón" basándonos en el offset y la escala
        // Usamos transform.localScale.x para que el disparo cambie de lado si el enemigo gira
        Vector3 posicionDisparoReal = transform.position + new Vector3(offsetDisparo.x * transform.localScale.x, offsetDisparo.y, 0);

        // 2. Mirada: Raycast desde la posición calculada
        // El rayo también debe mirar hacia donde apunta el enemigo (transform.right)
        float scaleDirection = transform.localScale.x >= 0 ? 1 : -1;
        Vector2 direction = transform.right * scaleDirection;
        RaycastHit2D hit = Physics2D.Raycast(posicionDisparoReal, direction, distanciaVista, capaJugador);

        if (hit.collider != null)
        {
            if (Time.time >= tiempoSiguienteDisparo)
            {
                Disparar(posicionDisparoReal);
                tiempoSiguienteDisparo = Time.time + cadenciaDisparo;
            }
        }
    }

    void Disparar(Vector3 posicion)
    {
        float directionX = transform.localScale.x < 0 ? -1f : 1f;

        Vector2 actualSpawnPos = (Vector2)transform.position + new Vector2(offsetDisparo.x * directionX, offsetDisparo.y);

        GameObject bullet = Instantiate(original: balaPrefab, position: actualSpawnPos, rotation: Quaternion.identity);

        if (directionX == -1f)
        {
            bullet.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Dibujamos los Gizmos para que veas el punto de salida y el rango de visión
    private void OnDrawGizmos()
    {
        // Calculamos la posición igual que en el Update para que el Gizmo sea preciso
        float direccion = applicationIsPlaying ? transform.localScale.x : 1;
        // Nota: en el editor (sin Play), asumimos que mira a la derecha para poder ajustarlo
        Vector3 visualPos = transform.position + new Vector3(offsetDisparo.x, offsetDisparo.y, 0);

        // Si el juego está corriendo, usamos la escala real
        if (Application.isPlaying)
            visualPos = transform.position + new Vector3(offsetDisparo.x * transform.localScale.x, offsetDisparo.y, 0);

        // Punto de salida de la bala (Círculo azul)
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(visualPos, 0.1f);

        // Línea de visión (Línea amarilla)
        Gizmos.color = Color.yellow;
        Vector3 forward = Application.isPlaying ? transform.right : Vector3.right;
        Gizmos.DrawRay(visualPos, forward * distanciaVista);
    }

    // Propiedad auxiliar para saber si estamos en modo Play
    private bool applicationIsPlaying => Application.isPlaying;
}