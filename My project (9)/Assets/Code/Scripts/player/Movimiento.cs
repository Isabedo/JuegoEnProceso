using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;
    private float horizontal;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direccion;

    [Header("Animaciones")]
    [SerializeField] private GameObject avatar;
    [SerializeField] private Animator animator;

    [Header("Salto")]
    [SerializeField] private float jumpForce= 10;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 tamañoCaja  =new Vector2 (0,0);
    [SerializeField] private Transform groundCheck;
    [SerializeField] private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = avatar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
        Salto();
        Animaciones();
    }

    private void MovimientoPersonaje()
    {
        horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        direccion = new Vector2(horizontal, 0);
        rb.linearVelocity = direccion * velocidad;
        Flip();
        
        

    }

    private void Flip()
    {
        Vector3 escala = transform.localScale;

        if (horizontal > 0)
        {
            Debug.Log("Velocidad asignada: " + (direccion * velocidad));
            escala.x = 1;
            transform.localScale = escala;
        }
        else if (horizontal < 0)
        {
            escala.x = -1; // o -1
            transform.localScale = escala;
        }
        
    }

    private void Salto()
    {
        //enSuelo = Physics2D.OverlapBox(groundCheck.position, tamañoCaja, 0f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y)<0.01f) 
        {
            Debug.Log("saltando");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheck.position, tamañoCaja);
        }
    }
    private void Animaciones()
    {
        animator.SetFloat("movimiento", direccion.sqrMagnitude);
        animator.SetBool("enSuelo", enSuelo);
    }
}
