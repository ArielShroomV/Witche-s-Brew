using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer _renderer;
   // bool isGrounded;
  //  [SerializeField] Transform groundCheck;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float jumpSpeed = 5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
      //  if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))         
        {
       //     isGrounded = true;
        }
      // else { isGrounded = false; }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            _renderer.flipX = false;
           
                //animator.play("name for run") 
       }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            _renderer.flipX = true;
 // if (isGrounded)
            {
                //animator.play("name for run")
            }
        }
        else
        {
           
            rb.velocity = new Vector2(0, rb.velocity.y);
      //     if (isGrounded) { }
            //animator.play("name for idle")
        }

        if (Input.GetKey("space")) //+ && isGrounded) //keydown wont let her jump wtf 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            Debug.Log("jummmp");
            //animator.play("name for jump")
        }
    }

}
