using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMovement Controller;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed = 2f;
    public float jumpforce = 7f; 
    private float horizontal;
    public PlayableDirector director;
    private Transform playerTransform; 



    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();

        if(GroundChecker.isGrounded)
        {

        }
    }
    
    private void FixedUpdate() 
    {
        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rb.velocity = new Vector2 (horizontal * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //playerTransform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0 , 0);
        //playerTransform.position += new Vector3 (1, 0 , 0) * horizontal * speed * Time.deltaTime;
        //playerTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);
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

        horizontal = Input.GetAxisRaw("Horizontal");
        jump();
    }
    
    void jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(playerTransform.up * jumpforce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
    }
}
