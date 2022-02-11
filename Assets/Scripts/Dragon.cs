using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Dragon : MonoBehaviour
{
   [SerializeField] private Animator animator;
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform mouth;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float speed;
   [SerializeField] private Vector3[] positions;
    private int index;
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;
    
    

    public GameObject Projectile { get => projectile; set => projectile = value; }



    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        
    }
    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }
    public void Shoot()
    {
        GameObject go = Instantiate(fireball, mouth.position, Quaternion.identity);
        Vector3 direction = new Vector3(transform.localScale.x, 0);
        go.GetComponent<Projectile>().Setup(direction);
    }

}
