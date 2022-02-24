using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneCollision.instanse.StartCoroutine(SceneCollision.instanse.endcorotine());
        
    }
}
