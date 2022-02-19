using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemButton;
    [SerializeField] GameObject slot;
    public AudioClip pickUpSound;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var newItem = Instantiate(itemButton, slot.transform, false);
            inventory.AddNewItem(newItem);
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position, 0.1f);
            Destroy(gameObject);
        }
    }

}
