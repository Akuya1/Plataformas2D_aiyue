using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_repaso : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;
    private float horizontal;
    //flechas de movimiento (horizontal)

    [SerializeField]private float speed = 4;
    [SerializeField]private float jumpForce = 10;

    [SerializeField]bool isGrounded;
    
    [SerializeField]Transform groundSensor;
    [SerializeField]float sensorRadius;
    [SerializeField]LayerMask sensorLayer;
    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update se repite todo el tiempo por FPS del juego
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //el sprite del rogue rota izquierda/derecha
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("isRunning", true);
        }
        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isRunning", true);
        }
        else if(horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }

        //en la posicion del game object, se crea un rayo el cual toca una layer, si es la que debe, la funcion actuara.
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Star")
        {
            GameManager_repaso.Instance.LoadLevel(1);
        }
        else if(other.gameObject.tag == "Coin")
        {
            GameManager_repaso.Instance.AddCoin(other.gameObject);
        }
    }

    //FixedUptade se repite x veces por FPS del juego, por defecto 50 aprox.
    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        //3 pq es la layer de ground en el inspector
        if(coll.gameObject.layer == 3)
        {
            anim.SetBool("isJumping", false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
    }
}
