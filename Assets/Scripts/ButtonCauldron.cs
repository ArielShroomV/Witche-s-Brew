using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCauldron : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject canvasItems;
    Animator anim;
    [SerializeField] GameObject potionButton;
    [SerializeField] AudioSource brewPotion;
    public GameObject Cauldron;
    bool isClicked;
    BoxCollider2D boxCollider;


    void Start()
    {
        potionButton.SetActive(false);
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        CauldronMake();
        
    }

    public void RemoveItems(Inventory inventory)
    {
        foreach (var item in inventory.slots)
        {
            Destroy(canvasItems);
            Destroy(item);
        }
    }
    public void CauldronMake()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isClicked = true;

            if (inventory.CheckIfFull())
            {
                Debug.Log("potion made yayyy");
                RemoveItems(inventory);
                anim.SetBool("isMaking", true);
                StartCoroutine(test());
                return;
            }
            else
            {
                Debug.Log("not ready to use");
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isClicked = false;
        }
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("delay done");
        brewPotion.Play();
        potionButton.SetActive(true);
        anim.SetBool("isMaking", false);
    }
}