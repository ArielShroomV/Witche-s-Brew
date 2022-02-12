using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCauldron : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject canvasItems;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CheckFull())
            {
                Debug.Log("potion made yayyy");
                // remove the canvas 
                canvasItems.SetActive(false);
                //animation
                anim.SetBool("isMaking", true);
                //  instant to make other button appear 

            }
        }
    }
    bool CheckFull()
    {
        foreach (var item in inventory.isFull)
        {
            if (item == false)
            {
                return false;
            }
        }
        return true;
    }
}
