using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{  
    public AudioSource start;
    public void PlayStart()
    {
        start.Play();
    }
} 
