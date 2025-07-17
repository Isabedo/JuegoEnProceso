using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo;     // Jugador o cualquier objeto a seguir
    public float suavizado = 0.125f; // Qué tan suave se mueve la cámara (opcional)
    public Vector3 offset;         // Desfase opcional de la cámara

    public Vector3 cameraLimiteIzquierdo = new Vector3 (3.4f, 0, 0);
    public Vector3 cameraLimiteDerecho = new Vector3(53.4f, 0, 0);
    void LateUpdate()
    {
        if (objetivo == null) return;

        // Solo seguimos en el eje X, mantenemos Y y Z actuales
        Vector3 posicionActual = transform.position;
        Vector3 posicionDeseada = new Vector3(objetivo.position.x + offset.x, posicionActual.y, posicionActual.z + offset.z);

        // Suavizado (opcional)
        transform.position = Vector3.Lerp(posicionActual, posicionDeseada, suavizado);
    }

    private void Start()
    {
        this.transform.position = new Vector3(objetivo.position.x, objetivo.position.y, objetivo.position.z + -10f);

    }

    private void LimitesCamara()
    {
        if(this.transform.position.x == 3.4)
        {
            this.transform.position = new Vector3(3.4f, this.transform.position.y, this.transform.position.z);
        }
    }
}
