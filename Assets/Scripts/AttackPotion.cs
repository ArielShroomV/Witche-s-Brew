using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackPotion : MonoBehaviour
{
    [SerializeField] playerController player;
    public Transform attackPoint;
    public int attackDamage = 5;
    public float attackRange = 2f;
    public LayerMask enemyLayers;
    public int usecounter = 4;
    public GameObject potion;
    [SerializeField] AudioSource iceAttack;
    public GameObject attackpotion;

    public TextMeshProUGUI countText;
    private int count;

    private void Awake()
    {
        count = 5;
    }
    private void Update()
    {
        if (attackpotion.activeInHierarchy)
        {
            Potion();
        }

    }
    public void Potion()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InitPower();
        }
    }
    public void InitPower()
    {
        if (usecounter >= 0)
        {
            potion.SetActive(true);
            StartCoroutine(wait());

        }
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Dragon>().TakeDamage(attackDamage);
        }
    }
    IEnumerator wait()
    {
        player.canMove = false;
        player.anim.SetTrigger("Attack");
        iceAttack.Play();
        Attack();
        yield return new WaitForSeconds(0.9f);
        SetCountText();
        player.canMove = true;
        usecounter--;

        if (usecounter == 0)
        {

            potion.SetActive(false);
            countText.gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void SetCountText()
    {
        count = count - 1;
        countText.text = count.ToString() + "";

        if (count <= 0)
        {
            Destroy(gameObject);
            player.canMove = true;
        }
    }
}
