using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSize : MonoBehaviour
{
    public float scale = .01f;
    public GameObject myPotion;
    public void ScaleWitch()
    {
        if (transform.localScale.x < 1)
        {
            Debug.Log("im normal");
            transform.localScale = transform.localScale + new Vector3(scale, scale);
            myPotion.SetActive(false);
        }


    }
}
