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
       potionButton.SetActive(false);
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void RemoveItems(Inventory inventory)
    {
        foreach (var item in inventory.slots)
        {
            Destroy(canvasItems);
            Destroy(item);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isClicked = true;

            if (inventory.CheckIfFull())
            {
                Debug.Log("potion made yayyy");
                RemoveItems(inventory);
                anim.SetBool("isMaking", true);
               potionButton.SetActive(true);
                return;
            }
            else
            {
                Debug.Log("not ready to use");
            }
        }
    }
    private void OnMouseUp()
    {
        isClicked = false;
    }
}
