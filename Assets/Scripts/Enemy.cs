using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform waypoint1;
    [SerializeField] Transform waypoint2;
    [SerializeField] state enemystate;
    Transform target;
    Rigidbody2D rb;
    GameObject player;
    [SerializeField] float moveSpeed;
    Vector3 DirectionToTarget;
    [SerializeField] int currentHp;
    private float timer;
    public Transform Player;

    private SpriteRenderer mySpriteRenderer;
    


    enum state
    {
        Patrol,
        Follow


    }

    //private void Awake()
    //{
    //    mySpriteRenderer = GetComponent<SpriteRenderer>();
    //}

    void Start()
    {
        target = waypoint1;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);
    }



    void Update()
    {
        timer += Time.deltaTime;
        switch (enemystate)
        {
            case state.Patrol:
                //  Debug.Log("I'm Patroling");
                Patrol();
                break;
            case state.Follow:
                //   Debug.Log("I'm Following");
                Follow();
                break;



        }



       // Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemystate = state.Follow;


        }
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            ApplyDamage(player, 1);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.velocity = Vector3.zero;
            enemystate = state.Patrol;

        }

    }
    void Patrol()
    {
        if (target == waypoint1)
        {
            if (Vector2.Distance(transform.position, target.position) < 1f)
            {
                target = waypoint2;
              //  mySpriteRenderer.flipX = true;
                
            }
        }
        if (target == waypoint2)
        {
            if (Vector2.Distance(transform.position, target.position) < 1f)
            {
                target = waypoint1;
             //   mySpriteRenderer.flipX = false;
               
            }

        }
        transform.position = Vector3.Lerp(transform.position, target.position, 1 * Time.deltaTime);
    }
    void Follow()
    {

        Vector3 temp = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        transform.position = Vector2.MoveTowards(transform.position, temp, moveSpeed * Time.deltaTime);

    }
    public void TakeDamage(int howmuch)
    {
        currentHp -= howmuch;
        Debug.Log($"{name} is hurt " + "HP is " + currentHp);

    }
    public void ApplyDamage(PlayerController player, int howmuch)
    {
        player.TakeDamage(howmuch);

    }
   // public void Die()
    //{
    //    if (currentHp <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
