using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public int dano = 1;
    public float lifeTime = 3f;
    private Rigidbody2D rb;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        // La bala siempre se mueve hacia "su derecha" local
        rb.linearVelocity = transform.right * speed;
        // Se destruye sola tras unos segundos para no llenar la memoria
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
                return;

        if (collision.CompareTag("Player"))
        {
            // Buscamos el script de vida en el jugador y le quitamos vida
            collision.GetComponent<PlayerHealth>()?.RecibirDano(dano);
            Destroy(gameObject); // La bala desaparece al impactar
        }

        Destroy(gameObject);
        
    }
}