using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    public Vector2 spawnOffset = new Vector2(0.16f, -0.035f);   
    public GameObject bulletPrefab; // La plantilla de la bala
    [Header("Controles (Input System)")]
    public InputActionReference attackAction; // Reference to the Attack action (Button)


    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        attackAction.action.performed += ContextToShoot;
    }

    void ContextToShoot(InputAction.CallbackContext context)
    {
        float directionX = transform.localScale.x < 0 ? -1f : 1f;

        Vector2 actualSpawnPos = (Vector2)transform.position + new Vector2(spawnOffset.x * directionX, spawnOffset.y);
        
        GameObject bullet = Instantiate(original: bulletPrefab, position: actualSpawnPos, rotation: Quaternion.identity);

        if (directionX == -1f)
        {
            bullet.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Como ya no hay un objeto físico para ver dónde está el detector,
    // usamos los Gizmos para dibujar un círculo rojo en el editor y poder ajustarlo visualmente.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        // Dibujamos el punto derecho
        Gizmos.DrawWireSphere((Vector2)transform.position + spawnOffset, 0.1f);
        // Dibujamos el punto izquierdo
        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(-spawnOffset.x, spawnOffset.y), 0.1f);
    }
}