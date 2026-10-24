using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public event Action change;
    public List<Item> items = new List<Item>();

    public void Awake()
    {
        instance = this;
    }
    public void AddItem(Item item)
    {
        items.Add(item);
        change?.Invoke();
        PickUpUI.instance.ShowPopup(item);
    }
}
