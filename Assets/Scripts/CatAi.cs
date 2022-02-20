using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAi : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    private Transform target;
    public float stoppingDistance;
    Vector3 direction;
    private Vector2 movement;
    public bool shouldRotate;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        anim.SetBool("isWalking", true);
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        direction = target.position - transform.position;
        //float angle = Mathf.Atan(direction.x, direction.y) * Mathf.Rad2Deg;
        //direction.normalized;
        //movement = direction;
            if (shouldRotate)
        {
            anim.SetFloat("X", direction.x);
            anim.SetFloat("Y", direction.y);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
