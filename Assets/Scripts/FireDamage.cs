using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            ApplyDamage(player, 2);
            
        }
    }
    public void ApplyDamage(PlayerController player, int howmuch)
    {
        player.TakeDamage(howmuch);

    }
    
}
