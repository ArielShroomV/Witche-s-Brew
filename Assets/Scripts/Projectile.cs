using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    [SerializeField] private string targetTag;


   
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void Setup(Vector2 direction)
    {
        this.direction = direction;
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
