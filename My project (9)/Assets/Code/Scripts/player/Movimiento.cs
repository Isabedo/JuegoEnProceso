using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 3f;
    private float horizontal;
    private float vertical;
    
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direccion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direccion = new Vector2(horizontal, vertical);
        rb.linearVelocity = direccion * velocidad;
        Debug.Log("Velocidad asignada: " + (direccion * velocidad));
    }

    private void MovimientoPersonaje()
    {
        

    }
}
