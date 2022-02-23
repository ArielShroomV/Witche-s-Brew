using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTheEnd : MonoBehaviour
{
    [SerializeField] AudioSource runSound;
    private SpriteRenderer _renderer;
    public Animator anim;
    public int Speed = 5;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        Movment();
    }

    public void Movment()
    {
        var body = GetComponentInParent<Rigidbody2D>();
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontal * Speed, vertical * Speed);
       
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isWalking", true);
            _renderer.flipX = true;
            if (!runSound.isPlaying)
            {
                runSound.Play();
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalking", true);
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
    }

}
