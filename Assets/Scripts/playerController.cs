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
    public Animator anim;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHp;
    public HealthBar healthBar;
    public GameObject player;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource hurtSound;
    [SerializeField] AudioSource runSound;
    GameObject GameOverCanvas;
    public bool canMove = true;

    void Awake()
    {
        if (FindObjectOfType<RetryLvl>() != null)
        GameOverCanvas = FindObjectOfType<RetryLvl>().gameObject;
    }
    private void Start()
    {
        currentHp = maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        canMove = true;
    }
    private void Update()
    {
        if (canMove)
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

            Walk();
            Jump();
        }

        Vector3 characterScale = transform.localScale;
        transform.localScale = characterScale;


        if (transform.localScale.x < 1)
        {
            jumpForce = 5;
        }
        else
        {
            jumpForce = 6;
        }
        Die();
    }
    private void Jump()
    {
        if (Input.GetButton("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            jumpSound.Play();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
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

            if (!runSound.isPlaying)
            {
                runSound.Play();
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalking", true && !isJumping);
            _renderer.flipX = false;

            if (!runSound.isPlaying)
            {
                runSound.Play();
            }

        }
        else
        {
            anim.SetBool("isWalking", false);
            runSound.Stop();
        }
        if (isJumping)
        {
            runSound.Stop();
        }
    }
    public void TakeDamage(int howmuch)
    {
        anim.SetTrigger("Hurt");
        hurtSound.Play();
        currentHp -= howmuch;
        healthBar.SetHealth(currentHp);
        Debug.Log($"{name} is hurt " + "HP is " + currentHp);

    }

    public void Die()
    {
        if (currentHp <= 0)
        {
            canMove = false;
            anim.SetTrigger("Dead");
            StartCoroutine(wait());

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        if (GameOverCanvas != null)
            GameOverCanvas.SetActive(true);
        Destroy(gameObject);

    }
 }
