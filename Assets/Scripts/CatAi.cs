using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAi : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float speed;
    private Transform target;
    public float stoppingDistance;
    Vector2 movement;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
       
        Follow();


    }
    void Follow()
    {
        anim.SetBool("isWalking", true);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
