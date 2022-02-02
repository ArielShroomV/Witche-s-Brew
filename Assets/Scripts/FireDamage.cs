using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            playerController player = collision.GetComponent<playerController>();
            ApplyDamage(player, 2);
            
        }
    }
    public void ApplyDamage(playerController player, int howmuch)
    {
        player.TakeDamage(howmuch);

    }
    
}
