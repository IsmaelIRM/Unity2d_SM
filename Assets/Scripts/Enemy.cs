using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private Collider2D coll;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Esta función la llamará la bala del jugador cuando le golpee
    public void Morir()
    {
        // 1. Desactivamos su caja de colisión para que no se coma más balas estando muerto
        if (coll != null) coll.enabled = false;

        // 2. Activamos la animación de muerte
        if (anim != null) anim.SetTrigger("Muerte");

        // // 3. Sumamos 1 al contador global
        // GameManager.enemigosEliminados++;
        // Debug.Log("¡Enemigo abatido! Total: " + GameManager.enemigosEliminados);

        // 4. Destruimos el objeto después de 1 segundo (ajusta este tiempo a lo que dure tu animación de muerte)
        Destroy(gameObject, 1f); 
    }
}