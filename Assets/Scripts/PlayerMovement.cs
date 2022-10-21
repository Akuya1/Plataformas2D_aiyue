using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float speed = 2f;
    public float jumpforce = 7f; 
    private float horizontal;
    private float vertical;
    public PlayableDirector director;
    private Transform playerTransform;
    public LayerMask ground; 
    public Transform groundSensor;
    public float sensorRadius;
    public bool isGrounded;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }
    
    private void FixedUpdate() 
    {
        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal == 0)
        {
            anim.SetBool("Run" , false);
        }  
        else if (horizontal == 1)
        {
            anim.SetBool("Run" , true); 
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal == -1)
        {
            anim.SetBool("Run" , true); 
            playerTransform.rotation = Quaternion.Euler(0, -180, 0);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

            anim.SetBool("Jump", true);
        }

        //Para acceder a esta instancia
        //GameManager.Instance.RestarVidas();
        //GameManager.Instance.vidas;
        //Global.nivel = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
    }
}
