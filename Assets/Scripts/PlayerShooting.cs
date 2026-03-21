using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Configuración de Disparo")]
    public Transform firePoint; // De dónde sale la bala (la punta del arma)
    public GameObject bulletPrefab; // La plantilla de la bala

    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // "Fire1" es el clic izquierdo del ratón o el Ctrl izquierdo por defecto
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. Avisamos al Animator
        anim.SetTrigger("Shoot");

        // 2. Creamos la bala en la posición del firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 3. ¿Hacia dónde miramos? Si el sprite está volteado, giramos la bala 180 grados
        if (sr.flipX)
        {
            bullet.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}