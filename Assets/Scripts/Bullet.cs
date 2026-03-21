using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f; // Se destruye a los 2 segundos para no saturar la memoria
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // La bala siempre se mueve hacia "su derecha" local
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, lifeTime); 
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // 1. Si chocamos contra nuestro propio Jugador, ignoramos el choque y salimos
        if (hitInfo.CompareTag("Player"))
        {
            return; 
        }

        // 2. Buscamos si hemos chocado contra un Enemigo
        Enemy enemigo = hitInfo.GetComponent<Enemy>();
        if (enemigo != null)
        {
            enemigo.Morir();
        }

        // 3. Si es cualquier otra cosa (enemigo, suelo, pared...), la bala se destruye
        Destroy(gameObject); 
    }
}