using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class playerController : MonoBehaviour
{
    public float movementSpeed = 4;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    public float jumpForce = 5;
    Animator anim;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        Walk();
        Jump();
        Vector3 characterScale = transform.localScale;
        transform.localScale = characterScale;

    }
    private void Jump()
    {
        if (Input.GetButton("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (_rigidbody.velocity.y != 0)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void Walk()
    {
        var isJumping = anim.GetBool("isJumping");

        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isWalking", true && !isJumping);
            _renderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalking", true && !isJumping);
            _renderer.flipX = false;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }


}
