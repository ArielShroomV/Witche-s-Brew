using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cauldronButton: MonoBehaviour
{
   [SerializeField] Inventory inventory;
    [SerializeField] GameObject canvasItems;
    Animator anim;
    public void Cauldron()
    {
       // if inventory full...
       if (CheckFull())
        {
            Debug.Log("potion made yay");
            // remove the canvas 
            canvasItems.SetActive(false);
            //animation
           anim.SetBool("isMaking", true);
            //  instant to make other button appear 
        }
       
    }

    bool CheckFull()
    {
        foreach(var item in inventory.isFull)
        {
            if(item == false)
            {
                return false;
            }
        }
        return true;
    }

    void Start()
    {
        Cauldron();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
