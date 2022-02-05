using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class playerController : MonoBehaviour
{
    public float movementSpeed = 4;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    public float jumpForce = 6;
    Animator anim;
    [SerializeField] int maxHealth = 10;
    [SerializeField] int currentHp;
    public HealthBar healthBar;
    bool isGrounded;
    public GameObject player;
    private void Start()
    {
        currentHp = maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);

    }

    private void Update()
    { // if (Input.GetKeyDown(KeyCode.Space))
      //   {

        //       TakeDamage(2);
        //   }
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        Walk();
        Jump();
        Vector3 characterScale = transform.localScale;
        transform.localScale = characterScale;
        // Die();

        if (transform.localScale.x < 1)
        {
            jumpForce = 5;
        }
        else
        {
            jumpForce = 6;
        }
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
            isGrounded = false;
        }
        else
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
            player.transform.parent = collision.gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        player.transform.parent = null;
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
    public void TakeDamage(int howmuch)
    {
        currentHp -= howmuch;
        healthBar.SetHealth(currentHp);
        Debug.Log($"{name} is hurt " + "HP is " + currentHp);

    }

    //public void Die()
    //{
    //    if (currentHp <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
