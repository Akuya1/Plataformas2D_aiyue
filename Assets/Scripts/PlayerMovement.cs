using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5.5f;
    private float horizontal;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate() 
    {
        //la velocidad del Rigidbody es un vector que en el eje X, mueves en horizontal dependiendo de la velocidad(multiplica)
        rb.velocity = new Vector2 (horizontal * speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //playerTransform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0 , 0);
        //playerTransform.position += new Vector3 (1, 0 , 0) * horizontal * speed * Time.deltaTime;
        //playerTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);
    }
}
