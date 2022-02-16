using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public bool CheckIfFull()
    {
        foreach (var slot in slots)
        {
            if (slot == null)
            {
                return false;
            }         
        }
        return true;
    }

    public void AddNewItem(GameObject newItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = newItem;
                return;
            }      
        }
    }
}
