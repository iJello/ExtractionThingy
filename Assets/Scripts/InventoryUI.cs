using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform slotsParent;
    public GameObject slotPrefab;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            bool open = !inventoryPanel.activeSelf;
            inventoryPanel.SetActive(open);

            if (open)
            {
                Refresh();
            }
        }
    }

    private void Refresh()
    {
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }
        
        Dictionary<Item, int> counts = new Dictionary<Item, int>();

        foreach (Item item in Inventory.instance.items)
        {
            if (counts.ContainsKey(item))
            {
                counts[item] = counts[item] + 1;
            }
            else
            {
                counts[item] = 1;
            }
        }
        
        foreach (Item item in counts.Keys)
        {
            int count = counts[item];

            GameObject slot = Instantiate(slotPrefab, slotsParent);
            
            Image icon = slot.transform.Find("Icon").GetComponent<Image>();
            icon.sprite = item.icon;
            
            TMP_Text text = slot.GetComponentInChildren<TMP_Text>();

            if (count > 1)
            {
                text.text = item.itemName + " x" + count;
            }
            else
            {
                text.text = item.itemName;
            }
        }
    }
}