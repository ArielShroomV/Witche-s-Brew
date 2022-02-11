using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
   [SerializeField] private Animator animator;
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform mouth;
    [SerializeField] private GameObject projectile;

    public GameObject Projectile { get => projectile; set => projectile = value; }

    void Start()
    {
        
    }

   
    void Update()
    {
        
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
