using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_repaso : MonoBehaviour
{
    private Rigidbody2D rBody;
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
    }

    // Update se repite todo el tiempo por FPS del juego
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //el sprite del rogue rota izquierda/derecha
        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //en la posicion del game object, se crea un rayo el cual toca una layer, si es la que debe, la funcion actuara.
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //FixedUptade se repite x veces por FPS del juego, por defecto 50 aprox.
    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
    }
}
