using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El jugador
    public float smoothSpeed = 5f;
    
    // Al poner X=0 e Y=0, la cámara apuntará al centro exacto del jugador
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Zoom (Mayor número = Más lejos)")]
    public float zoomSize = 8f; // El valor por defecto de Unity es 5

    void Start()
    {
        // Esto cambia automáticamente la amplitud de la cámara al iniciar
        if (Camera.main != null)
        {
            Camera.main.orthographicSize = zoomSize;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime);
            
        transform.position = smoothedPosition;
    }
}