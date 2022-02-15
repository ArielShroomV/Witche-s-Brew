using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCauldron : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject canvasItems;
    Animator anim;
    [SerializeField] GameObject potionButton;
    public GameObject Cauldron;
    bool isClicked;
    BoxCollider2D boxCollider;


    void Start()
    {

        anim = GetComponent<Animator>();
        
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        Click();

    }
    private void Click()
    {
        if (isClicked == true && Input.GetMouseButtonDown(0))
        {

            if (CheckFull())
            {
                Debug.Log("potion made yayyy");
                // remove the canvas items of ingredients 
                canvasItems.SetActive(false);
                //animation
                anim.SetBool("isMaking", true);
                //  instant to make other button appear 
                Instantiate(potionButton);
                //stop using on click!! :( won't let click on potion
               
            }
            else
            {
                Debug.Log("not ready to use");
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
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isClicked = true;
        }

    }
    private void OnMouseUp()
    {
        isClicked = false;
    }
   
}
