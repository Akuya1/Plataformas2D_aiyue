using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{    
    PlayerMovement player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("knight").GetComponent<PlayerMovement>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.layer == 3)
        {
            player.isGrounded = true;
            player.anim.SetBool("Jump", false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    
    {
        if(col.gameObject.layer == 3)
        {
            player.isGrounded = false;
        }
    }
 
}
