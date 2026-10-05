using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<String> items = new List<String>();

    public void AddItem(String itemName)
    {
        items.Add(itemName);
    }
}
