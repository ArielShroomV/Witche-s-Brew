using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{

    [SerializeField] Transform Player;
 
    void Update()
    {
        if (Player != null)
        transform.position = Player.position;
    }
}
