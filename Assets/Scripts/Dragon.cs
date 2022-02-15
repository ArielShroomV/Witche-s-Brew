using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DragonState
{
    patrol,
    attack
}

[RequireComponent(typeof(SpriteRenderer))]
public class Dragon : MonoBehaviour
{
    public Transform playerCharacter;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform mouth;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector3[] positions;

    [SerializeField] private float speed = 10;
    [SerializeField] private float attackRange = 3;
    [SerializeField] private float timeBetweenShoot = 1;

    private int index;
    private SpriteRenderer spriteRenderer;
    private DragonState _dragonState;
    private DragonState dragonState
    {
        set
        {
            _dragonState = value;
            if (value != _dragonState)
                switch (_dragonState)
                {
                    case DragonState.patrol:
                        StartCoroutine(Patrol());
                        break;
                    case DragonState.attack:
                        StartCoroutine(Attack());
                        break;
                }
        }
        get
        {
            return _dragonState;
        }
    }
    public GameObject Projectile { get => projectile; set => projectile = value; }

    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        transform.position = positions[index];
        StartCoroutine(Patrol());
    }


    void Update()
    {
        //check if player is in range
        if (Vector2.Distance(transform.position, playerCharacter.position) < attackRange)
        {
            if (dragonState != DragonState.attack)
            {
                dragonState = DragonState.attack;
            }
        }
        else if (dragonState != DragonState.patrol)
        {
            dragonState = DragonState.patrol;
        }
    }

    void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    IEnumerator Attack()
    {
        while (dragonState == DragonState.attack)
        {
            if (transform.position.x - playerCharacter.position.x > 0f)
            {
                transform.rotation = new Quaternion(Quaternion.identity.x, -180, Quaternion.identity.z, 0);
            }
            else
            {
                transform.rotation = new Quaternion(Quaternion.identity.x, 0, Quaternion.identity.z, 0);
            }

            animator.SetBool("Attack", true);
            Instantiate(fireball, mouth.position, Quaternion.identity);
            StopAttack();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
       
    }

    IEnumerator Patrol()
    {
        while (dragonState == DragonState.patrol)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

            if (transform.position.x - positions[index].x > 0f)
            {
                transform.rotation = new Quaternion(Quaternion.identity.x, -180, Quaternion.identity.z, Quaternion.identity.w);
            }
            else
            {
                transform.rotation = new Quaternion(Quaternion.identity.x, 0, Quaternion.identity.z, Quaternion.identity.w);
            }

            if (Vector2.Distance(transform.position, positions[index]) < 0.2f)
            {
                if (index >= positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            yield return null;
        }
        
    }
}
