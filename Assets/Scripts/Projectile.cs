using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Vector2 direction;
    [SerializeField] private string targetTag;

    Vector3 target;

    private void Start()
    {
        target = new Vector3(FindObjectOfType<PlayerController>().transform.position.x, transform.position.y, 0);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, target) <= 0.2)
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(gameObject);
    }
}
