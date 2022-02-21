using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MomDragon : MonoBehaviour
{
    public int maxHealth = 5;
    int currentHealth;

    public Transform playerCharacter;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform mouth;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector3[] positions;

    [SerializeField] private float speed = 10;
    [SerializeField] private float attackRange = 3;
    [SerializeField] private float timeBetweenShoot = 1;

    [SerializeField] AudioSource fireSneeze;
    private int index;
    private SpriteRenderer spriteRenderer;
    private DragonState _dragonState;
    private DragonState dragonState
    {
        set
        {
            _dragonState = value;
            switch (_dragonState)
            {
                case DragonState.patrol:
                    StopCoroutine(Attack());
                    StartCoroutine(Patrol());
                    break;
                case DragonState.attack:
                    StopCoroutine(Patrol());
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

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        //check if player is in range
        if (playerCharacter != null)
        {

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
            Die();
        }

    }

    void StopAttack()
    {
        animator.SetBool("IsAttacking", false);
    }

    IEnumerator Attack()
    {
        bool firstAttack = true;
        Quaternion currentLookDirection = Quaternion.identity;

        while (dragonState == DragonState.attack)
        {
            if (playerCharacter != null)
                if (transform.position.x - playerCharacter.position.x > 0f)
                {
                    currentLookDirection = new Quaternion(Quaternion.identity.x, -180, Quaternion.identity.z, 0);
                    transform.rotation = currentLookDirection;
                }
                else
                {
                    currentLookDirection = new Quaternion(Quaternion.identity.x, 0, Quaternion.identity.z, 0);
                    transform.rotation = currentLookDirection;
                }

            animator.SetBool("IsAttacking", true);
            if (!firstAttack) animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.2f);

            GameObject newFireball = Instantiate(fireball, mouth.position, Quaternion.identity);
            newFireball.transform.rotation = currentLookDirection;

            fireSneeze.Play();
            yield return new WaitForSeconds(timeBetweenShoot - 0.2f);
            StopAttack();
            firstAttack = false;
        }
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(1);

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

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
