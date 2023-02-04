using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float jumpTime;
    public float jumpTimeCounter;
 
    public bool grounded;
    public LayerMask whatIsGround;
    public bool stoppedJumping;


    public BoxCollider2D col;
    public Transform groundCheck;
    public float groundCheckRadius;

    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        //funcionapls...
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            stoppedJumping = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                //Saltaaaaa ctm!
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        //Mantener
        if ((Input.GetKey(KeyCode.W)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        //Soltar el boton de salto
        if (Input.GetKeyUp(KeyCode.W) && !grounded)
        {
            //Resetear Salto
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.IsTouch)

        grounded = true;
    }*/


}


