using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSize : MonoBehaviour
{
    public float scale = .01f;
    public GameObject myPotion;
    public ParticleSystem smoke;
    [SerializeField] AudioSource sizeGrowSound;
    public GameObject potion;
    private void Update()
    {
        if (potion.activeInHierarchy)
        {
            Potion();
        }

    }
    public void ScaleWitch()
    {
        if (transform.localScale.x < 1)
        {
            Debug.Log("im normal");
            sizeGrowSound.Play();
            smoke.Play();
            transform.localScale = transform.localScale + new Vector3(scale, scale);
            myPotion.SetActive(false);
        }
    }
    public void Potion()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScaleWitch();
        }
    }
}
