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

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal"); 
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * movementSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            _renderer.flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            _renderer.flipX = false;
        }
        transform.localScale = characterScale;
    }

}
